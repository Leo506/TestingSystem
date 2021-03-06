using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem
{
    public class ProfileViewModel
    {
        public ProfileModel Profile { get; }

        public ProfileViewModel(Data.User user)
        {
            Profile = new ProfileModel(user);
            
        }


        public bool StartTest(string guid, out Testing.Test test)
        {
            var db = DB.DBWorkerFactory.GetDBWorker();

            test = db.GetTest(guid);

            if (test.IsEmpty)
                return false;

            return true;
        }
    }
}
