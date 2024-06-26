﻿using System;
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
    /// Interaction logic for SearchForFlights.xaml
    /// </summary>
    public partial class SearchForFlights : Page
    {
        SqlConnection sqlConnection = new SqlConnection("server = DESKTOP-JJNLF5N\\SQLEXPRESS; Trusted_Connection = Yes; DataBase = TEST;");



        public SearchForFlights()
        {
            InitializeComponent();

            string expression = "SELECT * FROM Flights";

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(expression, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read()) // построчно считываем данные
                {
                    object From = reader.GetValue(1);
                    object To = reader.GetValue(2);
                    comboBox1.Items.Add(From);
                    comboBox2.Items.Add(To);
                }

            }
            sqlConnection.Close();

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

            sqlConnection.Open();
            string dTable = $"SELECT FlightId, FromPlace, ToPlace, LaunchTime, NumberOfSeats, Price, Status FROM Flights WHERE FromPlace IN ('{comboBox1.Text}') AND ToPlace IN ('{comboBox2.Text}')";
            SqlCommand comm = new SqlCommand(dTable, sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            DataTable dt = new DataTable("Flights");
            sda.Fill(dt);

            dataGrid.ItemsSource = dt.DefaultView;
            dataGrid.Columns[0].Header = "Идентификатор";
            dataGrid.Columns[1].Header = "Откуда";
            dataGrid.Columns[2].Header = "Куда";
            dataGrid.Columns[3].Header = "Время отправления";
            dataGrid.Columns[4].Header = "Кол-во мест";
            dataGrid.Columns[5].Header = "Цена";
            dataGrid.Columns[6].Header = "Статус";
            sqlConnection.Close();

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
        }
    }
}

