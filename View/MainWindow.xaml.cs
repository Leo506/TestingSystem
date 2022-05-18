using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TestViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();

            viewModel = new TestViewModel();

            DataContext = viewModel.Question;

            PrevButton.Visibility = Visibility.Collapsed;
        }


        private void NextQuestion(object sender, RoutedEventArgs e)
        {
            if (viewModel.NextQuestion())
            {
                DataContext = viewModel.Question;

                PrevButton.Visibility = Visibility.Visible;
            }
            else
            {
                var summary = new SummaryWindow(viewModel.GetTest());
                summary.ShowDialog();
            }
        }


        private void SelectAnswer(object sender, RoutedEventArgs e)
        {
            RadioButton? btn = sender as RadioButton;

            if (btn != null)
            {
                viewModel.SelectAnswer(btn.Content.ToString());
            }
        }

        private void PreviousQuestion(object sender, RoutedEventArgs e)
        {
            if (viewModel.HasPreviousQuestion)
            {
                viewModel.PreviousQuestion();
                DataContext = viewModel.Question;

                if (!viewModel.HasPreviousQuestion)
                    PrevButton.Visibility = Visibility.Collapsed;
            }
        }
    }
}
