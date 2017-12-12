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
            lblCheckInOut.Content = CurrentQuote.CheckInDate.ToString("MM/dd/yyyy");
            lblCheckOutOut.Content = CurrentQuote.CheckOutDate.ToString("MM/dd/yyyy");
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
            int i;
            int intCheckDigit;
            int intCheckSum = 0;

            DateTime CheckIn = new DateTime();
            DateTime CheckOut = new DateTime();

            //Parse Variable
            double dblNum;

            // variables to check empty fields
            bool bolEmpty = false; // boolean that is set to true whenever there is an unselected/empty field
            string strEmpty = ""; // string used to add fields that will be displayed whenever they are empty

            // check for empty fields
            if (txtFirstName.Text.Trim() == "")
            {
                bolEmpty = true;
                strEmpty = "first name";
            }

            if (txtLastName.Text.Trim() == "")
            {
                if (bolEmpty == true)
                    strEmpty = strEmpty + ", last name";

                else
                {
                    bolEmpty = true;
                    strEmpty = "last name";
                }
            }

            if (txtCardNo.Text.Trim() == "")
            {
                if (bolEmpty == true)
                    strEmpty = strEmpty + ", credit card no";

                else
                {
                    bolEmpty = true;
                    strEmpty = "credit card no";
                }
            }

            if (txtPhone.Text.Trim() == "")
            {
                if (bolEmpty == true)
                    strEmpty = strEmpty + ", phone no";

                else
                {
                    bolEmpty = true;
                    strEmpty = strEmpty + "phone no";
                }
            }

            // if bolEmpty is true, display message showing all empty fields that needs to be sorted out
            if (bolEmpty == true)
            {
                MessageBox.Show("The field(s) " + strEmpty + " cannot be empty.");
                return;
            }

            //Check whether first name contains numbers, show error if true
            if (double.TryParse(txtFirstName.Text.Trim(), out dblNum))
            {
                MessageBox.Show("First name cannot contain numbers.");
                return;
            }

            //Check whether last name contains numbers, show error if true
            if (double.TryParse(txtLastName.Text.Trim(), out dblNum))
            {
                MessageBox.Show("Last name cannot contain numbers.");
                return;
            }

            //Check that credit card only contains numbers
            if (!Int64.TryParse(strCardNum, out lngOut))
            {
                MessageBox.Show("Credit card can only contain numeric values.");
                return;
            }

            //Validate the card number length
            if (strCardNum.Length != 13 && strCardNum.Length != 15 && strCardNum.Length != 16)
            {
                MessageBox.Show("Credit card numbers must be either 13, 15, or 16 digits.");
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

            // show error if the checksum is not valid
            if (intCheckSum % 10 != 0)
            {
                MessageBox.Show("Credit card number is not valid.");
                return;
            }

            // validate that phone number only contain numbers
            if (!Int64.TryParse(txtPhone.Text, out lngOut))
            {
                MessageBox.Show("Phone number can only contain numeric values.");
                return;
            }

            if (txtPhone.Text.Trim().Length != 10)
            {
                MessageBox.Show("Phone number must be 10 digits.");
                return;
            }

            // if email is not empty, validate it
            if (txtEmail.Text.Trim() != "")
            {
                if (IsValidEmail(txtEmail.Text.Trim()) == false)
                {
                    MessageBox.Show("Email must be in valid format.");
                    return;
                }
            }

            //Store the inputed value
            FirstName = txtFirstName.Text.Trim();
            LastName = txtLastName.Text.Trim();
            CardNo = txtCardNo.Text.Trim();
            PhoneNumber = txtPhone.Text.Trim();
            Email = txtEmail.Text.Trim();

            CheckIn = Convert.ToDateTime(lblCheckInOut.Content).Date;
            CheckOutDate = CheckIn.Date;

            CheckOut = Convert.ToDateTime(lblCheckOutOut.Content).Date;
            CheckInDate = CheckOut.Date;


            //Add the reservation to the reservation list
            Reservation newReservation = new Reservation(CheckInDate.Date, CheckOutDate.Date,
                FirstName, LastName, PhoneNumber, Email, lblRoomTypeOut.Content.ToString(), CurrentQuote.NoOfRoom,
                lblTotalPriceOut.Content.ToString());

            reservationlist.Add(newReservation);

            //Save to json file
            SaveToJson();

            //Return to main Menu
            New_Reservation mw = new New_Reservation();
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
                //try to append the file
                StreamWriter writer = new StreamWriter(strFilePath, false);
                string jsonData = JsonConvert.SerializeObject(reservationlist);
                

                //create the data
                writer.Write(jsonData);

                //Close the writer
                writer.Close();

                reservationlist = JsonConvert.DeserializeObject<List<Reservation>>(jsonData);

            }

            // if an error occurs print out error message
            catch (Exception ex)
            {
                MessageBox.Show("Reservation failed to save: " + ex.Message);
            }

            // notify that reservation has been created and print out info
            MessageBox.Show("Reservation created!" + Environment.NewLine +
                "Room type: " + lblRoomTypeOut.Content + Environment.NewLine +
                "Check-in date: " + lblCheckOutOut.Content + Environment.NewLine +
                "Number of nights: " + CurrentQuote.NoOfNight + Environment.NewLine +
                "Total cost: " + lblTotalPriceOut.Content);
        }

        private void LoadFromJson()
        {
            string strFilePath = @"..\..\Data\Reservations.json";

            // read and try to import JSON data into roomList
            try
            {
                //Read the file to the end from the starting position
                StreamReader reader = new StreamReader(strFilePath);
                string jsonData = reader.ReadToEnd();

                //Close the reader
                reader.Close();

                reservationlist = JsonConvert.DeserializeObject<List<Reservation>>(jsonData);
            }

            // if an error occurs print out error message
            catch (Exception ex)
            {
                MessageBox.Show("Import failed: " + ex.Message);
            }
        }

            //reverse string method
        private static string ReverseString(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        // function to check whether an email is valid or not
        bool IsValidEmail(string email)
        {
            // try to create a MailAddress instance using user input
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }

            // if an error occurs, return false (email is invalid)
            catch
            {
                return false;
            }
        }
    }
}
