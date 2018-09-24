using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HotelWcfService
{
    [DataContract]
    public class Hotel
    {
        [DataMember]
        public int hotelid { get; set; }
        [DataMember]
        public string hotelname { get; set; }
        [DataMember]
        public string hoteladdress { get; set; }
        [DataMember]
        public int pincode { get; set; }
        [DataMember]
        public int rating { get; set; }
    }
}