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
    /// Interaction logic for ManageBooking.xaml
    /// </summary>
    public partial class ManageBooking : Page
    {
        SqlConnection sqlConnection = new SqlConnection("server = DESKTOP-JJNLF5N\\SQLEXPRESS; Trusted_Connection = Yes; DataBase = TEST;");

        public ManageBooking()
        {
            InitializeComponent();

           
        }

        private void updateButt_click(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            string dTable = $"SELECT BookingId, FlightNumber, NumOfTickets FROM Booking";
            SqlCommand comm = new SqlCommand(dTable, sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            DataTable dt = new DataTable("Bookings");
            sda.Fill(dt);

            dataGrid.ItemsSource = dt.DefaultView;
            dataGrid.Columns[0].Header = "Идентификатор";
            dataGrid.Columns[1].Header = "Номер билета";
            dataGrid.Columns[2].Header = "Кол-во билетов";

            sqlConnection.Close();
        }

        private void deleteButt_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
