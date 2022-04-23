using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Kitchen.KitchenStuff;
using Newtonsoft.Json;

namespace Kitchen
{
    public static class Kitchen
    {
        public static List<Cook> Cooks { get; set; } = new List<Cook>();
        public static Dictionary<string, ConcurrentQueue<CookingApparatus>> CookingApparatuses =
                new Dictionary<string, ConcurrentQueue<CookingApparatus>>
                {
                    { "oven", new ConcurrentQueue<CookingApparatus>() },
                    { "stove", new ConcurrentQueue<CookingApparatus>() }
                };

        public static void Work()
        {

            new Thread(new ThreadStart(() =>
            {

                foreach (var cook in Cooks)
                {
                    cook.Work();
                }

                while (true)
                {
                    if (Data.orders.Count == 0)
                        continue;

                    Data.orders.TryDequeue(out Order order);
                    List<CookingDetails> cookingDetails = new List<CookingDetails>();
                    foreach (var item in order.Items)
                    {
                        Console.Write(item + " ");
                        while (true)
                        {
                            if (Data.preparedDishes[item - 1].Count > 0)
                            {
                                Data.preparedDishes[item - 1].TryDequeue(out int cookId);
                                cookingDetails.Add(new CookingDetails(cookId, item));
                                
                                break;
                            }
                        }
                    }

                    SendFinishedOrder(order, cookingDetails);
                    
                }
            })).Start();

        }

        public static void SendFinishedOrder(Order order, List<CookingDetails> details)
        {
            string json = JsonConvert.SerializeObject(new
            {
                OrderId = order.Id,
                WaiterId = order.WaiterId,
                order.TableId,
                order.Items,
                order.Priority,
                order.MaxWait,
                DetailsList = details,
                CookingTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() - order.PickUpTime,
                PickUpTime = order.PickUpTime

            });

            Console.WriteLine($"Order {order.Id} from table {order.TableId} has been sent back to the DiningHall!");
            SendOrderHall.SendOrder(json);
        }

    }
}
