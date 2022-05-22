using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.DB
{
    public interface IDBWorker
    {
        bool HasUser(string login, string password);
        Testing.Test GetTest(string guid);
    }
}
