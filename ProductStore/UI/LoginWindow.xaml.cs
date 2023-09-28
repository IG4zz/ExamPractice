using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProductStore.UI;
using ProductStore.DBEntities;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProductStore.UI
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            User currentUser = ProductStoreEntities.GetContext().Users.FirstOrDefault(p => p.Login.Equals(txtBoxLogin.Text) && p.Password.Equals(pswrdBoxPassword.Password));
            if(currentUser !=null)
            {
                if(currentUser.IdRole == 1)
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    this.Close();
                }

                if (currentUser.IdRole == 2)
                {
                    MessageBox.Show("Функционал временно недоступен");
                }
            }
            else
            {
                MessageBox.Show("Введен неверный Логин или Пароль");

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            EntryWindow entryWindow = new EntryWindow();
            entryWindow.Show();
            this.Close();
        }
    }
}
