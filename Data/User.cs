using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Data
{
    public struct User
    {
        public int id { get; set; }
        public string name { get; set; }
        public int countOfTests { get; set; }

        public static User Nobody
        {
            get
            {
                return new User { name = "", countOfTests = 0, id = -1 };
            }
        }

        public User(int id, string name, int countOfTests)
        {
            this.id = id;
            this.name = name;
            this.countOfTests = countOfTests;
        }
    }
}
