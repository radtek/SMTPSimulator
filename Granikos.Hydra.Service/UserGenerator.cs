using System;
using System.Diagnostics.Contracts;
using Granikos.Hydra.Service.Models;
using Granikos.Hydra.Service.Models.Providers;

namespace Granikos.Hydra.Service
{
    class UserGenerator
    {
        private readonly IDataProvider<IUser, int> _users;
        private readonly IUserTemplate _template;

        public UserGenerator(IDataProvider<IUser, int> users, IUserTemplate template)
        {
            Contract.Requires<ArgumentNullException>(users != null, "users");

            _users = users;
            _template = template;
        }

        public bool Generate(string pattern, string domain, int count)
        {
            foreach (var user in _template.Generate(pattern, domain, count))
            {
                if (_users.Add(user) == null) return false;
            }

            return true;
        }
    }
}