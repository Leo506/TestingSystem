using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingSystem.Testing;

namespace TestsForTestingSystem
{
    [TestClass]
    public class TestQuestion
    {
        [TestMethod]
        public void TestCreateQuestion()
        {
            string[] answers = { "var 1", "var2", "var3" };
            int correctAnswerIndex = 0;
            Question question = new Question(answers, correctAnswerIndex);

            Assert.AreEqual(answers, question.GetAnswerVariants());
            Assert.AreEqual(correctAnswerIndex, question.GetCorrectAnswer());
        }

        [TestMethod]
        public void TestChangeQuestionState()
        {
            Question question = new Question();

            Assert.AreEqual(QuestionStates.UNDEFIND, question.GetState());

            question.SetState(QuestionStates.CORRECT_ANSWER);

            Assert.AreEqual(QuestionStates.CORRECT_ANSWER, question.GetState());

            question.SetState(QuestionStates.UNCORRECT_ANSWER);

            Assert.AreEqual(QuestionStates.UNCORRECT_ANSWER, question.GetState());
        }
    }
}