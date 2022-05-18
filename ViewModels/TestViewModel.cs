using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Testing;

namespace TestingSystem
{
    public class TestViewModel
    {
        private Test test;
        private int questionIndex;
        public Question Question
        {
            get { return test.GetQuestion(questionIndex); }
        }

        public TestViewModel()
        {
            questionIndex = 0;
            test = Data.DataFactory.BuildDataGiver().GetTest();
        }

        public void NextQuestion()
        {
            if (questionIndex + 1 < test.QuestionCount)
                questionIndex++;
        }
    }
}
