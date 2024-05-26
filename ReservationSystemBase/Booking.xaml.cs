using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
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
using System.Windows.Threading;

namespace ReservationSystemBase
{
    /// <summary>
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class Booking : Page
    {
        SqlConnection sqlConnection = new SqlConnection("server = DESKTOP-JJNLF5N\\SQLEXPRESS; Trusted_Connection = Yes; DataBase = TEST;");
        MainWindow main = new MainWindow();
        MainWindow.UserInfo userInfo = new MainWindow.UserInfo();
        TESTEntities db = new TESTEntities();
        public Booking()
        {
            InitializeComponent();

            startClock();


        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void startClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickEvent;
            timer.Start();

        }
        private void tickEvent(object sender, EventArgs e)
        {
            timeBlock.Content = DateTime.Now.ToString("T");
        }
        private void searchFligh_click(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            string expression = $"SELECT * FROM Flights WHERE FlightId = {idOfFlight.Text}";
            SqlCommand sqlCommand = new SqlCommand(expression, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                object id;
                object numbers;
                object status;
                while (reader.Read()) // построчно считываем данные
                {
                    id = reader.GetValue(0);
                    numbers = reader.GetValue(4);
                    status = reader.GetValue(6);
                    if (id.ToString() == idOfFlight.Text)
                    {
                        MessageBox.Show($"Билет с идентификатором {id}\nКоличество мест: {numbers} \nСтатус: {status}");

                    }
                }

            }
            sqlConnection.Close();

        }

        private void bookFlight_click(object sender, RoutedEventArgs e)
        {


            sqlConnection.Open();
            
            string query = $"INSERT INTO Booking (FlightNumber, NumOfTickets) VALUES ({idOfFlight.Text}, {numbersOfFlight.Text})";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();


            sqlConnection.Close();
        }


        private void clearForm_click(object sender, RoutedEventArgs e)
        {
            idOfFlight.Text = null;
            numbersOfFlight.Text = null;
        }

        
    }
}
