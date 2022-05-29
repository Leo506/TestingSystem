using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Settings
{
    public class Settings
    {


        public static string? GetSettings(string settingsName)
        {
            return ConfigurationManager.AppSettings[settingsName];
        }

        public static void SetSettings(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Trace.WriteLine("Old value: " + config.AppSettings.Settings[key].Value);
            config.AppSettings.Settings[key].Value = value;
            Trace.WriteLine("New value: " + config.AppSettings.Settings[key].Value);
            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
