using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestingSystem.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string? _url;
        public string? Url
        {
            get { return _url; }
            set
            {
                Trace.WriteLine("New url: " + value);
                bool isValid = Regex.IsMatch(value, "^((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\\.){3}(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])$");
                if (isValid)
                {
                    _url = value;
                    OnPropertyChange(nameof(Url));

                    string newBaseUrl = "http://" + _url + ":8080";
                    Trace.WriteLine(newBaseUrl);
                    Settings.Settings.SetSettings("baseUrl", newBaseUrl);
                }
            }
        }

        private bool _useLocalDB;
        public bool UseLocalDB
        {
            get { return _useLocalDB;}
            set
            {
                _useLocalDB = value;
                OnPropertyChange(nameof(UseLocalDB));

                Settings.Settings.SetSettings("database", _useLocalDB ? "local" : "remote");
            }
        }

        private void OnPropertyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public SettingsViewModel()
        {
            string? tmp = Settings.Settings.GetSettings("baseUrl");
            _url = tmp?.Substring(7, tmp.Length - 12);
            _useLocalDB = Settings.Settings.GetSettings("database") == "local";
        }
    }
}
