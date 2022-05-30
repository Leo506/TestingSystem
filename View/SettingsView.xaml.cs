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
using TestingSystem.ViewModels;

namespace TestingSystem.View
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class SettingsView : Window
    {
        SettingsViewModel viewModel;
        public SettingsView()
        {
            InitializeComponent();

            viewModel = new SettingsViewModel();

            DataContext = viewModel;

            IpInput.IsEnabled = !viewModel.UseLocalDB;
        }

        private void UseLocalDB(object sender, RoutedEventArgs e)
        {
            IpInput.IsEnabled = false;
        }

        private void UnusedLocalDB(object sender, RoutedEventArgs e)
        {
            IpInput.IsEnabled = true;
        }
    }
}
