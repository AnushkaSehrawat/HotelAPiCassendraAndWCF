using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelServiceAPI
{
    public class Book
    {
        public int hotelid { get; set; }
        public string hotelname { get; set; }
        public string typeOfRoomBooked { get; set; }
        public string hoteladdress { get; set; }
        public int pincode { get; set; }
        public int roomrate { get; set; }

        public int noOfRoomsBooked { get; set; }
    }
}