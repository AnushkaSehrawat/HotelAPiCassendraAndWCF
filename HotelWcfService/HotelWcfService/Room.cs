using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HotelWcfService
{
    [DataContract]
    public class Room
    {
        [DataMember]
        public int hotelid { get; set; }
        [DataMember]
        public string roomtype { get; set; }
        [DataMember]
        public int roomrate { get; set; }
        [DataMember]
        public int roomavailability { get; set; }
    }
}