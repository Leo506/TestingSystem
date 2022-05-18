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

        public bool HasPreviousQuestion { get => questionIndex > 0; }

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

        public void SelectAnswer(string answer)
        {
            test.SelectAnswer(questionIndex, answer);
            Trace.WriteLine("Stats: " + test.Statistic);
        }

        public void PreviousQuestion()
        {
            if (questionIndex - 1 >= 0)
                questionIndex--;
        }
    }
}
