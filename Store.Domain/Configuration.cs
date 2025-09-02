using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Domain
{
    public static class Configuration
    {
        public static SecretsConfiguration Secrets { get; set; } = new SecretsConfiguration();
        public static EmailConfiguration Email { get; set; } = new EmailConfiguration();

        public static SendGridConfigurations SendGrid { get; set; } = new SendGridConfigurations();
        public static DataBaseConfiguration Database { get; set; } = new DataBaseConfiguration();

        public class DataBaseConfiguration
        {
            public string ConnectionString { get; set; } = string.Empty;
        }

        public class EmailConfiguration
        {
            public string DefaultFromEmail { get; set; } = "Test@io";
            public string DefaultFromName { get; set; } = "Test";
        }

        public class SendGridConfigurations
        {
            public string ApiKey { get; set; } = string.Empty;
        }

        public class SecretsConfiguration
        {
            public string ApiKey { get; set; } = string.Empty;
            public string JwtPrivateKey { get; set; } = string.Empty;
            public string PasswordSaltKey { get; set; } = string.Empty;
        }
    }
}