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
        private void CardNumber_TextChange(object sender, TextChangedEventArgs e)
        {
            //Credit card validation variables
            string strCardNum = txtCardNo.Text.Trim().Replace(" ", "");
            string strCardType;

            //Look up the card type value
            if (strCardNum.StartsWith("34") || strCardNum.StartsWith("37"))
            {
                strCardType = "AMEX";
            }
            else if (strCardNum.StartsWith("6011"))
            {
                strCardType = "Discover";
            }
            else if (strCardNum.StartsWith("51") || strCardNum.StartsWith("52") || strCardNum.StartsWith("53") || strCardNum.StartsWith("54") || strCardNum.StartsWith("55"))
            {
                strCardType = "MasterCard";
            }
            else if (strCardNum.StartsWith("4"))
            {
                strCardType = "VISA";
            }
            else
            {
                strCardType = "Unknown Card Type";
            }

            txtCardType.Text = strCardType;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string strCardNum = txtCardNo.Text.Trim().Replace(" ", "");
            string FirstName;
            string LastName;
            string CardNo;
            string PhoneNumber;
            string Email;
            DateTime CheckInDate;
            DateTime CheckOutDate;

            //Validate card number
            long lngOut;
            bool bolValid = false;
            int i;
            int intCheckDigit;
            int intCheckSum = 0;

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

            //validate if card number is empty
            if (!Int64.TryParse(strCardNum, out lngOut))
            {
                MessageBox.Show("Credit card numbers contain only numbers.");
                return;
            }

            //Validate the card number length
            if (strCardNum.Length != 13 && strCardNum.Length != 15 && strCardNum.Length != 16)
            {
                MessageBox.Show("Credit card numbers must contain 13, 15, or 16 digits.");
                return;
            }
            //Validate the card number
            strCardNum = ReverseString(strCardNum);

            for (i = 0; i < strCardNum.Length; i++)
            {
                intCheckDigit = Convert.ToInt32(strCardNum.Substring(i, 1));

                if ((i + 1) % 2 == 0)
                {
                    intCheckDigit *= 2;

                    if (intCheckDigit > 9)
                    {
                        intCheckDigit -= 9;
                    }
                }

                intCheckSum += intCheckDigit;
            }

            if (intCheckSum % 10 == 0)
            {
                bolValid = true;
            }

            //if the credit card not valid
            if (!bolValid)
            {
                MessageBox.Show("Card is not valid");
                return;
            }

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
            CheckOutDate = CheckIn.Date;

            CheckOut = Convert.ToDateTime(lblCheckOutOut.Content);
            CheckInDate = CheckOut.Date;


            //Add the reservation to the reservation list
            Reservation newReservation = new Reservation(CheckInDate, CheckOutDate,
                FirstName, LastName, PhoneNumber, Email, lblRoomTypeOut.Content.ToString(), CurrentQuote.NoOfRoom,
                lblTotalPriceOut.Content.ToString());

            reservationlist.Add(newReservation);

            //Save to json file
            SaveToJson();

            //Return to main Menu
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
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

        //reverse string method
        private static string ReverseString(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }


    }
}
