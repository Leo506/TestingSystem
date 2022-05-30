using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Models;

namespace TestingSystem.Data
{
    public class TempDataGiver : IGivableData
    {
        public Test GetTest()
        {
            Test test = new Test();
            Question q1 = new Question(new string[] { "5", "4", "3" }, 0, "Сколько пальцев на руке у человека?");
            Question q2 = new Question(new string[] { "Венера", "Земля", "Марс" }, 1, "На какой планете мы живем?");
            Question q3 = new Question(new string[] { "Красный", "Зеленый", "Синий" }, 2, "Какого цвета небо?");

            test.AddQuestion(q1);
            test.AddQuestion(q2);
            test.AddQuestion(q3);

            return test;
        }
    }
}
