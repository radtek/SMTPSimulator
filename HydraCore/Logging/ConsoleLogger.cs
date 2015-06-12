using System;
using System.ComponentModel.Composition;
using System.Net;

namespace HydraCore.Logging
{
    [Export(typeof(ISMTPLogger))]
    public class ConsoleLogger : ISMTPLogger
    {
        public void Log(string connectorId, string session, IPEndPoint local, IPEndPoint remote, LogPartType part, LogEventType type,
            string data)
        {
            if (IsConnectionEvent(type))
            {
                Console.WriteLine("[{0}] {1}{2}  L:{3} R:{4}", connectorId, PartSymbol(part), EventSymbol(type),
                    local, remote);
            }
            else
            {
                foreach (var l in (data ?? "").Split(new[] { "\r\n" }, StringSplitOptions.None))
                {
                    Console.WriteLine("[{0}] {1}{2} {3}", connectorId, PartSymbol(part), EventSymbol(type), l);
                }

            }
        }

        private static string PartSymbol(LogPartType part)
        {
            switch (part)
            {
                case LogPartType.Client:
                    return "C";
                case LogPartType.Server:
                    return "S";
                case LogPartType.Other:
                    return "O";
                default:
                    return null;
            }
        }

        private static string EventSymbol(LogEventType type)
        {
            switch (type)
            {
                case LogEventType.Connect:
                    return "*";
                case LogEventType.Disconnect:
                    return "+";
                case LogEventType.Incoming:
                    return "<";
                case LogEventType.Outgoing:
                    return ">";
                case LogEventType.Other:
                    return "?";
                default:
                    return null;
            }
        }

        private static bool IsConnectionEvent(LogEventType type)
        {
            switch (type)
            {
                case LogEventType.Connect:
                    return true;
                case LogEventType.Disconnect:
                    return true;
                default:
                    return false;
            }
        }
    }
}