using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DiningHallServer.DiningHallStuff
{
    public class Waiter
    {
        public int Id { get; set; }
        public List<Order> TakenOrders { get; set; }

        public Waiter(int id)
        {
            Id = id;
            TakenOrders = new List<Order>();
        }

        public void SendOrder(Order order)
        {
            string json = JsonConvert.SerializeObject(new
            {
                order.Id,
                WaiterId = this.Id,
                order.TableId,
                order.Items,
                order.Priority,
                order.MaxWait,
                order.PickUpTime
            });

            Console.WriteLine($"Order {order.Id} from table {order.TableId} has been sent to the Kitchen!");
            SendOrderKitchen.SendOrder(json);
        }
        public void Work()
        {

            new Thread(new ThreadStart(() =>
            {
                Random rand = new Random();

                while (true)
                {

                    while (TakenOrders.Any(x => Data.orders.Any(y => x.Id == y.OrderId)))
                    {
                        
                        var preparedOrder = TakenOrders.First(x => Data.orders.Any(y => x.Id == y.OrderId));
                        Console.WriteLine($"Serving the order {preparedOrder.Id} for table {preparedOrder.TableId}");

                        Thread.Sleep(rand.Next(2, 4) * Data.TIME_UNIT);
                        TakenOrders.Remove(preparedOrder);

                        lock (DiningHall.Tables)
                        {
                            DiningHall.Tables[preparedOrder.TableId - 1].waitingServe = false;
                            DiningHall.Tables[preparedOrder.TableId - 1].Eat();
                            
                        }

                    }

                    Table table = new Table(-1);

                    lock (DiningHall.Tables)
                    {
                        if (DiningHall.Tables.Any(x => x.waitingToOrder))
                        {

                            table = DiningHall.Tables.First(x => x.waitingToOrder);
                            table.waitingToOrder = false;
                            table.waitingServe = true;
                        }
                    }

                    if (table.Id != -1)
                    {
                        Thread.Sleep(rand.Next(2, 4) * Data.TIME_UNIT);
                        Order order = table.GenerateOrder();
                        SendOrder(order);
                        TakenOrders.Add(order);

                    }

                }

            })).Start();
        }
    }
}
