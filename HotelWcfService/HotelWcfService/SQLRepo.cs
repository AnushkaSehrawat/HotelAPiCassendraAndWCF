using Cassandra;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelWcfService
{
    public class SQLRepo
    {
     
        string query;
        public void Add(Book bookingObject)
        {
            

            SqlConnection connectionobject = new SqlConnection();

            connectionobject.ConnectionString = "Data Source=TAVDESK087;Initial Catalog=Booking;Integrated Security=True";
            connectionobject.Open();
            query = "insert into book values(@hotelid,@hotelname,@typeOfRoomBooked,@hoteladdress,@pincode,@noOfRoomsBooked)";
            SqlCommand cmd = new SqlCommand(query, connectionobject);
            cmd.Parameters.Add(new SqlParameter("@hotelid", bookingObject.hotelid));
            cmd.Parameters.Add(new SqlParameter("@hotelname", bookingObject.hotelname));
            cmd.Parameters.Add(new SqlParameter("@typeOfRoomBooked", bookingObject.typeOfRoomBooked));
            cmd.Parameters.Add(new SqlParameter("@hoteladdress", bookingObject.hoteladdress));
            cmd.Parameters.Add(new SqlParameter("@pincode", bookingObject.pincode));
            cmd.Parameters.Add(new SqlParameter("@noOfRoomsBooked", bookingObject.noOfRoomsBooked));


            cmd.ExecuteNonQuery();
            connectionobject.Close();

            //throw new NotImplementedException();


        }

     
    }
}