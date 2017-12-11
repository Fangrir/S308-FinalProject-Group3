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

namespace Group03
{
    /// <summary>
    /// Interaction logic for New_Reservation.xaml
    /// </summary>
    public partial class New_Reservation : Window
    {
        List<Room> roomList;
        Quote myquote { get; set; }

        public New_Reservation()
        {
            InitializeComponent();

            // create a room lists
            roomList = new List<Room>();

            // load rooms data from json and insert into list
            LoadFromJson();
        }
        
        //When the users select a checkin date
        private void dtpCheckIn_SelectedDateChange(object sender, SelectionChangedEventArgs e)
        {
            if (dtpCheckIn.SelectedDate < DateTime.Today || dtpCheckIn.SelectedDate > dtpCheckOut.SelectedDate)
            {
                MessageBox.Show("Please input a valid check in date.");
                dtpCheckIn.SelectedDate = null;
                return;
            }
        }

        //When the users select a checkout date
        private void dtpCheckOut_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtpCheckOut.SelectedDate < dtpCheckIn.SelectedDate || dtpCheckOut.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Please input a valid check out date.");
                dtpCheckOut.SelectedDate = null;
                return;
            }
        }

        //When the users click the Create Quote Button
        private void btnQuote_Click(object sender, RoutedEventArgs e)
        {
            DateTime CheckinDate = new DateTime();
            DateTime CheckOutDate = new DateTime();

            //int variable
            int NoOfRooms;
            int NoOfNights;

            int a;

            //double variable
            double RatePerNight = 0;

            // variables to check empty fields
            bool bolEmpty = false; // boolean that is set to true whenever there is an unselected/empty field
            string strEmpty = ""; // string used to add fields that will be displayed whenever they are empty

            // check for empty fields
            if (cbxRoomType.SelectedIndex == -1)
            {
                bolEmpty = true;
                strEmpty = "room type";
            }

            if (txtNoOfRooms.Text.Trim() == "")
            {
                if (bolEmpty == true)
                    strEmpty = strEmpty + ", no of rooms";

                else
                {
                    bolEmpty = true;
                    strEmpty = "no of rooms";
                }
            }

            if (dtpCheckIn.SelectedDate.ToString() == "")
            {
                if (bolEmpty == true)
                    strEmpty = strEmpty + ", check in date";
                
                else
                {
                    bolEmpty = true;
                    strEmpty = "check in date";
                }
            }

            if (dtpCheckOut.SelectedDate.ToString() == "")
            {
                if (bolEmpty == true)
                    strEmpty = strEmpty + ", check out date";

                else
                {
                    bolEmpty = true;
                    strEmpty = "check out date";
                }
            }

            // if bolEmpty is true, display message showing all empty fields that needs to be sorted out
            if (bolEmpty == true)
            {
                MessageBox.Show("The field(s) " + strEmpty + " cannot be empty.");
                return;
            }


            // check if no of rooms is an integer
            if (!Int32.TryParse(txtNoOfRooms.Text.Trim(), out a))
            {
                MessageBox.Show("Number of rooms must be a whole number.");
                return;
            }

            //Store no of rooms
            NoOfRooms = Convert.ToInt32(txtNoOfRooms.Text.Trim());

            //Store the date and assign difference to NoOfNights
            CheckinDate = dtpCheckIn.SelectedDate.Value;
            CheckOutDate = dtpCheckOut.SelectedDate.Value;
            NoOfNights = (int)(CheckOutDate - CheckinDate).TotalDays;

            //Get rate from matching room type from room list
            foreach (Room r in roomList)
            {
                if (r.Type == cbxRoomType.Text)
                {
                    RatePerNight = r.Price;
                }
            }
            
            //Insert data to the constructor
             myquote = new Quote(cbxRoomType.Text, Convert.ToInt32(txtNoOfRooms.Text.Trim()), 
                dtpCheckIn.SelectedDate.ToString(), dtpCheckOut.SelectedDate.ToString(),
                ((NoOfNights * RatePerNight * NoOfRooms) + ((NoOfNights * RatePerNight * NoOfRooms) * 0.07) + (10 * NoOfNights)));

            //Calculate quote variables and output them
            lblNoOfNightsOut.Content = NoOfNights;
            lblRatePerNightOut.Content = "$" + String.Format("{0:n}", RatePerNight);
            lblSubtotalOut.Content = "$" + String.Format("{0:n}", (NoOfNights * RatePerNight * NoOfRooms));
            lblTaxOut.Content = "$" + String.Format("{0:n}", ((NoOfNights * RatePerNight * NoOfRooms) * 0.07));
            lblConvFeeOut.Content = "$" + String.Format("{0:n}", (10 * NoOfNights * NoOfRooms));
            lblTotalOut.Content = "$" + String.Format("{0:n}", ((NoOfNights * RatePerNight * NoOfRooms) + ((NoOfNights * RatePerNight * NoOfRooms) * 0.07) + (10 * NoOfNights)));
        }

        //When the Main Menu is clicked
        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }

        //When the Create Reservation is clicked
        private void btnReservation_Click(object sender, RoutedEventArgs e)
        {
            New_Reservation_2 CompleteReservation = new New_Reservation_2(myquote);
            CompleteReservation.Show();
            this.Close();
        }

        private void LoadFromJson()
        {
            string strFilePath = @"..\..\Data\Rooms.json";

            // read and try to import JSON data into roomList
            try
            {
                StreamReader reader = new StreamReader(strFilePath);
                string jsonData = reader.ReadToEnd();
                reader.Close();

                roomList = JsonConvert.DeserializeObject<List<Room>>(jsonData);
            }

            // if an error occurs print out error message
            catch (Exception ex)
            {
                MessageBox.Show("Failed to import Room data: " + ex.Message);
            }
        }

    }
}
