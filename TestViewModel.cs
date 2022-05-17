using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Testing;

namespace TestingSystem
{
    public class TestViewModel
    {
        private Test test;
        public ObservableCollection<Question> Questions
        {
            get
            {
                ObservableCollection<Question> q = new ObservableCollection<Question>();
                for (int i = 0; i < test.QuestionCount; i++)
                    q.Add(test.GetQuestion(i));
                return q;
            }
        }


        public TestViewModel()
        {
            test = new Test();
            AddTestData(test);
        }

        private void AddTestData(Test test)
        {
            Question q1 = new Question(new string[] { "var 1", "var 2", "var 3"}, 0, "text text");
            Question q2 = new Question(new string[] { "var 4", "var 5", "var 6" }, 1, "text1 text1");

            test.AddQuestion(q1);
            test.AddQuestion(q2);
        }
    }
}
