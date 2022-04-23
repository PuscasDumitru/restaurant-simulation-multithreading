using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using Kitchen.KitchenStuff;
using System.Threading;
using Newtonsoft.Json;

namespace Kitchen
{
     class Program
     {
          public static void Main(string[] args)
          {
               new Thread(new ThreadStart(() =>
               {
                    HttpServer server = new HttpServer();
                    server.Run();
               })).Start();

               int cnt = 0;

            //Console.WriteLine("Number of rank 1 cooks: ");
            //cnt = Convert.ToInt32(Console.ReadLine());
            //PutCooks(cnt, 1);

            //Console.WriteLine("Number of rank 2 cooks: ");
            //cnt = Convert.ToInt32(Console.ReadLine());
            //PutCooks(cnt, 2);

            //Console.WriteLine("Number of rank 3 cooks: ");
            //cnt = Convert.ToInt32(Console.ReadLine());
            //PutCooks(cnt, 3);

            Kitchen.Cooks.Add(Data.rank1[0]);
            Kitchen.Cooks.Add(Data.rank2[0]);
            Kitchen.Cooks.Add(Data.rank2[1]);
            Kitchen.Cooks.Add(Data.rank3[0]);
            

            Console.WriteLine("Number of stoves: ");
               cnt = Convert.ToInt32(Console.ReadLine());
               for (int i = 0; i < cnt; i++)
               {
                    Kitchen.CookingApparatuses["stove"].Enqueue(new CookingApparatus("stove"));
               }

               Console.WriteLine("Number of ovens: ");
               cnt = Convert.ToInt32(Console.ReadLine());
               for (int i = 0; i < cnt; i++)
               {
                    Kitchen.CookingApparatuses["oven"].Enqueue(new CookingApparatus("oven"));
               }

               new Thread(new ThreadStart(() =>
               {
                    Kitchen.Work();
               })).Start();

          }

          public static void PutCooks(int num, int rank)
          {
               if (rank == 1)
               {
                    for (int i = 0; i < num; i++)
                    {
                         Kitchen.Cooks.Add(Data.rank1[i]);
                    }
               }

               else if (rank == 2)
               {
                    for (int i = 0; i < num; i++)
                    {
                         Kitchen.Cooks.Add(Data.rank2[i]);
                    }
               }

               else if (rank == 3)
               {
                    for (int i = 0; i < num; i++)
                    {
                         Kitchen.Cooks.Add(Data.rank3[i]);
                    }
               }
          }
     }

}