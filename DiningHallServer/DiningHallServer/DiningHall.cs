using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using DiningHallServer.DiningHallStuff;

namespace DiningHallServer
{
     public static class DiningHall
     {
          public static List<Waiter> Waiters { get; set; } = new List<Waiter>();
          public static List<Table> Tables { get; set; } = new List<Table>();

          public static void Work()
          {
               foreach (var table in Tables)
               {
                    new Thread(new ThreadStart(() =>
                    {
                         table.Work();
                    })).Start();
                    
               }

               foreach (var waiter in Waiters)
               {
                    waiter.Work();
               }
          }

     }
}
