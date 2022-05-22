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

namespace TestingSystem
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
            DataContext = viewModel.AuthUser;
        }

        private void StartTest(object sender, RoutedEventArgs e)
        {
            Testing.Test test;
            if (viewModel.StartText(IdInput.Text, out test))
            {
                Visibility = Visibility.Collapsed;
                var main = new MainWindow(test);
                main.ShowDialog();
                Visibility = Visibility.Visible;
            }
        }
    }
}
