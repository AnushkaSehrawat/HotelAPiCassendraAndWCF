using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelWcfService
{
    public interface IRepo
    {
        List<Hotel> get();
        void update(BookingUpdates bookingObject);
        List<Room> getbyid(string id);
    }
}
