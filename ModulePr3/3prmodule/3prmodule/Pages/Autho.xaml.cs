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
using _3prmodule.Pages;

namespace _3prmodule.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        public Autho()
        {
            InitializeComponent();
        }

        private void btnEnterGuests_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Client(null));
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string enteredLogin = txtbLogin.Text.Trim();
            string enteredPassword = pswbPassword.Password.Trim();

            if (string.IsNullOrEmpty(enteredLogin) || string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Введите логин и пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var user = Helper.GetContext().Clients
                    .FirstOrDefault(x => x.login.Trim() == enteredLogin && x.password.Trim() == enteredPassword);

                if (user != null)
                {
                    MessageBox.Show($"Добро пожаловать, {user.name}!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    NavigationService.Navigate(new Client(null));
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
