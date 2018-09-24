using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace HotelWcfService
{
    [ServiceContract]
    public interface IHotel
    {
        [OperationContract]

        [WebGet(UriTemplate = "/Hotel", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

        List<Hotel> GetAllHotels();
        [WebGet(UriTemplate = "/room/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

        List<Room> GetRoomsOfAHotel(string id);

        [WebInvoke(UriTemplate = "/Hotel", Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void  update(BookingUpdates bookingObject);
        //[WebInvoke(Method = "POST", UriTemplate = "/Addbook", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //void post(Book bookobject);
    }

}
