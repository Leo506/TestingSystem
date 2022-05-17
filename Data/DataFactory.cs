using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Data
{
    public class DataFactory
    {
        public static IGivableData BuildDataGiver()
        {
            return new TempDataGiver();
        }
    }
}
