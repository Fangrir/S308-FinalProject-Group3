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

namespace Group03
{
    /// <summary>
    /// Interaction logic for New_Reservation.xaml
    /// </summary>
    public partial class New_Reservation : Window
    {
        public New_Reservation()
        {
            InitializeComponent();

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
            string Room_Type;

            //int variable
            int No_of_Room;

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
            else
            {
                //if a customer type is selected
                ComboBoxItem cbiSelectedItem = (ComboBoxItem)cbxRoomType.SelectedItem;
                Room_Type = cbiSelectedItem.Content.ToString().ToUpper().Trim();
            }

            //Store the date
            CheckinDate = dtpCheckIn.SelectedDate.Value;
            CheckOutDate = dtpCheckOut.SelectedDate.Value;

            //Output
            txtQuote.Text = "Number of Night: " + (CheckOutDate-CheckinDate).Days + Environment.NewLine
                + "Rate per Night: " + Environment.NewLine + "No of Rooms: " + txtNoOfRooms.Text.Trim() +
                Environment.NewLine;


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
    }
}
