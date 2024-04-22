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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        MainWindow mainWindow = new MainWindow();
        TESTEntities obj;
        MainWindow.UserInfo userInfo = new MainWindow.UserInfo();

        public Login() // принимаем ссылку на форму
        {
            InitializeComponent();
            obj = new TESTEntities();
            
        }

        private void regin_Click(object sender, RoutedEventArgs e)
        {



        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {


            if (textBox_login.Text.Length > 0) // проверяем введён ли логин     
            {
                if (password.Password.Length > 0) // проверяем введён ли пароль
                {// ищем в базе данных пользователя с такими данными         
                    //DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[Users] WHERE [login] = '" + textBox_login.Text + "'AND [password] = '" + password.Password + "'");
                    if (obj.Users.Any(u => u.login == textBox_login.Text && u.password == password.Password))
                     {
                        MessageBox.Show("Пользователь авторизовался"); //говорим, что авторизовался

                        userInfo.Name = textBox_login.Text;
                        mainWindow.tBlock.Text = userInfo.Name;
                        mainWindow.stack.Children.Contains(mainWindow.tBlock);

                        this.Close();
                        mainWindow.Show();
                    } // если такая запись существует
                    else
                    {
                        MessageBox.Show("Пользователь не найден\n" +
                                        "Зарегестрируйтесь в приложении"); //выводим ошибку

                    }
                }
                else MessageBox.Show("Введите пароль"); //выводим ошибку
            }
            else MessageBox.Show("Введите логин"); //выводим ошибку
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Regin regin = new Regin();
            this.Close();
            regin.Show();
        }
    }
}

