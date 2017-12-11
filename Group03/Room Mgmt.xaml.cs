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
    /// Interaction logic for Room_Mgmt.xaml
    /// </summary>
    public partial class Room_Mgmt : Window
    {
        List<Room> roomList;
        public Room_Mgmt()
        {
            InitializeComponent();

            // create a room lists
            roomList = new List<Room>();

            // point data grid source to list
            dtgRoomList.ItemsSource = roomList;

            // load file from json and insert into data grid
            LoadFromJson();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // declare variables
            int intQuantity = 0;
            double dblPrice = 0;

            // check if room type is not selected, if true set bolEmpty to true and add field to strEmpty
            if (cbxRoomType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a room type.");
                return;
            }

            // if quantity and price are both empty, print out message saying no changes were made
            if (txtQuantity.Text == "" && txtPrice.Text == "")
            {
                MessageBox.Show("Quantity and price are empty, no changes were made.");
                return;
            }

            // if quantity is not empty, check that input is valid
            if (txtQuantity.Text != "")
            {
                if (!Int32.TryParse(txtQuantity.Text.Trim(), out intQuantity))
                {
                    MessageBox.Show("Quantity must be a whole number.");
                    return;
                }

                // assign quantity input to variable
                intQuantity = Convert.ToInt32(txtQuantity.Text.Trim());

                if (intQuantity < 0)
                {
                    MessageBox.Show("Quantity cannot be a negative number.");
                    return;
                }
            }

            // if price is not empty, check that input is valid
            if (txtPrice.Text != "")
            {
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

            // search room object from list that matches the selected room type
            foreach (Room r in roomList)
            {
                // modify the data if the object matches the selected room type AND if the fields are not empty
                if (r.Type == cbxRoomType.Text)
                {
                    if (txtQuantity.Text.Trim() != "")
                        r.Quantity = intQuantity;

                    if (txtPrice.Text.Trim() != "")
                        r.Price = dblPrice;
                }
            }

            // refresh the data grid
            dtgRoomList.Items.Refresh();

            // export to JSON
            SaveToJson();
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
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

                dtgRoomList.ItemsSource = roomList;
            }

            // if an error occurs print out error message
            catch (Exception ex)
            {
                MessageBox.Show("Failed to import room data: " + ex.Message);
            }

            // refresh the data grid
            dtgRoomList.Items.Refresh();
        }

        private void SaveToJson()
        {
            string strFilePath = @"..\..\Data\Rooms.json";

            // try to export JSON data from roomList
            try
            {
                StreamWriter writer = new StreamWriter(strFilePath, false);
                string jsonData = JsonConvert.SerializeObject(roomList);
                writer.Write(jsonData);
                writer.Close();
            }

            // if an error occurs print out error message
            catch (Exception ex)
            {
                MessageBox.Show("Export failed: " + ex.Message);
            }

            // notify user that the export is completed and show filepath of new file
            MessageBox.Show("Changes saved!" + Environment.NewLine + "File Created: " + strFilePath);
        }
    }
}
