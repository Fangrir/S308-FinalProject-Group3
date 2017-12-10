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
    /// Interaction logic for New_Reservation_2.xaml
    /// </summary>
    public partial class New_Reservation_2 : Window
    {
        //Property
        Quote CurrentQuote { get; set; }

        List<Reservation> reservationlist;
        public New_Reservation_2()
        {
            InitializeComponent();

            //Set all textbox to empty
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtCardNo.Text = "";
            txtCardType.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";

            //create reservation list
            reservationlist = new List<Reservation>();
        }

        public New_Reservation_2(Quote quote)
        {
            InitializeComponent();

            //Set All textbox to empty
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtCardNo.Text = "";
            txtCardType.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";

            CurrentQuote = new Quote();
            CurrentQuote = quote;

            //Show data from previous window
            lblNoOfRoomsOut.Content = CurrentQuote.NoOfRoom.ToString();
            lblRoomTypeOut.Content = CurrentQuote.RoomType.ToString();
            lblCheckInOut.Content = CurrentQuote.CheckInDate.ToString(); ;
            lblCheckOutOut.Content = CurrentQuote.CheckOutDate.ToString();
            lblTotalPriceOut.Content = "$" + String.Format("{0:n}", CurrentQuote.TotalPrice.ToString());

            //create reservation list
            reservationlist = new List<Reservation>();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string FirstName;
            string LastName;
            string CardNo;
            string PhoneNumber;
            string Email;
            string CheckInDate;
            string CheckOutDate;

            DateTime CheckIn = new DateTime();
            DateTime CheckOut = new DateTime();


            //Parse Variable
            double dblNum;

            //Validate if first name is empty or numbers, validation errors show a pop up message
            if (txtFirstName.Text.Trim() == "")
            {
                MessageBox.Show("Please provide customer first name");
                return;
            }
            if (double.TryParse(txtFirstName.Text.Trim(), out dblNum))
            {
                MessageBox.Show("Please provide your first name without containing numbers");
                return;
            }
            //Validate if last name is empty or numbers, validation errors show a pop up message
            if (txtLastName.Text.Trim() == "")
            {
                MessageBox.Show("Please provide customer last name");
                return;
            }
            if (double.TryParse(txtLastName.Text.Trim(), out dblNum))
            {
                MessageBox.Show("Please provide customer last name without containing numbers");
                return;
            }
            //Validate if credit card number is empty, not numbers ,and the format not matched with VISA, MASTERCARD, DISCOVER or AMERICAN EXPRESS. Validation errors show a pop up message
            if (txtCardNo.Text.Trim() == "")
            {
                MessageBox.Show("Please provide a credit card number");
                return;
            }

            if (!double.TryParse(txtCardNo.Text, out dblNum))
            {
                MessageBox.Show("Please provide a credit card number with numbers only");
                return;
            }

            //if (txtCardNo.Text.Trim().Length == 16 && txtCardNo.Text.Trim().StartsWith("4"))
            //{
            //    txtCardType.Text = "VISA";
            //}
            //else if (txtCardNo.Text.Trim().Length == 16 && txtCardNo.Text.Trim().StartsWith("6"))
            //{
            //    txtCardType.Text = "DISCOVER";
            //}
            //else if (txtCardNo.Text.Trim().Length == 15 && txtCardNo.Text.Trim().StartsWith("3") && (txtCardNo.Text.Trim().Substring(1, 1) == "4" || txtCardNo.Text.Trim().Substring(1, 1) == "7"))
            //{
            //    txtCardType.Text = "AMEX";
            //}
            //else if (txtCardNo.Text.Trim().Length == 16 && (txtCardNo.Text.Trim().StartsWith("6") || txtCardNo.Text.Trim().StartsWith("2")))
            //{
            //    txtCardType.Text = "MASTERCARD";
            //}
            //else
            //{
            //    MessageBox.Show("Please provide a valid card type of VISA, DISCOVER, AMEX, OR MASTERCARD");
            //    return;
            //}

            //Validate if phone number is empty, not numbers. Validation errors show a pop up message
            if (txtPhone.Text.Trim() == "")
            {
                MessageBox.Show("Please provide a phone number");
                return;
            }

            if (!double.TryParse(txtPhone.Text, out dblNum))
            {
                MessageBox.Show("Please provide a phone number with numbers only");
                return;
            }

            if (txtPhone.Text.Trim().Length != 10)
            {
                MessageBox.Show("Please provide a phone number that contains 10 digit number");
                return;
            }

            //validate if an optional email conatains @, validation errors show a pop up message

            if (!txtEmail.Text.Trim().Contains("@") && txtEmail.Text != "")
            {
                MessageBox.Show("Please provide an email address that contains @");
                return;
            }

            //Store the inputed value
            FirstName = txtFirstName.Text.Trim();
            LastName = txtLastName.Text.Trim();
            CardNo = txtCardNo.Text.Trim();
            PhoneNumber = txtPhone.Text.Trim();
            Email = txtEmail.Text.Trim();

            CheckIn = Convert.ToDateTime(lblCheckInOut.Content);
            CheckOutDate = CheckIn.ToString("MM/dd/yyyy");

            CheckOut = Convert.ToDateTime(lblCheckOutOut.Content);
            CheckInDate = CheckOut.ToString("MM/dd/yyyy");


            //Add the reservation to the reservation list
            Reservation newReservation = new Reservation(CheckInDate, CheckOutDate,
                FirstName, LastName, PhoneNumber, Email, lblRoomTypeOut.Content.ToString(), Convert.ToInt32(lblNoOfRoomsOut.Content),
                lblTotalPriceOut.Content.ToString());

            reservationlist.Add(newReservation);

            //Save to json file
            SaveToJson();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            New_Reservation CreateNewReservation = new New_Reservation();
            CreateNewReservation.Show();
            this.Close();
        }

        private void SaveToJson()
        {
            string strFilePath = @"..\..\Data\Reservations.json";

            // try to export JSON data from roomList
            try
            {
                StreamWriter writer = new StreamWriter(strFilePath, false);
                string jsonData = JsonConvert.SerializeObject(reservationlist);
                writer.Write(jsonData);
                writer.Close();
            }

            // if an error occurs print out error message
            catch (Exception ex)
            {
                MessageBox.Show("Export failed: " + ex.Message);
            }

            // notify user that the export is completed and show filepath of new file
            MessageBox.Show("Export successful." + Environment.NewLine + "File Created: " + strFilePath);
        }

    }
}
