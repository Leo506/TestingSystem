using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Testing;
using TestingSystem.Data;

namespace TestingSystem.DB
{
    public interface IDBWorker
    {
        bool HasUser(string login, string password);
        Test GetTest(string guid);

        User GetUser(string login, string password);

        List<TestInfo> GetPassedTests(int id);
    }
}
