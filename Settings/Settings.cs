using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
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
    }
}
