using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HotelServiceAPI.Controllers
{
    public class HotelServiceController : ApiController
    {
        HttpClient client = new HttpClient();
        
        public static List<EntireHotelDetails> entireList = new List<EntireHotelDetails>();
        public static List<Amenities> amenitiesList = new List<Amenities>();
        public static EntireHotelDetails entireObject = new EntireHotelDetails();
        public static List<Hotel> HotelList = new List<Hotel>();
        public static List<Room> roomsList = new List<Room>();
        [HttpGet]
        public async Task<List<EntireHotelDetails>> getAllHotels()
        {
            Logging.Instance.add("In Get Calling Third party service ","Get","200 OK");
            await Task.Run(async () =>
            {
                client.BaseAddress = new Uri("http://localhost:50513");
                HttpResponseMessage response = await client.GetAsync("HotelService.svc/Hotel");
                if (response.IsSuccessStatusCode)
                {
                    HotelList = await response.Content.ReadAsAsync<List<Hotel>>();

                }
            });
            await Task.Run(() =>
            {
                var path = @"C:\Users\asehrawat\Desktop\localjson.json";
                using (StreamReader sr = new StreamReader(path))
                {
                    string json = sr.ReadToEnd();
                    amenitiesList = JsonConvert.DeserializeObject<List<Amenities>>(json);

                }
            });
            for (int i = 0; i < HotelList.Count; i++)
            {
                entireObject.hotelid = HotelList[i].hotelid;
                entireObject.hotelname = HotelList[i].hotelname;
                entireObject.hoteladdress = HotelList[i].hoteladdress;
                entireObject.pincode = HotelList[i].pincode;
                entireObject.rating = HotelList[i].rating;
                entireObject.images = amenitiesList[i].images;
                entireObject.amenities = amenitiesList[i].amenities;
                entireList.Add(entireObject);
            }


            return entireList;
        }

        [HttpPost]

        public void postBookingDetails([FromBody] BookingDetails bookingObject)
        {
            Task.Run(() =>
            {
                Book bookobject = new Book();
                //var path = @"C:\Users\asehrawat\Desktop\localjson.json";
                //using (StreamReader sr = new StreamReader(path))
                //{
                //    string json = sr.ReadToEnd();
                //    amenitiesList = JsonConvert.DeserializeObject<List<Amenities>>(json);

                //}

                //foreach (var hotelamenities in amenitiesList)
                //{
                //    if (hotelamenities.hotelname == bookingObject.hotelname)
                //    {
                //        bookingObject.hotelid = hotelamenities.hotelid;
                //    }
                //}
                for(int i = 0; i < entireList.Count; i++)
                {
                    if (entireList[i].hotelid==bookingObject.hotelid)
                    {
                        bookobject.hotelid = entireList[i].hotelid;
                        bookobject.hotelname = entireList[i].hotelname;
                        bookobject.hoteladdress = entireList[i].hoteladdress;
                        bookobject.pincode = entireList[i].pincode;
                        bookobject.noOfRoomsBooked = bookingObject.noOfRoomsBooked;
                        bookobject.typeOfRoomBooked = bookingObject.typeOfRoomBooked;
                        bookobject.roomrate = bookingObject.roomrate; 
                    }
                }

                SQLRepo sqlObject = new SQLRepo();
                sqlObject.Add(bookobject);
            });



        }

        [HttpPut]

        public async void updateCassendra([FromBody] BookingUpdates bookObj)
        {
            var path = @"C:\Users\asehrawat\Desktop\localjson.json";

            using (StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                amenitiesList = JsonConvert.DeserializeObject<List<Amenities>>(json);

            }

            foreach (var hotelamenities in amenitiesList)
            {
                if (hotelamenities.hotelname == bookObj.hotelname)
                {
                    bookObj.hotelid = hotelamenities.hotelid.ToString();
                }
            }

            HttpResponseMessage response = null;

            using (var client = new HttpClient())
            {
                string url = "http://localhost:50513/HotelService.svc/Hotel";



                response = await client.PutAsJsonAsync(url, bookObj);




            }
        }

        [HttpGet]
        [Route("api/HotelService/rooms/{hotelname}")]
        public async Task<List<Room>> getRoomsOfAHotel(string hotelname)
        {
            var client = new HttpClient();
            var path = @"C:\Users\asehrawat\Desktop\localjson.json";
            string hotelid = null;

            using (StreamReader sr = new StreamReader(path))
            {
                string json = sr.ReadToEnd();
                amenitiesList = JsonConvert.DeserializeObject<List<Amenities>>(json);

            }

            foreach (var hotelamenities in amenitiesList)
            {
                if (hotelamenities.hotelname == hotelname)
                {
                    hotelid = hotelamenities.hotelid.ToString();
                }
            }

            string url = "http://localhost:50513/HotelService.svc/room/"+hotelid;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                roomsList = await response.Content.ReadAsAsync<List<Room>>();

            }
            return roomsList;

        }


    }
}
