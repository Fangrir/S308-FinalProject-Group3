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
        public New_Reservation_2()
        {
            InitializeComponent();

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtCardNo.Text = "";
            txtCardType.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";

        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            double dblNum;

            //Validate if first name is empty or numbers, validation errors show a pop up message
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("Please provide customer first name");
                return;
            }
            if (double.TryParse(txtFirstName.Text, out dblNum))
            {
                MessageBox.Show("Please provide your first name without containing numbers");
                return;
            }
            //Validate if last name is empty or numbers, validation errors show a pop up message
            if (txtLastName.Text == "")
            {
                MessageBox.Show("Please provide customer last name");
                return;
            }
            if (double.TryParse(txtFirstName.Text, out dblNum))
            {
                MessageBox.Show("Please provide customer last name without containing numbers");
                return;
            }
            //Validate if credit card number is empty, not numbers ,and the format not matched with VISA, MASTERCARD, DISCOVER or AMERICAN EXPRESS. Validation errors show a pop up message
            if (txtCardNo.Text=="")
            {
                MessageBox.Show("Please provide a credit card number");
                return;
            }

            if(!double.TryParse(txtCardNo.Text, out dblNum))
            {
                MessageBox.Show("Please provide a credit card number with numbers only");
                return;
            }

            if (txtCardNo.Text.Trim().Length == 16 && txtCardNo.Text.Trim().StartsWith("4"))
            {
                txtCardType.Text = "VISA";
            }
            else if (txtCardNo.Text.Trim().Length == 16 && txtCardNo.Text.Trim().StartsWith("6"))
            {
                txtCardType.Text = "DISCOVER";
            }
            else if (txtCardNo.Text.Trim().Length == 15 && txtCardNo.Text.Trim().StartsWith("3") && (txtCardNo.Text.Trim().Substring(1,1)=="4"|| txtCardNo.Text.Trim().Substring(1, 1) == "7"))
            {
                txtCardType.Text = "AMEX";
            }
            else if (txtCardNo.Text.Trim().Length == 16 && (txtCardNo.Text.Trim().StartsWith("6")|| txtCardNo.Text.Trim().StartsWith("2")))
            {
                txtCardType.Text = "MASTERCARD";
            }
            else
            {
                MessageBox.Show("Please provide a valid card type of VISA, DISCOVER, AMEX, OR MASTERCARD");
                return;
            }

                //Validate if phone number is empty, not numbers. Validation errors show a pop up message
                if (txtPhone.Text == "")
                {
                    MessageBox.Show("Please provide a phone number");
                    return;
                }

                if (!double.TryParse(txtPhone.Text, out dblNum))
                {
                    MessageBox.Show("Please provide a phone number with numbers only");
                    return;
                }

                if (txtPhone.Text.Length != 10)
                {
                    MessageBox.Show("Please provide a phone number that contains 10 digit number");
                    return;
                }

                //validate if an optional email conatains @, validation errors show a pop up message

                if (!txtEmail.Text.Contains("@") && txtEmail.Text !="")
                {
                    MessageBox.Show("Please provide an email address that contains @");
                    return;
                }

                // PENTING !: DOUBLE CHECK SM KENNY VARIABLENYA
                lblRoomTypeOut.Content= New_Reservation.Room_Type;
                lblNoOfRoomsOut.Content = New_Reservation.No_of_Room;
                lblCheckInOut.Content = New_Reservation.CheckinDate;
                lblCheckOutOut.Content = New_Reservation.CheckOutDate;
                lblTotalPriceOut.Content = New_Reservation.totalprice;

                //Store data to Json File
                ExportToJson();

                //Confirmation Message
                MessageBox.Show("Your reservation has been confirmed");

                //Back to New Reservation window after a confirmation message has been shown
                New_Reservation ConfirmReservation = new New_Reservation();
                ConfirmReservation.Show();
                this.Close();

        }

                lblRoomType = New_Reservation.Room_Type;

            // if an error occurs print out error message
            catch (Exception ex)
            {
                MessageBox.Show("Export failed: " + ex.Message);
            }

            // notify user that the export is completed and show filepath of new file
            MessageBox.Show("Export successful." + Environment.NewLine + "File Created: " + strFilePath);

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //if canceled, clear all text box, close new reservation 2, and open new reservation window
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtCardNo.Text = "";
            txtCardType.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";

            New_Reservation CancelReservation = new New_Reservation();
            CancelReservation.Show();
            this.Close();
        }
    }
}
