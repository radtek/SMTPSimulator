using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using Granikos.Hydra.Service.Models;

namespace Granikos.Hydra.Service
{
    [ServiceContract]
    public interface IConfigurationService
    {
        [OperationContract]
        [WebGet(
            UriTemplate = "Version",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        VersionInfo GetVersionInfo();

        [OperationContract]
        [WebGet(
            UriTemplate = "Logs",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string[] GetLogNames();

        [OperationContract]
        [WebGet(
            UriTemplate = "Logs/{name}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        Stream GetLogFile(string name);

        [OperationContract]
        void SetProperty(string name, string value);

        [OperationContract]
        [WebGet(
            UriTemplate = "LocalGroups",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<MailboxGroup> GetLocalGroups();

        [WebGet(
            UriTemplate = "LocalGroups/{id}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        MailboxGroup GetLocalGroup(int id);

        [WebInvoke(
            UriTemplate = "LocalGroups",
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        MailboxGroup UpdateLocalGroup(MailboxGroup mailboxGroup);

        [WebInvoke(
            UriTemplate = "LocalGroups/{name}",
            Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        MailboxGroup AddLocalGroup(string name);

        [WebInvoke(
            UriTemplate = "LocalGroups/{id}",
            Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool DeleteLocalGroup(int id);

        [OperationContract]
        [WebGet(
            UriTemplate = "ExternalGroups",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<MailboxGroup> GetExternalGroups();

        [WebGet(
            UriTemplate = "ExternalGroups/{id}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        MailboxGroup GetExternalGroup(int id);

        [WebInvoke(
            UriTemplate = "ExternalGroups",
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        MailboxGroup UpdateExternalGroup(MailboxGroup mailboxGroup);

        [WebInvoke(
            UriTemplate = "ExternalGroups/{name}",
            Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        MailboxGroup AddExternalGroup(string name);

        [WebInvoke(
            UriTemplate = "ExternalGroups/{id}",
            Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool DeleteExternalGroup(int id);

        // TODO: Clean up
        [OperationContract]
        [WebGet(
            UriTemplate = "DefaultReceiveConnector",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        ReceiveConnector GetDefaultReceiveConnector();

        [OperationContract]
        [WebGet(
            UriTemplate = "ReceiveConnectors",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<ReceiveConnector> GetReceiveConnectors();

        [OperationContract]
        [WebGet(
            UriTemplate = "ReceiveConnectors/{id}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        ReceiveConnector GetReceiveConnector(int id);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "ReceiveConnectors",
            Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        ReceiveConnector AddReceiveConnector(ReceiveConnector connector);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "ReceiveConnectors",
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        ReceiveConnector UpdateReceiveConnector(ReceiveConnector connector);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "ReceiveConnectors/{id}",
            Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool DeleteReceiveConnector(int id);

        [OperationContract]
        [WebGet(
            UriTemplate = "DefaultSendConnector",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        SendConnector GetEmptySendConnector();

        [WebGet(
            UriTemplate = "DefaultSendConnector",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        SendConnector GetDefaultSendConnector();

        [WebInvoke(
            UriTemplate = "DefaultSendConnector/{id}",
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool SetDefaultSendConnector(int id);

        [OperationContract]
        [WebGet(
            UriTemplate = "SendConnectors",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<SendConnector> GetSendConnectors();

        [OperationContract]
        [WebGet(
            UriTemplate = "SendConnectors/{id}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        SendConnector GetSendConnector(int id);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "SendConnectors",
            Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        SendConnector AddSendConnector(SendConnector connector);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "SendConnectors",
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        SendConnector UpdateSendConnector(SendConnector connector);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "SendConnectors/{id}",
            Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool DeleteSendConnector(int id);

        [OperationContract]
        [WebGet(
            UriTemplate = "LocalUsers/ByDomain/{domain}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<User> GetLocalUsersByDomain(string domain);

        [OperationContract]
        [WebGet(
            UriTemplate = "ExternalUsers/SearchDomains/{domain}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<ValueWithCount<string>> SearchExternalUserDomains(string domain);

        [OperationContract]
        [WebGet(
            UriTemplate = "ExternalUsers/ByDomain/{domain}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<User> GetExternalUsersByDomain(string domain);

        [OperationContract]
        [WebGet(
            UriTemplate = "LocalUsers/Count",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        int GetLocalUserCount();

        [OperationContract]
        [WebGet(
            UriTemplate = "LocalUsers/{perPage}/{page}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        EntitiesWithTotal<User> GetLocalUsers(int page, int perPage);

        [OperationContract]
        [WebGet(
            UriTemplate = "LocalUsers/Search/{search}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<string> SearchLocalUsers(string search);

        [OperationContract]
        [WebGet(
            UriTemplate = "LocalUsers/{id}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        User GetLocalUser(int id);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "LocalUsers",
            Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        User AddLocalUser(User user);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "LocalUsers/{id}",
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        User UpdateLocalUser(User user);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "LocalUsers/{id}",
            Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool DeleteLocalUser(int id);

        [OperationContract]
        [WebGet(
            UriTemplate = "LocalUsers/Export",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        Stream ExportLocalUsers();

        [OperationContract]
        [WebInvoke(
            UriTemplate = "LocalUsers/Import",
            Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        ImportResult ImportLocalUsers(Stream stream);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "LocalUsers/ImportWithOverwrite",
            Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        ImportResult ImportLocalUsersWithOverwrite(Stream stream);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "LocalUsers/Generate",
            Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool GenerateLocalUsers(string template, string pattern, string domain, int count);

        [OperationContract]
        [WebGet(
            UriTemplate = "LocalUsers/Templates",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<UserTemplate> GetLocalUserTemplates();

        [OperationContract]
        [WebGet(
            UriTemplate = "ExternalUsers/{perPage}/{page}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        EntitiesWithTotal<User> GetExternalUsers(int page, int perPage);

        [OperationContract]
        [WebGet(
            UriTemplate = "ExternalUsers/Count",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        int GetExternalUserCount();

        [OperationContract]
        [WebGet(
            UriTemplate = "ExternalUsers/Search/{search}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<string> SearchExternalUsers(string search);

        [OperationContract]
        [WebGet(
            UriTemplate = "ExternalUsers/{id}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        User GetExternalUser(int id);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "ExternalUsers",
            Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        User AddExternalUser(User user);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "ExternalUsers",
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        User UpdateExternalUser(User user);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "ExternalUsers/{id}",
            Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool DeleteExternalUser(int id);

        [OperationContract]
        [WebGet(
            UriTemplate = "TimeTables",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<TimeTable> GetTimeTables();

        [OperationContract]
        [WebGet(
            UriTemplate = "TimeTables/{id}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        TimeTable GetTimeTable(int id);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "TimeTables",
            Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        TimeTable AddTimeTable(TimeTable timeTable);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "TimeTables",
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        TimeTable UpdateTimeTable(TimeTable timeTable);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "TimeTables/{id}",
            Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool DeleteTimeTable(int id);

        [OperationContract]
        [WebGet(
            UriTemplate = "ExternalUsers/Export",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        Stream ExportExternalUsers();

        [OperationContract]
        [WebInvoke(
            UriTemplate = "ExternalUsers/Import",
            Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        ImportResult ImportExternalUsers(Stream stream);

        [OperationContract]
        [WebInvoke(
            UriTemplate = "ExternalUsers/ImportWithOverwrite",
            Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        ImportResult ImportExternalUsersWithOverwrite(Stream stream);

        [OperationContract]
        [WebGet(
            UriTemplate = "Certificates",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string[] GetCertificateFiles();

        [OperationContract]
        [WebGet(
            UriTemplate = "Server/Start",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void Start();

        [OperationContract]
        [WebGet(
            UriTemplate = "Server/Stop",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void Stop();

        [OperationContract]
        [WebGet(
            UriTemplate = "Server/IsRunning",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        bool IsRunning();

        [OperationContract]
        [WebInvoke(
            UriTemplate = "Mail",
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void SendMail(MailMessage msg);
    }
}