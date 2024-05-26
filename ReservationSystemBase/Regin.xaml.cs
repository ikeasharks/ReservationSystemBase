using System;
using System.Collections.Generic;
using System.Data;
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

namespace ReservationSystemBase
{
    /// <summary>
    /// Interaction logic for Regin.xaml
    /// </summary>
    public partial class Regin : Window
    {
        TESTEntities obj;
        Login login = new Login();

        public Regin()
        {
            InitializeComponent();
            obj = new TESTEntities();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {

        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_login.Text.Length > 0)
            {
                if (password.Password.Length > 0)
                {
                    if (password_Copy.Password.Length > 0)
                    {

                    }
                    else MessageBox.Show("Повторите пароль");
                }
                else MessageBox.Show("Укажите пароль");
            }
            else MessageBox.Show("Введите логин");

            string[] dataLogin = textBox_login.Text.Split('@');
            if (dataLogin.Length == 2)
            {
                string[] data2Login = dataLogin[1].Split('.');
                if (data2Login.Length == 2)
                {

                }
                else MessageBox.Show("Укажите логин в форме x@x.x");
            }
            else MessageBox.Show("Укажите логин в форме x@x.x");

            if (password.Password.Length >= 6)
            {
                bool en = true;
                bool symbol = false;
                bool number = false;

                for (int i = 0; i < password.Password.Length; i++)
                {
                    if (password.Password[i] >= 'А' && password.Password[i] <= 'Я') en = false;
                    if (password.Password[i] >= '0' && password.Password[i] <= '9') number = true;
                    if (password.Password[i] == '_' || password.Password[i] == '-' || password.Password[i] == '!') symbol = true;
                }
                if (!en)
                {
                    MessageBox.Show("Доступна только английская раскладка");
                }
                else if (!symbol)
                {
                    MessageBox.Show("Добавьте один из следующих символов: _ - !");
                }
                else if (!number)
                {
                    MessageBox.Show("Добавьте хотя бы одну цифру");
                }

                if (password.Password == password_Copy.Password) // проверка на совпадение паролей
                {
                    if (obj.Users.Any(u => u.login == textBox_login.Text && u.password == password.Password)) // если такая запись существует
                    {
                        MessageBox.Show("Пользователь уже зарегестрирован"); //говорим, что пользователь уже зарегестрирован

                    }
                    else
                    {
                        User user = new User
                        {
                            login = textBox_login.Text,
                            password = password_Copy.Password
                        };
                        obj.Users.Add(user);
                        obj.SaveChanges();

                        MessageBox.Show("С успешной регистрацией");

                        this.Close();
                        login.Show();
                    }
                }
                else MessageBox.Show("Пароли не совпадают");
            }
            else MessageBox.Show("Пароль должен быть больше 6 символов");
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            this.Close();
            login.Show();
        }
    }
}
