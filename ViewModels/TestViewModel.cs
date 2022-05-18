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
        private List<QuestionViewModel> questions;
        public QuestionViewModel Question
        {
            get { return questions[questionIndex]; }
        }

        public bool HasPreviousQuestion { get => questionIndex > 0; }

        public TestViewModel()
        {
            questionIndex = 0;
            test = Data.DataFactory.BuildDataGiver().GetTest();
            questions = new List<QuestionViewModel>();
            for (int i = 0; i < test.QuestionCount; i++)
            {
                questions.Add(new QuestionViewModel(test.GetQuestion(i)));
            }
        }

        public bool NextQuestion()
        {
            if (questionIndex + 1 < test.QuestionCount)
            {
                questionIndex++;
                return true;
            }
            return false;
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

        public Test GetTest() => test;
    }
}
