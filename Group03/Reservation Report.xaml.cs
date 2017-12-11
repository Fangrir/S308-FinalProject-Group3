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
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace Group03
{
    /// <summary>
    /// Interaction logic for Reservation_Report.xaml
    /// </summary>
    public partial class Reservation_Report : Window
    {
        List<Reservation> reservationList;

        public Reservation_Report()
        {
            InitializeComponent();

            // create a room lists
            reservationList = new List<Reservation>();

            // point data grid source to list
            dtgReservation.ItemsSource = reservationList;

            // load file from json and insert into data grid
            LoadFromJson();
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            
            //Date Time variable
            DateTime dtCheckinDate = new DateTime();
            DateTime dtCheckOutDate = new DateTime();

            string strLastName;

            strLastName = txtLastName.Text.Trim();

            //Remove the item source first
            dtgReservation.ItemsSource = "";

            //if the date range is not available but the lastname input is not blank
            if(txtLastName.Text.Trim() == "" && dtpStartDate.SelectedDate.Value != null && dtpEndDate.SelectedDate.Value != null)
            {
                dtCheckinDate = dtpStartDate.SelectedDate.Value.Date;
                dtCheckOutDate = dtpEndDate.SelectedDate.Value.Date;

                var ReservationSearch = reservationList.Where(r =>
                r.CheckinDate >= dtCheckinDate &&
                r.CheckoutDate <= dtCheckOutDate);

                foreach (Reservation r in ReservationSearch)    
                {
                    dtgReservation.ItemsSource = ReservationSearch.ToList();
                }
            }

            //if the lastname text is blank
            else if(dtpStartDate.SelectedDate.ToString() == "" && dtpEndDate.SelectedDate.ToString() == ""
                && txtLastName.Text.Trim() != "")
            {
                var ReservationSearch = reservationList.Where(r =>
                r.LastName.StartsWith(strLastName));

                foreach (Reservation r in ReservationSearch)
                {
                    dtgReservation.ItemsSource = ReservationSearch.ToList();
                }
                if (ReservationSearch.ToString() == "")
                {
                    MessageBox.Show("No record found. Pleaase check your input");
                }
            }

            //if none of the input is blank
            else if(dtpStartDate.SelectedDate.ToString() != "" && dtpEndDate.SelectedDate.ToString() != "" && txtLastName.Text != "")
            {
                dtCheckinDate = dtpStartDate.SelectedDate.Value.Date;
                dtCheckOutDate = dtpEndDate.SelectedDate.Value.Date;

                var ReservationSearch = reservationList.Where(r =>
                r.CheckinDate >= dtCheckinDate &&
                r.CheckoutDate <= dtCheckOutDate &&
                r.LastName.StartsWith(strLastName));

                foreach (Reservation r in ReservationSearch)
                {
                    dtgReservation.ItemsSource = ReservationSearch.ToList();
                }

                if( ReservationSearch.ToString() == "")
                {
                    MessageBox.Show("No record found. Pleaase check your input");
                }
            }
            else
            {
                MessageBox.Show("Please check your input again");
            }

        }

        //When the main menu button is clicked
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }

        //Load the file to the data grid
        private void LoadFromJson()
        {
            string strFilePath = @"..\..\Data\Reservations.json";

            // read and try to import JSON data into roomList
            try
            {
                StreamReader reader = new StreamReader(strFilePath);
                string jsonData = reader.ReadToEnd();
                reader.Close();

                reservationList = JsonConvert.DeserializeObject<List<Reservation>>(jsonData);

                dtgReservation.ItemsSource = reservationList;
            }

            // if an error occurs print out error message
            catch (Exception ex)
            {
                MessageBox.Show("Import failed: " + ex.Message);
            }

            // refresh the data grid
            dtgReservation.Items.Refresh();
        }

    }
}
