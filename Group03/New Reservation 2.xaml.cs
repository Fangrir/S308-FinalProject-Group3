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
    /// Interaction logic for New_Reservation_2.xaml
    /// </summary>
    public partial class New_Reservation_2 : Window
    {
        public New_Reservation_2()
        {
            InitializeComponent();
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

                //validate if email is empty or not contained character "@", validation errors show a pop up message

                if (!txtEmail.Text.Contains("@"))
                {
                    MessageBox.Show("Please provide an email address that contains @");
                    return;
                }

                lblRoomType = New_Reservation.Room_Type;

            }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //if canceled, clear all text box, close new reservation, and open new reservation window
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
