using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Data
{
    public struct TestInfo
    {
        public double Result { get; set; }
        public string Guid { get; set; }

        public TestInfo(double result, string guid)
        {
            Result = result;
            Guid = guid;
        }
    }
}
