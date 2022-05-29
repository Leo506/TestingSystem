using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Data;
using TestingSystem.Testing;

namespace TestingSystem.DB
{
    public class StubDBWorler : IDBWorker
    {
        public List<TestInfo> GetPassedTests(int id)
        {
            throw new NotImplementedException();
        }

        public Test GetTest(string guid)
        {
            return Data.DataFactory.BuildDataGiver().GetTest();
        }

        public User GetUser(string login, string password)
        {
            return new User() { name = login == "Admin" ? "God" : "Nobody", countOfTests = 0 };
        }

        public bool HasUser(string login, string password)
        {
            if ((login == "Admin" && password == "Admin") || (login == "User" && password == "User"))
                return true;

            return false;
        }
    }
}
