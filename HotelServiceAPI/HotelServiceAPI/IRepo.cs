using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelServiceAPI
{
    public interface IRepo
    {
        void Add(Book bookingobject);
    }
}
