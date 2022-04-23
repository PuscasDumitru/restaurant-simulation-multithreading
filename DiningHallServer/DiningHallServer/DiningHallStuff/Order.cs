using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiningHallServer.DiningHallStuff
{
     public class Order
     {
          public Guid Id { get; set; }
          public int[] Items { get; set; }
          public int Priority { get; set; }
          public double MaxWait { get; set; }
          public int TableId { get; set; }
          public long PickUpTime { get; set; }

          public Order(int[] items, int priority, int tableId, long pickupTime)
          {
               Id = Guid.NewGuid();
               TableId = tableId;
               Items = items;
               Priority = priority;
               PickUpTime = pickupTime;
               MaxWait = Data.menuDishes.Where(x => Items.Contains(x.Id)).Select(x => x.PrepTime).Max() * 1.3 * Data.TIME_UNIT;
          }

     }
}
