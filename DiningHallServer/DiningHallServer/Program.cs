using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DiningHallServer.DiningHallStuff;
using Newtonsoft.Json;

namespace DiningHallServer
{
     class Program
     {
          static void Main(string[] args)
          {
               new Thread(new ThreadStart(() =>
               {
                    HttpServer server = new HttpServer();
                    server.Run();
               })).Start();

               int cnt = 0;

               Console.WriteLine("Number of tables: ");
               cnt = Convert.ToInt32(Console.ReadLine());
               for (int i = 0; i < cnt; i++)
               {
                    DiningHall.Tables.Add(new Table(i + 1));
               }

               Console.WriteLine("Number of waiters: ");
               cnt = Convert.ToInt32(Console.ReadLine());
               for (int i = 0; i < cnt; i++)
               {
                    DiningHall.Waiters.Add(new Waiter(i + 1));
               }

               DiningHall.Work();
          }
     }
}
