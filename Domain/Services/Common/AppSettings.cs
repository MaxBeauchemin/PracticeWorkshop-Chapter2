using System.Configuration;

namespace Domain.Services.Common
{
    public static class AppSettings
    {
        public static string GetValue(string key, string defaultValue)
        {
            var configValue = ConfigurationManager.AppSettings[key];

            if (configValue == null)
            {
                return defaultValue;
            }

            return configValue;
        }

        public static string GetConnectionString(string key)
        {
            var connString = ConfigurationManager.ConnectionStrings[key];

            if (connString != null)
            {
                return connString.ConnectionString;
            }

            return null;
        }
    }
}
