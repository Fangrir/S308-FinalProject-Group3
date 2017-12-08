using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group03
{
    class Reservation
    {
        // check in date
        public int NoOfNights { get; set; }
        public string RoomType { get; set; }
        public int NoOfRooms { get; set; }
        public double RoomPrice { get; set; }
        public double SubTotal { get; set; }
        public double Tax { get; set; }
        public double Fee { get; set; }
        public double Total { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CCType { get; set; }
        public long CCNo { get; set; }
        // phone no
        public string Email { get; set; }
    }
}
