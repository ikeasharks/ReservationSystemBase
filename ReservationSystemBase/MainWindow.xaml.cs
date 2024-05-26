using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReservationSystemBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public DataTable Select(string selectSQL)// функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");// создаём таблицу в приложении

            SqlConnection sqlConnection = new SqlConnection("server = DESKTOP-JJNLF5N\\SQLEXPRESS; Trusted_Connection = Yes; DataBase = TEST;");// подключаемся к базе данных
            sqlConnection.Open();// открываем базу данных

            SqlCommand sqlCommand = sqlConnection.CreateCommand();// создаём команду
            sqlCommand.CommandText = selectSQL;// присваиваем команде текст

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);// создаём обработчик
            sqlDataAdapter.Fill(dataTable);// возращаем таблицу с результатом

            return dataTable;
        }


        private void profileButt_Click(object sender, RoutedEventArgs e)
        {
            Profiles prof = new Profiles();
            frame.NavigationService.Navigate(prof);

        }

        private void searchButt_Click(object sender, RoutedEventArgs e)
        {
            SearchForFlights search = new SearchForFlights();
            frame.NavigationService.Navigate(search);
        }

        private void bookButt_Click(object sender, RoutedEventArgs e)
        {
            Booking book = new Booking();
            frame.NavigationService.Navigate(book);
        }

        private void manageButt_Click(object sender, RoutedEventArgs e)
        {
            ManageBooking manage = new ManageBooking();
            frame.NavigationService.Navigate(manage);
        }

        public class UserInfo
        {
            public UserInfo()
            {
                
            }

            public string Name { get; set; }
        }

        
    }
}

