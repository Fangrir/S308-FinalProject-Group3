//nadiwira,kevan, & ftjandra
//Background Image Source: http://www.hotelroomsearch.net/im/hotels/asia/th/villa-ocean-view-10.jpg
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Group03
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

        //When the Quit Program is clicked
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //When the Create Reservation is Click
        private void btnNewReservation_Click(object sender, RoutedEventArgs e)
        {
            New_Reservation CreateQuote = new New_Reservation();
            CreateQuote.Show();
            this.Close();
        }

        //When the View Reservation Report Button is Clicked
        private void btnReservationRpt_Click(object sender, RoutedEventArgs e)
        {
            Reservation_Report Report = new Reservation_Report();
            Report.Show();
            this.Close();
        }

        //When the manage rooms is clicked
        private void btnRoomMgmt_Click(object sender, RoutedEventArgs e)
        {
            Room_Mgmt ManageRoom = new Room_Mgmt();
            ManageRoom.Show();
            this.Close();
        }
    }
}
