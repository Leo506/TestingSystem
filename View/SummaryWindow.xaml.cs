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
using System.Windows.Shapes;
using TestingSystem.Models;
using TestingSystem.ViewModels;

namespace TestingSystem.View
{
    /// <summary>
    /// Логика взаимодействия для SummaryWindow.xaml
    /// </summary>
    public partial class SummaryWindow : Window
    {
        SummaryViewModel viewModel;
        public SummaryWindow(Test test)
        {
            InitializeComponent();
            viewModel = new SummaryViewModel(test);

            DataContext = viewModel;
        }
    }
}
