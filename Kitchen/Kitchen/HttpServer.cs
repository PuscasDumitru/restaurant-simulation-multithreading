using Kitchen.KitchenStuff;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kitchen
{

    class HttpServer
    {
        public HttpListener listener;
        public string url = "http://localhost:8000/";
        public int requestCount = 0;

        public void Run()
        {
            listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();
            Console.WriteLine("Listening for connections on {0}", url);

            Task listenTask = HandleIncomingConnections();
            listenTask.GetAwaiter().GetResult();

            listener.Close();
        }

        public void RequestInfo(HttpListenerRequest req)
        {

            Console.WriteLine("Request #: {0}", ++requestCount);

            Console.WriteLine("Endpoint:" + req.LocalEndPoint);
            Console.WriteLine("Method: " + req.HttpMethod);
            Console.WriteLine("Payload: ");

        }

        public async Task HandleIncomingConnections()
        {
            bool runServer = true;


            while (runServer)
            {

                HttpListenerContext ctx = await listener.GetContextAsync();

                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;

                RequestInfo(req);


                if (req.HttpMethod == "POST")
                {
                    using var body = req.InputStream;
                    var encoding = req.ContentEncoding;

                    using (var reader = new StreamReader(body, encoding))
                    {
                        string s = reader.ReadToEnd();
                        Console.WriteLine(s + "\n\n");

                        Order order = JsonConvert.DeserializeObject<Order>(s);


                        foreach (var item in order.Items)
                        {
                            lock (Data.dividedOrder[Data.menuDishes[item - 1].Complexity])
                                Data.dividedOrder[Data.menuDishes[item - 1].Complexity].Enqueue(item, order.PickUpTime + order.Priority);
                        }

                        Data.orders.Enqueue(order);

                    }
                }

                byte[] data = Encoding.UTF8.GetBytes("Order received from DiningHall!");
                resp.ContentType = "text/html";
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.LongLength;

                await resp.OutputStream.WriteAsync(data, 0, data.Length);
                resp.Close();
            }
        }

    }
}