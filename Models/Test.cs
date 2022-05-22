using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Testing
{
    public class Test
    {
        public int QuestionCount { get => questions.Count; }
        public float Statistic { get => (float) questions.Where(q => q.GetState() == QuestionStates.CORRECT_ANSWER).Count() / questions.Count; }
        public bool IsEmpty { get => questions.Count == 0; }

        private List<Question> questions;


        public Test()
        {
            questions = new List<Question>();
        }


        public void AddQuestion(Question question)
        {
            questions.Add(question);
        }

        public Question GetQuestion(int index) => questions[index];

        public void SelectAnswer(int questionIndex, int answerIndex)
        {
            Question question = questions[questionIndex];
            if (question.GetCorrectAnswer() == answerIndex)
                question.SetState(QuestionStates.CORRECT_ANSWER);
            else
                question.SetState(QuestionStates.UNCORRECT_ANSWER);
        }

        public void SelectAnswer(int questionIndex, string answer)
        {
            Question question = questions[questionIndex];
            string correct = question.Answers[question.GetCorrectAnswer()];
            if (correct == answer)
                question.SetState(QuestionStates.CORRECT_ANSWER);
            else
                question.SetState(QuestionStates.UNCORRECT_ANSWER);
        }
    }
}
