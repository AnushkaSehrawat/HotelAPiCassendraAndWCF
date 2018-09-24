using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelServiceAPI
{
    public class Logging
    {
        private Logging() { }
        private static Logging _instance;
        public static Logging Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logging();
                }
                return _instance;
            }
        }
        CassendraRepo cassendraObject = new CassendraRepo();
       public void add(string comment, string request, string response)
        {
            cassendraObject.Insert(comment, request, response);
        }
    }
}