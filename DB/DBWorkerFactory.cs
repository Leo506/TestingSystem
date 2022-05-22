using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.DB
{
    public class DBWorkerFactory
    {
        public static IDBWorker GetDBWorker() => new StubDBWorler();
    }
}
