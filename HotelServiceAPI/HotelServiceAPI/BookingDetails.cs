using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelServiceAPI
{
    public class BookingDetails
    {
        public int hotelid { get; set; }
        public string typeOfRoomBooked { get; set; }
        public int noOfRoomsBooked { get; set; }

        public int roomrate { get; set; }
    }
}