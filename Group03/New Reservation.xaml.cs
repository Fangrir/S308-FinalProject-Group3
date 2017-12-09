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
            if (dtpCheckIn.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Please input a valid date");
                return;
            }
        }

        //When the users select a checkout date
        private void dtpCheckOut_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtpCheckOut.SelectedDate < dtpCheckIn.SelectedDate || dtpCheckOut.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Please input a valid date");
                return;
            }
        }

        //When the users click the Create Quote Button
        private void btnQuote_Click(object sender, RoutedEventArgs e)
        {
            //String Variable
            DateTime CheckinDate = new DateTime();
            DateTime CheckOutDate = new DateTime();

            //int variable
            int NoOfRooms;
            int NoOfNights;

            //double variable
            double RatePerNight = 0;

            //parse variable
            int a;

            if(txtNoOfRooms.Text.Trim() == "")
            {
                MessageBox.Show("Room number cannot be blank");
            }
            else if (dtpCheckIn.SelectedDate.ToString() == "")
            {
                MessageBox.Show("Please select a check in date!");
                return;
            }
            else if (dtpCheckOut.SelectedDate.ToString() == "")
            {
                MessageBox.Show("Please select a check out date!");
                return;
            }

            else if (dtpCheckIn.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Please input a valid date");
                return;
            }
            else if (dtpCheckOut.SelectedDate < dtpCheckIn.SelectedDate && 
                dtpCheckOut.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Please input a valid date");
                return;
            }
            else if (txtNoOfRooms.Text.Trim() == "")
            {
                MessageBox.Show("Please input the number of room");
                return;
            }
            else if(!Int32.TryParse(txtNoOfRooms.Text.Trim(), out a ))
            {
                MessageBox.Show("Please input a valid number of rooms");
                return;
            }
            else if (cbxRoomType.SelectedIndex == -1)
            {
                //if a customer type is not selected
                MessageBox.Show("Please choose a room type");
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

            //Output
            txtQuote.Text = 
                "Number of Night(s): " + NoOfNights + Environment.NewLine +
                "Rate per Night: " + RatePerNight + Environment.NewLine +
                "No of Rooms: " + NoOfRooms + Environment.NewLine +
                "Subtotal: " + (NoOfNights * RatePerNight * NoOfRooms) + Environment.NewLine + Environment.NewLine +
                "Tax (7%): " + ((NoOfNights * RatePerNight * NoOfRooms) * 0.07) + Environment.NewLine +
                "Convenience Fee ($10/night): " + (10 * NoOfNights) + Environment.NewLine +
                "Total: " + ((NoOfNights * RatePerNight * NoOfRooms) + ((NoOfNights * RatePerNight * NoOfRooms) * 0.07) + (10 * NoOfNights));
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
            New_Reservation_2 CompleteReservation = new New_Reservation_2();
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
                MessageBox.Show("Import failed: " + ex.Message);
            }
        }
    }
}
