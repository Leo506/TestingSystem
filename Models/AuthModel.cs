using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Auth
{
    public class AuthModel : INotifyPropertyChanged
    {
        private bool _isAuthorized;
        public bool IsAuthorized
        {
            get { return _isAuthorized; }
            private set
            {
                _isAuthorized = value;
                OnPropertyChange(nameof(IsAuthorized));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public AuthModel()
        {
            _isAuthorized = false;
        }

        public bool TryAuth(string login, string password)
        {
            var db = DB.DBWorkerFactory.GetDBWorker();

            if (db.HasUser(login, password))
            {
                IsAuthorized = true;
                return true;
            }

            return false;
        }

        private void OnPropertyChange(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
