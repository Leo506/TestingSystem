﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Testing;

namespace TestingSystem.DB
{
    public class StubDBWorler : IDBWorker
    {
        public Test GetTest(string guid)
        {
            return new Test();
        }

        public bool HasUser(string login, string password)
        {
            if ((login == "Admin" && password == "Admin") || (login == "User" && password == "User"))
                return true;

            return false;
        }
    }
}
