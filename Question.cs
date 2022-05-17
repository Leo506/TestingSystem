﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem.Testing
{
    public enum QuestionStates
    {
        UNDEFINED,
        CORRECT_ANSWER,
        UNCORRECT_ANSWER
    }

    public class Question
    {
        private string[] answersVariant;
        private int correctIndex;

        private QuestionStates state;

        public Question()
        {
            state = QuestionStates.UNDEFINED;
            correctIndex = 0;
            answersVariant = new string[0];
        }

        public Question(string[] answers, int index)
        {
            state = QuestionStates.UNDEFINED;
            correctIndex = index;
            answersVariant = answers;
        }

        public QuestionStates GetState() => state;

        public void SetState(QuestionStates state)
        {
            this.state = state;
        }

        public string[] GetAnswerVariants() => answersVariant;

        public int GetCorrectAnswer() => correctIndex;
    }
}
