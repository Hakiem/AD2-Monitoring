using System;
using System.Configuration;

namespace Application.Core
{
    public abstract class ConfigurationSection
    {
        public static String ConnString
        {
            get
            {
                var connectionStringSetting = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
                if (string.IsNullOrEmpty(connectionStringSetting))
                    throw new Exception("Fatal Error : Cannot find the connectionString in web.config");

                return connectionStringSetting;
            }
        }
    }
}
