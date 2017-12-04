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

        private void dtpCheckIn_SelectedDateChange(object sender, SelectionChangedEventArgs e)
        {
            if (dtpCheckIn.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Please input a valid date");
                return;
            }
        }

        private void dtpCheckOut_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtpCheckOut.SelectedDate < dtpCheckIn.SelectedDate && dtpCheckOut.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Please input a valid date");
                return;
            }
        }

        private void btnQuote_Click(object sender, RoutedEventArgs e)
        {
            string CheckinDate;
            string CheckOutDate;

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

        }

    }
}
