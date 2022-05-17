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
            test = Data.DataFactory.BuildDataGiver().GetTest();
        }
    }
}
