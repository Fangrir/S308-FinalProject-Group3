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

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public double TotalPrice { get; set; }
        public int NoOfNight { get; set; }

        public Quote()
        {
            RoomType = "";
            NoOfRoom = 0;
            CheckInDate = default(DateTime);
            CheckOutDate = default(DateTime);
            TotalPrice = 0;
            NoOfNight = 0;
        }

        public Quote(string room_type, int No_Of_Room, DateTime checkin, DateTime checkout, double totalprice, int noofnight)
        {
            RoomType = room_type;
            NoOfRoom = No_Of_Room;
            CheckInDate = checkin.Date;
            CheckOutDate = checkout.Date;
            TotalPrice = totalprice;
            NoOfNight = noofnight;
        }


    }
}
