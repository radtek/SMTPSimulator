﻿// MIT License
// 
// Copyright (c) 2017 Granikos GmbH & Co. KG (https://www.granikos.eu)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Granikos.SMTPSimulator.Service.ConfigurationService;
using Granikos.SMTPSimulator.Service.ConfigurationService.Models;
using Granikos.SMTPSimulator.Service.Models;
using Granikos.SMTPSimulator.Service.Models.Providers;
using Granikos.SMTPSimulator.SmtpServer;
using log4net;

namespace Granikos.SMTPSimulator.Service
{
    public class JsonContentTypeMapper : WebContentTypeMapper
    {
        public override WebContentFormat GetMessageFormatForContentType(string contentType)
        {
            if (contentType.StartsWith("text/xml") || contentType.StartsWith("text/csv") ||
                contentType.StartsWith("application/octet-stream"))
            {
                return WebContentFormat.Raw;
            }

            return WebContentFormat.Json;
        }
    }


    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    public class ConfigurationServiceImpl : IConfigurationService
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof (IConfigurationService));
        private readonly IMailQueueProvider _mailQueue;
        private readonly ISMTPServerContainer _servers;

        [Import]
        private IAttachmentProvider _attachments;

        [Import]
        private ICertificateFileProvider _certificates;

        [Import]
        private IExternalMailboxGroupProvider _externalGroups;

        [Import]
        private IExternalUserProvider _externalUsers;

        [Import]
        private ILocalMailboxGroupProvider _localGroups;

        [Import]
        private ILocalUserProvider _localUsers;

        [Import]
        private ILogProvider _logs;

        [Import]
        private IMailTemplateProvider _mailTemplates;

        [Import]
        private IReceiveConnectorProvider _receiveConnectors;

        [Import]
        private ISendConnectorProvider _sendConnectors;

        [ImportMany]
        private IEnumerable<IUserTemplateProvider> _templateProviders;

        [Import]
        private ITimeTableProvider _timeTables;

        public ConfigurationServiceImpl(SMTPServer server, ISMTPServerContainer servers, IMailQueueProvider mailQueue)
        {
            if (server == null) throw new ArgumentNullException("server");
            if (servers == null) throw new ArgumentNullException("servers");
            if (mailQueue == null) throw new ArgumentNullException("mailQueue");

            _servers = servers;
            _mailQueue = mailQueue;
            SmtpServer = server;
        }

        public SMTPServer SmtpServer { get; private set; }

        [Import(AllowRecomposition = true)]
        private CompositionContainer _container { get; set; }

        public IEnumerable<UserGroup> GetLocalGroups()
        {
            return _localGroups.All().Select(g => g.ConvertTo<UserGroup>());
        }

        public UserGroup GetLocalGroup(int id)
        {
            return _localGroups.Get(id).ConvertTo<UserGroup>();
        }

        public UserGroup UpdateLocalGroup(UserGroup userGroup)
        {
            return _localGroups.Update(userGroup).ConvertTo<UserGroup>();
        }

        public UserGroup AddLocalGroup(string name)
        {
            return _localGroups.Add(name).ConvertTo<UserGroup>();
        }

        public bool DeleteLocalGroup(int id)
        {
            return _localGroups.Delete(id);
        }

        public IEnumerable<UserGroup> GetExternalGroups()
        {
            return _externalGroups.All().Select(g => g.ConvertTo<UserGroup>());
        }

        public UserGroup GetExternalGroup(int id)
        {
            return _externalGroups.Get(id).ConvertTo<UserGroup>();
        }

        public UserGroup UpdateExternalGroup(UserGroup userGroup)
        {
            return _externalGroups.Update(userGroup).ConvertTo<UserGroup>();
        }

        public UserGroup AddExternalGroup(string name)
        {
            return _externalGroups.Add(name).ConvertTo<UserGroup>();
        }

        public bool DeleteExternalGroup(int id)
        {
            return _externalGroups.Delete(id);
        }

        public IEnumerable<SendConnector> GetSendConnectors()
        {
            return _sendConnectors.All().Select(s => s.ConvertTo<SendConnector>());
        }

        public SendConnector GetSendConnector(int id)
        {
            return _sendConnectors.Get(id).ConvertTo<SendConnector>();
        }

        public SendConnector AddSendConnector(SendConnector connector)
        {
            return _sendConnectors.Add(connector).ConvertTo<SendConnector>();
        }

        public SendConnector UpdateSendConnector(SendConnector connector)
        {
            return _sendConnectors.Update(connector).ConvertTo<SendConnector>();
        }

        public bool DeleteSendConnector(int id)
        {
            return _sendConnectors.Delete(id);
        }

        public IEnumerable<User> GetLocalUsersByDomain(string domain)
        {
            return _localUsers.GetByDomain(domain).Select(u => u.ConvertTo<User>());
        }

        public IEnumerable<ValueWithCount<string>> SearchExternalUserDomains(string domain)
        {
            return _externalUsers.SearchDomains(domain);
        }

        public IEnumerable<ValueWithCount<string>> SearchLocalUserDomains(string domain)
        {
            return _localUsers.SearchDomains(domain);
        }

        public IEnumerable<User> GetExternalUsersByDomain(string domain)
        {
            return _externalUsers.GetByDomain(domain).Select(u => u.ConvertTo<User>());
        }

        public int GetLocalUserCount()
        {
            return _localUsers.Total;
        }

        public TimeTable GetEmptyTimeTable()
        {
            var tt = _timeTables.GetEmptyTimeTable().ConvertTo<TimeTable>();

            tt.Parameters = _container.GetExportedTypesWithContracts<ITimeTableType>()
                .Select(t => _container.GetExportedValue<ITimeTableType>(t.Item2))
                .SelectMany(type => type.InitialParameters)
                .ToLookup(pair => pair.Key, pair => pair.Value)
                .ToDictionary(group => group.Key, group => group.First());

            return tt;
        }

        public SendConnector GetDefaultSendConnector()
        {
            return _sendConnectors.DefaultConnector.ConvertTo<SendConnector>();
        }

        public bool SetDefaultSendConnector(int id)
        {
            try
            {
                _sendConnectors.DefaultId = id;
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<VersionInfo> GetVersionInfo()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.FullName.StartsWith("Granikos.SMTPSimulator"))
                .Select(a => new VersionInfo
                {
                    Assembly = a.GetName().Name.Split('.').Last(),
                    BuildDate = a.GetBuildDate(),
                    Version = a.GetName().Version
                });
        }

        public string[] GetLogNames()
        {
            return _logs.FileNames;
        }

        public Stream GetLogFile(string name)
        {
            var stream = new MemoryStream();
            _logs.GetFile(stream, name);

            stream.Position = 0;

            return stream;
        }

        public SendConnector GetEmptySendConnector()
        {
            return _sendConnectors.GetEmptyConnector().ConvertTo<SendConnector>();
        }

        public ReceiveConnector GetDefaultReceiveConnector()
        {
            return _receiveConnectors.GetEmptyConnector().ConvertTo<ReceiveConnector>();
        }

        public IEnumerable<ReceiveConnector> GetReceiveConnectors()
        {
            return _receiveConnectors.All().Select(r => r.ConvertTo<ReceiveConnector>());
        }

        public ReceiveConnector GetReceiveConnector(int id)
        {
            return _receiveConnectors.Get(id).ConvertTo<ReceiveConnector>();
        }

        public ReceiveConnector AddReceiveConnector(ReceiveConnector connector)
        {
            return _receiveConnectors.Add(connector).ConvertTo<ReceiveConnector>();
        }

        public ReceiveConnector UpdateReceiveConnector(ReceiveConnector connector)
        {
            return _receiveConnectors.Update(connector).ConvertTo<ReceiveConnector>();
        }

        public bool DeleteReceiveConnector(int id)
        {
            return _receiveConnectors.Delete(id);
        }

        public EntitiesWithTotal<User> GetLocalUsers(int page, int perPage)
        {
            var users = _localUsers.Paged(page, perPage).Select(u => u.ConvertTo<User>()).ToList();
            var total = _localUsers.Total;
            var result = new EntitiesWithTotal<User>(users, total);
            return result;
        }

        public IEnumerable<string> SearchLocalUsers(string search)
        {
            return _localUsers.SearchMailboxes(search, 20);
        }

        public User GetLocalUser(int id)
        {
            return _localUsers.Get(id).ConvertTo<User>();
        }

        public User AddLocalUser(User connector)
        {
            return _localUsers.Add(connector).ConvertTo<User>();
        }

        public User UpdateLocalUser(User connector)
        {
            return _localUsers.Update(connector).ConvertTo<User>();
        }

        public bool DeleteLocalUser(int id)
        {
            return _localUsers.Delete(id);
        }

        public Stream ExportLocalUsers()
        {
            var exporter = new UserExporter(_localUsers);
            var stream = new MemoryStream();
            exporter.ExportAsCSV(stream);

            stream.Position = 0;

            return stream;
        }

        public ImportResult ImportLocalUsers(Stream stream)
        {
            var importer = new UserImporter(_localUsers);
            var count = importer.ImportFromCSV(stream, false);

            return new ImportResult(count, 0);
        }

        public ImportResult ImportLocalUsersWithOverwrite(Stream stream)
        {
            var importer = new UserImporter(_localUsers);
            var before = _localUsers.Total;
            var count = importer.ImportFromCSV(stream, true);

            return new ImportResult(count, before);
        }

        public bool GenerateLocalUsers(string templateName, string pattern, string domain, int count)
        {
            var parts = templateName.Split(new[] {'/'}, 2);
            var template = _templateProviders
                .SelectMany(t => t.All())
                .First(t => t.GetType().Name.Equals(parts[0], StringComparison.InvariantCultureIgnoreCase)
                            && t.Name.Equals(parts[1], StringComparison.InvariantCultureIgnoreCase));

            var generator = new UserGenerator(_localUsers, template);

            return generator.Generate(pattern, domain, count);
        }

        public IEnumerable<UserTemplate> GetLocalUserTemplates()
        {
            try
            {
                return _templateProviders
                    .SelectMany(t => t.All())
                    .Select(t => new UserTemplate(t.GetType().Name + "/" + t.Name, t.DisplayName, t.SupportsPattern))
                    .OrderBy(t => t.DisplayName);
            }
            catch (Exception e)
            {
                Logger.Error("Template error", e);
                // TODO
                return new UserTemplate[0];
            }
        }

        public EntitiesWithTotal<User> GetExternalUsers(int page, int perPage)
        {
            return new EntitiesWithTotal<User>(_externalUsers.Paged(page, perPage).Select(u => u.ConvertTo<User>()),
                _externalUsers.Total);
        }

        public int GetExternalUserCount()
        {
            return _externalUsers.Total;
        }

        public IEnumerable<string> SearchExternalUsers(string search)
        {
            return _externalUsers.SearchMailboxes(search, 20);
        }

        public User GetExternalUser(int id)
        {
            return _externalUsers.Get(id).ConvertTo<User>();
        }

        public User AddExternalUser(User user)
        {
            return _externalUsers.Add(user).ConvertTo<User>();
        }

        public User UpdateExternalUser(User user)
        {
            return _externalUsers.Update(user).ConvertTo<User>();
        }

        public bool DeleteExternalUser(int id)
        {
            return _externalUsers.Delete(id);
        }

        public MailTemplate AddMailTemplate(MailTemplate template)
        {
            return _mailTemplates.Add(template).ConvertTo<MailTemplate>();
        }

        public MailTemplate ImportMailTemplate(Stream stream)
        {
            return new MailTemplateImporter(_mailTemplates).ImportFromXml(stream);
        }

        public Stream ExportMailTemplate(int id)
        {
            var template = _mailTemplates.Get(id).ConvertTo<MailTemplate>();
            var exporter = new MailTemplateExporter();
            var stream = new MemoryStream();
            exporter.ExportAsXml(stream, template);

            stream.Position = 0;

            return stream;
        }

        public MailTemplate GetMailTemplate(int id)
        {
            return _mailTemplates.Get(id).ConvertTo<MailTemplate>();
        }

        public MailTemplate UpdateMailTemplate(MailTemplate template)
        {
            return _mailTemplates.Update(template).ConvertTo<MailTemplate>();
        }

        public bool DeleteMailTemplate(int id)
        {
            return _mailTemplates.Delete(id);
        }

        public IEnumerable<NameWithDisplayName> GetCertificateTypes()
        {
            foreach (var type in _container.GetExportedTypesWithContracts<ICertificateProvider>())
            {
                var dn = (DisplayNameAttribute)Attribute.GetCustomAttribute(type.Item1, typeof(DisplayNameAttribute));

                yield return new NameWithDisplayName
                {
                    Name = type.Item2,
                    DisplayName = dn != null ? dn.DisplayName : type.Item2
                };
            }
        }

        public IEnumerable<string> GetCertificates(string type)
        {
            var provider = _container.GetExportedValue<ICertificateProvider>(type);

            return provider.ListCertificates().ToArray();
        }

        public bool UploadCertificate(string name, Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                var content = memoryStream.ToArray();

                return _certificates.Add(new Certificate
                {
                    Name = name,
                    Content = content
                });
            }
        }

        public Stream DownloadCertificate(string name)
        {
            var cert = _certificates.Get(name);

            return new MemoryStream(cert.Content);
        }

        public bool DeleteCertificate(string name)
        {
            return _certificates.Delete(name);
        }


        public IEnumerable<TimeTable> GetTimeTables()
        {
            return _timeTables.All().Select(t => t.ConvertTo<TimeTable>());
        }

        public IEnumerable<NameWithDisplayName> GetTimeTableTypes()
        {
            foreach (var type in _container.GetExportedTypesWithContracts<ITimeTableType>())
            {
                var dn = (DisplayNameAttribute) Attribute.GetCustomAttribute(type.Item1, typeof (DisplayNameAttribute));

                yield return new NameWithDisplayName
                {
                    Name = type.Item2,
                    DisplayName = dn != null ? dn.DisplayName : type.Item2
                };
            }
        }

        public IEnumerable<Attachment> GetAttachments()
        {
            return _attachments.All().Select(a => a.ConvertTo<Attachment>()).ToList();
        }

        public Attachment UploadAttachment(string name, int size, Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                var content = memoryStream.ToArray();

                _attachments.Add(new Attachment
                {
                    Name = name,
                    Content = content,
                    Size = size
                });
            }

            return new Attachment
            {
                Name = name,
                Size = size
            };
        }

        public Stream DownloadAttachment(string name)
        {
            var attachment = _attachments.Get(name);

            return new MemoryStream(attachment.Content);
        }

        public bool RenameAttachment(string oldName, string newName)
        {
            return _attachments.Rename(oldName, newName);
        }

        public bool DeleteAttachment(string name)
        {
            return _attachments.Delete(name);
        }

        public IEnumerable<MailTemplate> GetMailTemplates()
        {
            return _mailTemplates.All().Select(ModelHelpers.ConvertTo<MailTemplate>).ToArray();
        }

        public IDictionary<string, string> GetTimeTableTypeData(string type)
        {
            return _container.GetExportedValue<ITimeTableType>(type).Data;
        }

        public TimeTable GetTimeTable(int id)
        {
            return _timeTables.Get(id).ConvertTo<TimeTable>();
        }

        public TimeTable AddTimeTable(TimeTable timeTable)
        {
            return _timeTables.Add(timeTable).ConvertTo<TimeTable>();
        }

        public TimeTable UpdateTimeTable(TimeTable timeTable)
        {
            return _timeTables.Update(timeTable).ConvertTo<TimeTable>();
        }

        public bool DeleteTimeTable(int id)
        {
            return _timeTables.Delete(id);
        }

        public Stream ExportExternalUsers()
        {
            var exporter = new UserExporter(_externalUsers);
            var stream = new MemoryStream();
            exporter.ExportAsCSV(stream);

            stream.Position = 0;

            return stream;
        }

        public ImportResult ImportExternalUsers(Stream stream)
        {
            var exporter = new UserImporter(_externalUsers);
            var count = exporter.ImportFromCSV(stream, false);

            return new ImportResult(count, 0);
        }

        public ImportResult ImportExternalUsersWithOverwrite(Stream stream)
        {
            var exporter = new UserImporter(_externalUsers);
            var before = _externalUsers.Total;
            var count = exporter.ImportFromCSV(stream, true);

            return new ImportResult(count, before);
        }

        public void Start()
        {
            _servers.StartSMTPServers();
        }

        public void Stop()
        {
            _servers.StopSMTPServers();
        }

        public bool IsRunning()
        {
            return _servers.Running;
        }

        public void SendMail(MailMessage msg)
        {
            _mailQueue.Enqueue(msg);
        }
    }
}