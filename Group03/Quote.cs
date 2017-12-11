using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group03
{
    public class Quote
    {
        public string RoomType { get; set; }

        public int NoOfRoom { get; set; }

        public string CheckInDate { get; set; }

        public string CheckOutDate { get; set; }

        public double TotalPrice { get; set; }

        public Quote()
        {
            RoomType = "";
            NoOfRoom = 0;
            CheckInDate = "";
            CheckOutDate = "";
            TotalPrice = 0;
        }

        public Quote(string room_type, int No_Of_Room, string checkin, string checkout, double totalprice)
        {
            RoomType = room_type;
            NoOfRoom = No_Of_Room;
            CheckInDate = checkin;
            CheckOutDate = checkout;
            TotalPrice = totalprice;
        }


    }
}
