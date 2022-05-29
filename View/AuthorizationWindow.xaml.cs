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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        Auth.AuthModel authModel;
        public AuthorizationWindow()
        {
            InitializeComponent();
            authModel = new Auth.AuthModel();
            authModel.AuthorizedEvent += OnAuth;
        }

        private void Authorize(object sender, RoutedEventArgs e)
        {
            var login = LoginInput.Text;
            var password = PasswordInput.Password;

            Dispatcher.BeginInvoke(authModel.TryAuth, login, password);
            
        }

        private void OnAuth(bool status)
        {
            if (!status)
                MessageBox.Show("Autorization failed");
            else
            {
                var profile = new Profile(authModel.AuthUser);
                profile.Show();
                Close();
            }
        }

        private void OpenSettingsWindow(object sender, RoutedEventArgs e)
        {
            var settings = new SettingsView();
            Visibility = Visibility.Collapsed;
            settings.ShowDialog();
            Visibility = Visibility.Visible;

        }
    }
}
