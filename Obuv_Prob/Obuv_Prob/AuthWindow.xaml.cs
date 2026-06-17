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

namespace Obuv_Prob
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();

            PasswordTB.Password = "uzWC67";
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTB.Text) || string.IsNullOrEmpty(PasswordTB.Password))
            {
                MessageBox.Show("Введите логин или пароль", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                
            }

            try
            {
                var user = App.db.Users.FirstOrDefault(u => u.Login == LoginTB.Text && u.Password == PasswordTB.Password);
                if (user != null)
                {
                    MainWindow window = new MainWindow(user);
                    window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла ошибка с подлючением БД!:{ex.Message}", "Фатальная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
