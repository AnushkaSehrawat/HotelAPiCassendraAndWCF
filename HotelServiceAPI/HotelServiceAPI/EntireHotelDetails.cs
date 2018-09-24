using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelServiceAPI
{
    public class EntireHotelDetails
    {
        
        public int hotelid { get; set; }

        public string hotelname { get; set; }

        public string hoteladdress { get; set; }

        public int pincode { get; set; }

        public int rating { get; set; }
       

        public List<string> amenities { get; set; }

        public string images { get; set; }
    }
}