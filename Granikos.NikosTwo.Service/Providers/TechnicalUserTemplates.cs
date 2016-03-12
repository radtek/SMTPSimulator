using System.Collections.Generic;
using System.ComponentModel.Composition;
using Granikos.NikosTwo.Service.Models;
using Granikos.NikosTwo.Service.Models.Providers;
using User = Granikos.NikosTwo.Service.ConfigurationService.Models.User;

namespace Granikos.NikosTwo.Service.Providers
{
    [Export(typeof (IUserTemplateProvider))]
    public class TechnicalUserTemplates : IUserTemplateProvider
    {
        public IEnumerable<IUserTemplate> All()
        {
            yield return new TechnicalTemplate("english", "Technical (English)", "User", "{0}", "user{0}");
            yield return new TechnicalTemplate("german", "Technical (German)", "Benutzer", "{0}", "benutzer{0}");
        }

        private class TechnicalTemplate : IUserTemplate
        {
            private readonly string _firstNamePattern;
            private readonly string _lastNamePattern;
            private readonly string _mailboxPattern;

            public TechnicalTemplate(string name, string displayName, string firstNamePattern, string lastNamePattern,
                string mailboxPattern)
            {
                _firstNamePattern = firstNamePattern;
                _lastNamePattern = lastNamePattern;
                _mailboxPattern = mailboxPattern;
                Name = name;
                DisplayName = displayName;
            }

            public string Name { get; private set; }
            public string DisplayName { get; private set; }

            public bool SupportsPattern
            {
                get { return false; }
            }

            public IEnumerable<IUser> Generate(string pattern, string domain, int count)
            {
                for (var i = 1; i <= count; i++)
                {
                    yield return new User
                    {
                        FirstName = string.Format(_firstNamePattern, i),
                        LastName = string.Format(_lastNamePattern, i),
                        Mailbox = string.Format(_mailboxPattern, i) + "@" + domain
                    };
                }
            }
        }
    }
}