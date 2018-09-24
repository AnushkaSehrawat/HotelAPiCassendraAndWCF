using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWcfService
{
    public class CassandraRepo : IRepo
    {
        Cluster clusterObject = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
        List<Hotel> hotelList = new List<Hotel>();
        List<Room> roomsList = new List<Room>();
        public List<Hotel> get()
        {
            ISession session = clusterObject.Connect("hotels");
            string query = "SELECT * FROM  hotels.hotel";
            var res = session.Execute(query);
            foreach (var row in res)
            {
                int id = row.GetValue<int>("hotelid");
                string hoteladdress = row.GetValue<string>("hoteladdress");
                string hotelname = row.GetValue<string>("hotelname");
                int pincode = row.GetValue<int>("pincode");
                int rating = row.GetValue<int>("rating");
                hotelList.Add(new Hotel { hotelid = id, hoteladdress = hoteladdress, hotelname = hotelname, pincode = pincode, rating = rating });
                // Do something with the value
            }
            //throw new NotImplementedException();
            return hotelList;
        }

        public List<Room> getbyid(string id)
        {
            int hotelid = int.Parse(id);
            ISession session = clusterObject.Connect("hotels");
            string query = "SELECT * FROM  hotels.rooms WHERE hotelid=" + hotelid;
            var res = session.Execute(query);
            foreach (var row in res)
            {
                int hid = row.GetValue<int>("hotelid");
                string roomtype = row.GetValue<string>("roomtype");
                int roomavailabilty = row.GetValue<int>("roomavailabilty");
                int roomrate = row.GetValue<int>("roomrate");

                roomsList.Add(new Room { hotelid = hid, roomtype = roomtype, roomavailability = roomavailabilty, roomrate = roomrate });
                // Do something with the value
            }

            return roomsList;
        }

        public void update(BookingUpdates bookObject)
        {
            //throw new NotImplementedException();
            ISession session = clusterObject.Connect("hotels");
            int availablerooms=0;
            int noRooms = int.Parse(bookObject.noOfRooms);
            int id = int.Parse(bookObject.hotelid);


           string query = "SELECT * FROM  hotels.rooms where roomtype= '" + bookObject.roomtype +"' AND hotelid="+id;
            var res = session.Execute(query);
            foreach (var row in res)
            {
                availablerooms = int.Parse(row.GetValue<int>("roomavailabilty").ToString());


                // Do something with the value
            }
            availablerooms = availablerooms - noRooms;
            query = "Update hotels.rooms Set roomavailabilty =  " + availablerooms + " Where roomtype = '" + bookObject.roomtype +"' AND hotelid="+id ;
            session.Execute(query);
        }
    }
}