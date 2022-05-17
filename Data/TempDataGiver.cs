using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Testing;

namespace TestingSystem.Data
{
    public class TempDataGiver : IGivableData
    {
        public Test GetTest()
        {
            Test test = new Test();
            Question q1 = new Question(new string[] { "var 1", "var 2", "var 3" }, 0, "text text");
            Question q2 = new Question(new string[] { "var 4", "var 5", "var 6" }, 1, "text1 text1");
            Question q3 = new Question(new string[] { "var 5", "var 6", "var 7" }, 2, "text2 text2");

            test.AddQuestion(q1);
            test.AddQuestion(q2);
            test.AddQuestion(q3);

            return test;
        }
    }
}
