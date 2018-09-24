using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HotelWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HotelService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HotelService.svc or HotelService.svc.cs at the Solution Explorer and start debugging.
    public class HotelService : IHotel
    {

        CassandraRepo cassandraObject = new CassandraRepo();
        public List<Hotel> GetAllHotels()
        {
            return cassandraObject.get();
        }

        public List<Room> GetRoomsOfAHotel(string id)
        {
            return cassandraObject.getbyid(id);
        }

        //public void post(Book bookobject)
        //{
        //    SQLRepo sqlobject = new SQLRepo();
        //     sqlobject.Add(bookobject);
        //    //throw new NotImplementedException();
        //}

        public void update(BookingUpdates bookingObject)
        {
             cassandraObject.update(bookingObject);
        }
    }
}
