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
    /// Interaction logic for Room_Mgmt.xaml
    /// </summary>
    public partial class Room_Mgmt : Window
    {
        List<Room> roomList;
        public Room_Mgmt()
        {
            InitializeComponent();
            roomList = new List<Room>();

            // load file from json and insert into data grid

            // point data grid source to list
            dtgRoomList.ItemsSource = roomList;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Room roomNew = new Room("One King", 30, 179);
            // roomList.Add(roomNew);
            // dtgRoomList.Items.Refresh();

            // declare variables
            int intQuantity;
            double dblPrice;
            bool bolEmpty = false; // boolean that is set to true whenever there is an unselected/empty field
            string strEmpty = ""; // string used to add fields that will be displayed whenever they are empty

            // check for empty fields
            // check if room type is not selected, if true set bolEmpty to true and add field to strEmpty
            if (cbxRoomType.SelectedIndex == -1)
            {
                bolEmpty = true;
                strEmpty = "room type";
            }

            // check if quantity is empty
            if (txtQuantity.Text.Trim() == "")
            {
                if (bolEmpty == true) // if bolEmpty is already true, just add the field to strEmpty
                {
                    strEmpty = strEmpty + ", quantity";
                }

                else // if not, also set bolEmpty to true
                {
                    bolEmpty = true;
                    strEmpty = "quantity";
                }
            }

            // check if price is empty
            if (txtPrice.Text.Trim() == "")
            {
                if (bolEmpty == true) // if bolEmpty is already trye, just add the field to strEmpty
                {
                    strEmpty = strEmpty + ", price";
                }

                else // if not, also set bolEmpty to true
                {
                    bolEmpty = true;
                    strEmpty = "price";
                }
            }

            // if bolEmpty is true, display message showing all empty fields that needs to be sorted out
            if (bolEmpty == true)
            {
                MessageBox.Show("The field(s) " + strEmpty + " cannot be empty.");
                return;
            }

            // check that quantity input is numeric
            if (!Int32.TryParse(txtQuantity.Text.Trim(), out intQuantity))
            {
                MessageBox.Show("Quantity must be a whole number.");
                return;
            }

            // assign quantity input to variable
            intQuantity = Convert.ToInt32(txtQuantity.Text.Trim());

            // check that price input is numeric
            if (!Double.TryParse(txtPrice.Text.Trim(), out dblPrice))
            {
                MessageBox.Show("Price must be a number.");
                return;
            }

            // assign price input to variable
            dblPrice = Convert.ToDouble(txtPrice.Text.Trim());

            // check if price is negative
            if (dblPrice < 0)
            {
                MessageBox.Show("Price cannot be a negative number.");
                return;
            }
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }
    }
}
