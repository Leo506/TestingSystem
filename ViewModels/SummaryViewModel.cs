using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem
{
    public class SummaryViewModel
    {
        public int CorrectAnswersCount { get; private set; }
        public int AllAnswersCount { get; private set; }

        public double Result { get; private set; }

        public SummaryViewModel(Testing.Test test)
        {
            Testing.Question[] questions = new Testing.Question[test.QuestionCount];
            for (int i = 0; i < questions.Length; i++)
                questions[i] = test.GetQuestion(i);

            CorrectAnswersCount = questions.Where(q => q.GetState() == Testing.QuestionStates.CORRECT_ANSWER).Count();
            AllAnswersCount = questions.Length;
            Result = test.Statistic;
        }
    }
}
