using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Models;

namespace TestingSystem.ViewModels
{
    public class SummaryViewModel
    {
        public int CorrectAnswersCount { get; private set; }
        public int AllAnswersCount { get; private set; }

        public string Result { get; private set; }

        public static event Action<double>? TestEndEvent;

        public SummaryViewModel(Test test)
        {
            Question[] questions = new Question[test.QuestionCount];
            for (int i = 0; i < questions.Length; i++)
                questions[i] = test.GetQuestion(i);

            CorrectAnswersCount = questions.Where(q => q.GetState() == QuestionStates.CORRECT_ANSWER).Count();
            AllAnswersCount = questions.Length;
            double tmp = test.Statistic * 100;
            tmp = Math.Round(tmp, 2);
            Result = tmp.ToString() + "%";

            TestEndEvent?.Invoke(test.Statistic);
        }
    }
}
