using System;
using System.Collections.Generic;
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

        public AuthModel()
        {
            IsAuthorized = false;
            AuthUser = User.Nobody;
        }

        public bool TryAuth(string login, string password)
        {
            var db = DB.DBWorkerFactory.GetDBWorker();

            if (db.HasUser(login, password))
            {
                IsAuthorized = true;
                AuthUser = db.GetUser(login, password);
                return true;
            }

            return false;
        }
    }
}
