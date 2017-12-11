using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group03
{
    class Reservation
    {
        public string CheckinDate { get; set; }

        public string CheckoutDate { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Phone_Num { get; set; }

        public string Email { get; set; }

        public string RoomType { get; set; }

        public int No_of_Room { get; set; }

        public string Room_Price { get; set; }

        public string Total_Price { get; set; }
       
        public Reservation()
        {
            CheckinDate = "";
            CheckoutDate = "";
            FirstName = "";
            LastName = "";
            Phone_Num = "";
            Email = "";
            RoomType = "";
            No_of_Room = 0;
            Total_Price = "";
            Room_Price = "";
        }

        public Reservation(string checkin,string checkout, string firstname, string lastname, string phone_num, string email, string room_type, int no_of_room,
            string total_price)
        {
            CheckinDate = checkin;
            CheckoutDate = checkout;
            FirstName = firstname;
            LastName = lastname;
            Phone_Num = phone_num;
            Email = email;
            RoomType = room_type;
            Total_Price = total_price;
            
        }
    }
}
