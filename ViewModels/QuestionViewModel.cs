using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Models;

namespace TestingSystem.ViewModels
{
    public class QuestionViewModel
    {
        private Question question;

        public string QuestionText { get => question.QuestionText; }

        private AnswerViewModel[] _answers;
        public AnswerViewModel[] Answers { get => _answers; }

        public QuestionViewModel(Question question)
        {
            this.question = question;
            _answers = new AnswerViewModel[question.Answers.Length];
            for (int i = 0; i < question.Answers.Length; i++)
            {
                _answers[i] = new AnswerViewModel(question.Answers[i]);
            }
        }
    }


    public class AnswerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Text { get; private set; }

        private bool isChecked;
        public bool IsChecked
        {
            get => isChecked;
            set
            {
                isChecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsChecked)));
                Trace.WriteLine("IsChecked " + isChecked);
            }
        }



        public AnswerViewModel(string answer)
        {
            Text = answer;
            IsChecked = false;
        }

        
    }
}
