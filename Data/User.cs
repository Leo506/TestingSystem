using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Data
{
    public struct User
    {
        public string Name { get; set; }
        public int CountOfTests { get; set; }

        public static User Nobody
        {
            get
            {
                return new User { Name = "", CountOfTests = 0 };
            }
        }

        public User(string name, int countOfTests)
        {
            Name = name;
            CountOfTests = countOfTests;
        }
    }
}
