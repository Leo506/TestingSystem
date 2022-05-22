using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem
{
    public class ProfileViewModel
    {
        public Data.User AuthUser { get; set; }

        public ProfileViewModel(Data.User user)
        {
            AuthUser = user;
        }

        public bool StartText(string guid, out Testing.Test test)
        {
            var db = DB.DBWorkerFactory.GetDBWorker();

            test = db.GetTest(guid);

            if (test.IsEmpty)
                return false;

            return true;
        }
    }
}
