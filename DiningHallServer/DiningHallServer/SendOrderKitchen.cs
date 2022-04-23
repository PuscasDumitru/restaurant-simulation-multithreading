using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Text.Json;
using Newtonsoft.Json;

namespace DiningHallServer
{
    class SendOrderKitchen
    {
        public static void SendOrder(string order)
        {
            var url = "http://localhost:8000/order";

            var request = WebRequest.Create(url);
            request.Method = "POST";

            byte[] byteArray = Encoding.UTF8.GetBytes(order);
            
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            using var reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);

            using var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using var respStream = response.GetResponseStream();

            using var reader = new StreamReader(respStream);
            string data = reader.ReadToEnd();
            Console.WriteLine(data);
        }
        
    }
}
