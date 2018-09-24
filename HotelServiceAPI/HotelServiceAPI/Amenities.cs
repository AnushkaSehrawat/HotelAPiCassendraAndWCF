using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelServiceAPI
{
    public class Amenities
    {
         public int hotelid { get; set; }
        public string hotelname { get; set; }
        public List<string> amenities { get; set; }

        public string images { get; set; }

   
    }
}