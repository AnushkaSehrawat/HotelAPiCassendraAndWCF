using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelServiceAPI
{
    public class Hotel
    {
       
        public int hotelid { get; set; }
        
        public string hotelname { get; set; }
     
        public string hoteladdress { get; set; }
      
        public int pincode { get; set; }
       
        public int rating { get; set; }
    }
}