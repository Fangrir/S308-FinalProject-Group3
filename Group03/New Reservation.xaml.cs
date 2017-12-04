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

        private void btnQuote_Click(object sender, RoutedEventArgs e)
        {
            if(txtNoOfRooms.Text.Trim() == "")
            {
                MessageBox.Show("Please input the room number");
            }

        }
    }
}
