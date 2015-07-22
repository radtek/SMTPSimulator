using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using HydraService.Models;

namespace HydraService.Providers
{
    [Export(typeof(ISendConnectorProvider))]
    public class SendConnectorProvider : DefaultProvider<SendConnector>, ISendConnectorProvider
    {
        public SendConnectorProvider()
            : base("SendConnectors")
        {
        }

#if DEBUG
        protected override IEnumerable<SendConnector> Initializer()
        {
            yield return new SendConnector
            {
                Name = "Default"
            };
        }
#endif

        protected override bool CanRemove(int id)
        {
            return id != _defaultId;
        }

        private int _defaultId = 1;

        public int DefaultId
        {
            get { return _defaultId; }
            set
            {
                Contract.Requires<ArgumentException>(Get(value) != null);

                _defaultId = value;
            }
        }

        public SendConnector DefaultConnector { get { return Get(DefaultId); } }
    }
}