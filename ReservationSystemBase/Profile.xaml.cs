using System;
using System.Collections.Generic;
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

namespace ReservationSystemBase
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        MainWindow mainWindow = new MainWindow();
        TESTEntities db = new TESTEntities();
        public Profile()
        {
            

            PersonalInfo _pers = new PersonalInfo
            {
                FName = QueryTaker("SELECT FName FROM Profile"),
                LName = QueryTaker("SELECT LName FROM Profile"),
                Email = QueryTaker("SELECT Email FROM Profile"),
                Passport_Num = QueryTaker("SELECT Passport_Num FROM Profile"),
                Address = QueryTaker("SELECT Address FROM Profile"),
                creditCard = QueryTaker("SELECT CreditCard FROM Profile")
            };
            InitializeComponent();
            myStack.DataContext = _pers;
            //myStack.DataContext = db.Profiles.Select(u => u.IdOfUsers == db.Users.Select(o => o.id));


        }
        public static string QueryTaker(string query)
        {
            SqlConnection sqlConnection = new SqlConnection("server = DESKTOP-JJNLF5N\\SQLEXPRESS; Trusted_Connection = Yes; DataBase = TEST;");// подключаемся к базе данных
            sqlConnection.Open();// открываем базу данных
            string strQuery = query;
            SqlCommand sqlCommand = new SqlCommand(strQuery, sqlConnection);
            string testString = sqlCommand.ExecuteScalar().ToString();
            sqlConnection.Close();
            return testString;
        }

        private void updButt_click(object sender, RoutedEventArgs e)
        {

            mainWindow.Select($"INSERT INTO [dbo].[Profile] (Email, Passport_Num, Address, FName, LName, CreditCard) VALUES ('{EmailBox.Text}', '{NumberBox.Text}', '{AddresBox.Text}', '{FirstNBox.Text}', '{LastNBox.Text}', '{CreditBox.Text}')");
        }

        private void resButt_click(object sender, RoutedEventArgs e)
        {
            EmailBox.Text = "";
            NumberBox.Text = "";
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

