using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelServiceAPI
{
    public class CassendraRepo
    {
        Cluster clusterObject = Cluster.Builder().AddContactPoint("127.0.0.1").Build();

        public void Insert(string comment, string request, string response)
        {
            ISession session = clusterObject.Connect("log");
            
            string query = "Insert into log.logs(id,comment , request, response) values(uuid(),'" + comment + "','" +request + "','" + response + "');";
                        
            session.Execute(query);

        }

    }
}