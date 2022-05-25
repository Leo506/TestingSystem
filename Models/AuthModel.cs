using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Data;

namespace TestingSystem.Auth
{
    public class AuthModel
    {
        public bool IsAuthorized { get; private set; }

        public User AuthUser { get; private set; }

        public Action<bool> AuthorizedEvent;

        public AuthModel()
        {
            IsAuthorized = false;
            AuthUser = User.Nobody;
        }

        public void TryAuth(string login, string password)
        {
            var db = DB.DBWorkerFactory.GetDBWorker();

            if (db.HasUser(login, password))
            {
                Trace.WriteLine("Has user");
                IsAuthorized = true;
                AuthUser = db.GetUser(login, password);
                Trace.WriteLine(AuthUser);
                AuthorizedEvent?.Invoke(true);
            }
            else
                AuthorizedEvent?.Invoke(false);
        }
    }
}
