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
using TestingSystem.Models;
using TestingSystem.ViewModels;

namespace TestingSystem.View
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        ProfileViewModel viewModel;
        public Profile(Data.User user)
        {
            InitializeComponent();
            viewModel = new ProfileViewModel(user);
            DataContext = viewModel?.Profile?.User;
        }

        private void StartTest(object sender, RoutedEventArgs e)
        {
            Test test;
            if (viewModel.StartTest(IdInput.Text, out test))
            {
                Visibility = Visibility.Collapsed;
                var main = new MainWindow(test);
                main.ShowDialog();
                Visibility = Visibility.Visible;
                DataContext = viewModel.Profile.User;
            }
        }


        private void ShowStats(object sender, RoutedEventArgs e)
        {
            var stats = new StatisticPage(viewModel.Profile);
            stats.ShowDialog();
        }
    }
}
