using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Granikos.NikosTwo.Core;
using Granikos.NikosTwo.Core.Logging;
using Granikos.NikosTwo.Service.Models;
using Granikos.NikosTwo.Service.Models.Providers;
using Granikos.NikosTwo.SmtpServer;
using log4net;

namespace Granikos.NikosTwo.Service
{
    internal class ClientHandler
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof (ClientHandler));
        private readonly TcpClient _client;
        private readonly IPEndPoint _localEndpoint;
        private readonly string _name;
        private readonly IPEndPoint _remoteEndpoint;
        private readonly SMTPService _smtpServer;
        private readonly TLSConnector _tlsConnector;

        [ImportMany]
        private IEnumerable<ISMTPLogger> _loggers;

        private StreamReader _reader;
        private string _session;
        private bool _startTLS;
        private Stream _stream;
        private SMTPTransaction _transaction;
        private StreamWriter _writer;

        public ClientHandler(TcpClient client, SMTPService smtpServer, CompositionContainer container)
        {
            _client = client;
            _smtpServer = smtpServer;

            var certProvider = _smtpServer.Connector.TLSSettings.CertificateType != null
                ? container.GetExportedValue<ICertificateProvider>(_smtpServer.Connector.TLSSettings.CertificateType)
                : null;

            _tlsConnector = new TLSConnector(_smtpServer.Connector.TLSSettings, CertificateLog, certProvider);
            _localEndpoint = (IPEndPoint) _client.Client.LocalEndPoint;
            _remoteEndpoint = (IPEndPoint) _client.Client.RemoteEndPoint;
            _name = _localEndpoint.Address.ToString();
            _stream = _client.GetStream();
            _startTLS = false;
        }

        private void CertificateLog(string msg)
        {
            Log(LogEventType.Certificate, msg);
        }

        private void StartSession()
        {
            _session = Guid.NewGuid().ToString("N").Substring(0, 10);

            foreach (var logger in _loggers)
            {
                logger.StartSession(_session);
            }
        }

        private void EndSession()
        {
            foreach (var logger in _loggers)
            {
                logger.EndSession(_session);
            }
        }

        private void Log(LogEventType type, string data = null)
        {
            if (_session == null)
            {
                StartSession();
            }

            foreach (var logger in _loggers)
            {
                logger.Log(_name, _session, _localEndpoint, _remoteEndpoint, LogPartType.Server, type, data);
            }
        }

        public async Task Process()
        {
            try
            {
                Log(LogEventType.Connect);

                SMTPResponse response;
                _transaction = _smtpServer.SMTPServer.StartTransaction(_remoteEndpoint.Address, _smtpServer.Settings,
                    out response);

                if (_tlsConnector.Settings.Mode == TLSMode.FullTunnel)
                {
                    await StartTLS();
                }

                RefreshReaderAndWriter();

                _transaction.OnStartTLS += OnStartTLS;
                _transaction.OnClose += OnCloseHandler;

                await Write(response);

                try
                {
                    while (!_reader.EndOfStream && !_transaction.Closed)
                    {
                        await Write(_transaction.ExecuteCommand(await Read()));

                        while (_transaction.InDataMode)
                        {
                            string line;
                            var data = new StringBuilder();

                            do
                            {
                                line = await _reader.ReadLineAsync();
                            } while (_transaction.HandleDataLine(line, data));

                            await Write(_transaction.HandleData(data.ToString()));
                        }

                        if (_startTLS)
                        {
                            await StartTLS();

                            RefreshReaderAndWriter();
                            RefreshTransaction();

                            _startTLS = false;
                        }
                    }
                }
                catch (IOException)
                {
                }
            }
            catch (Exception e)
            {
                Logger.Error("Error while handling client connection.", e);
            }
            finally
            {
                Close();
            }
        }

        private void RefreshReaderAndWriter()
        {
            RefreshWriter();
            RefreshReader();
        }

        private void OnStartTLS(object sender, CancelEventArgs e)
        {
            _startTLS = true;
        }

        private void Close()
        {
            if (_transaction != null) _transaction.Close();

            if (_writer != null) _writer.Close();
            if (_reader != null) _reader.Close();
            if (_stream != null) _stream.Close();
            if (_client != null) _client.Close();

            EndSession();
        }

        private async Task<SMTPCommand> Read()
        {
            var line = await _reader.ReadLineAsync();

            Log(LogEventType.Incoming, line);

            var parts = line.Split(new[] {' '}, 2);

            return parts.Length > 1 ? new SMTPCommand(parts[0], parts[1]) : new SMTPCommand(parts[0]);
        }

        private async Task Write(SMTPResponse response)
        {
            if (_stream.CanWrite)
            {
                Log(LogEventType.Outgoing, response.ToString());

                await _writer.WriteLineAsync(response.ToString());
                _writer.Flush();
            }
        }

        private void OnCloseHandler(SMTPTransaction transaction)
        {
            Log(LogEventType.Disconnect);
        }

        private void RefreshTransaction()
        {
            SMTPResponse response;
            _transaction.OnClose -= OnCloseHandler;
            _transaction.Close();
            _transaction = _smtpServer.SMTPServer.StartTransaction(_remoteEndpoint.Address, _smtpServer.Settings,
                out response);
            _transaction.TLSActive = true;
            _transaction.OnClose += OnCloseHandler;
        }

        private async Task StartTLS()
        {
            var sslStream = _tlsConnector.GetSslStream(_stream);

            await _tlsConnector.AuthenticateAsServerAsync(sslStream);

            Log(LogEventType.Other, "TLS Layer established.");

            _tlsConnector.DisplaySecurityLevel(sslStream);
            _tlsConnector.DisplaySecurityServices(sslStream);
            _tlsConnector.DisplayCertificateInformation(sslStream);

            _transaction.TLSActive = true;
            _stream = sslStream;
        }

        private void RefreshReader()
        {
            if (_reader != null) _reader.Close();
            _reader = new StreamReader(_stream, Encoding.ASCII, false, 1000, true);
        }

        private void RefreshWriter()
        {
            if (_writer != null) _writer.Close();
            _writer = new StreamWriter(_stream, Encoding.ASCII, 1000, true) {NewLine = "\r\n"};
        }
    }
}