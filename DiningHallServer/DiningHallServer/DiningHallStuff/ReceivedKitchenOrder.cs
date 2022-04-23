using System;
using System.Collections.Generic;
using System.Text;

namespace DiningHallServer.DiningHallStuff
{
    public class ReceivedKitchenOrder
    {
        public Guid OrderId { get; set; }
        public int WaiterId { get; set; }
        public int[] Items { get; set; }
        public int Priority { get; set; }
        public double MaxWait { get; set; }
        public List<CookingDetails> DetailsList { get; set; }
        public long PickUpTime { get; set; }
        public double CookingTime { get; set; }
        public int TableId { get; set; }

    }
}
