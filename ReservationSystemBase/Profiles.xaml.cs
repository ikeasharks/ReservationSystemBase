using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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
using System.Diagnostics;

namespace ReservationSystemBase
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profiles : Page
    {
        TESTEntities obj = new TESTEntities();
        //MainWindow mainWindow = new MainWindow();
        MainWindow.UserInfo userInfo = new MainWindow.UserInfo();
        
        public Profiles()
        {

            InitializeComponent();
            

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
 
            

        }

        public static string QueryTaker(string query)
        {
            SqlConnection sqlConnection = new SqlConnection("server = DESKTOP-JJNLF5N\\SQLEXPRESS; Trusted_Connection = Yes; DataBase = TEST;");// подключаемся к базе данных
            sqlConnection.Open();// открываем базу данных
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            string testString = sqlCommand.ExecuteScalar().ToString();
            sqlConnection.Close();
            return testString;
        }

        private void updButt_click(object sender, RoutedEventArgs e)
        {
            Profile profileInfo = new Profile
            {
                FName = FirstNBox.Text,
                LName = LastNBox.Text,
                Email = EmailBox.Text,
                Passport_Num = PassNum.Text,
                Address = AddresBox.Text,
                CreditCard = CreditBox.Text,
            };
            obj.Profiles.Add(profileInfo);
            obj.SaveChanges();


            //mainWindow.Select($"INSERT INTO [dbo].[Profile] (Email, Passport_Num, Address, FName, LName, CreditCard) VALUES ('{EmailBox.Text}', '{NumberBox.Text}', '{AddresBox.Text}', '{FirstNBox.Text}', '{LastNBox.Text}', '{CreditBox.Text}')");
        }

        private void resButt_click(object sender, RoutedEventArgs e)
        {
            EmailBox.Text = "";
            PassNum.Text = "";
            AddresBox.Text = "";
            FirstNBox.Text = "";
            LastNBox.Text = "";
            CreditBox.Text = "";
        }
    }

    class PersonalInfo
    {
        public PersonalInfo()
        {

        }

        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Passport_Num { get; set; }
        public string Address { get; set; }
        public string creditCard { get; set; }


    }
}

