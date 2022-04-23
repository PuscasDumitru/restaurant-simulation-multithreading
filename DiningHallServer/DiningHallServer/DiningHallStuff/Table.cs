using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DiningHallServer.DiningHallStuff
{
     public class Table
     {
          public int Id { get; set; }
          public bool waitingToOrder = false;
          public bool isFree = true;
          public bool waitingServe = false;
          Random rand = new Random();

          public Table(int id)
          {
               Id = id;
          }
          public void Work()
          {

               new Thread(new ThreadStart(() =>
               {
                    while (true)
                    {
                         if (isFree)
                         {
                              Console.WriteLine($"Table {Id} is being occupied");
                              Thread.Sleep(rand.Next(5, 15) * Data.TIME_UNIT); 
                           isFree = false;

                              Console.WriteLine($"Table {Id} is making the order");
                              Thread.Sleep(rand.Next(5, 15) * Data.TIME_UNIT); 
                           waitingToOrder = true;
                         }
                    }

               })).Start();

          }

          public void Eat()
          {
               Console.WriteLine($"Table {Id} is eating");
               Thread.Sleep(rand.Next(10, 20) * Data.TIME_UNIT); 
            Console.WriteLine($"Table {Id} finished eating, now it's free");
               this.isFree = true;
          }
          public Order GenerateOrder()
          {

               int[] items = new int[rand.Next(1, 4)];
               for (int i = 0; i < items.Length; i++)
               {
                    items[i] = rand.Next(1, 10);
               }

               int priority = rand.Next(1, 5);

               return new Order(items, priority, this.Id, DateTimeOffset.Now.ToUnixTimeMilliseconds());
          }
     }
}
