using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Security;
using Granikos.SMTPSimulator.Service.Database.Models;
using Granikos.SMTPSimulator.Service.Models;

namespace Granikos.SMTPSimulator.Service.Database.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ServiceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ServiceDbContext context)
        {
            if (!context.SendConnectors.Any())
            {
                context.SendConnectors.Add(new SendConnector
                {
                    Name = "Default",
                    UseSmarthost = false,
                    RetryTime = TimeSpan.FromMinutes(5),
                    RetryCount = 3,
                    Default = true
                });
            }

            if (!context.ReceiveConnectors.Any())
            {
                context.ReceiveConnectors.Add(new ReceiveConnector
                {
                    Name = "Default",
                    Enabled = true,
                    Address = IPAddress.Parse("0.0.0.0"),
                    Port = 25,
                    Banner = "nikos two ready DEFAULT",
                    TLSSettings = new TLSSettings
                    {
                        EncryptionPolicy = EncryptionPolicy.NoEncryption
                    },
                    GreylistingTime = TimeSpan.FromMinutes(15)
                });
            }
        }
    }
}