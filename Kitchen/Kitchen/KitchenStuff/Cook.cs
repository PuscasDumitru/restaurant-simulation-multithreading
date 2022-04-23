using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Kitchen.KitchenStuff
{
    public class Cook
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        public int Proficiency { get; set; }
        public string Name { get; set; }
        public string CatchPhrase { get; set; }

        public Cook() { }
        public Cook(int id, int rank, int proficiency, string name, string catchPhrase)
        {
            Id = id;
            Rank = rank;
            Proficiency = proficiency;
            Name = name;
            CatchPhrase = catchPhrase;
        }

        public void Work()
        {
            new Thread(new ThreadStart(() =>
            {
                Thread[] dishThreads = new Thread[Proficiency];

                for (int i = 0; i < dishThreads.Length; i++)
                {
                    dishThreads[i] = new Thread(new ThreadStart(() =>
                       {
                           int dishId;
                           int takenDish;

                           while (true)
                           {
                               dishId = -1;

                               if (Data.dividedOrder[Rank].Count > 0)
                               {
                                   lock (Data.dividedOrder[Rank])
                                   {
                                       Data.dividedOrder[Rank].TryDequeue(out takenDish, out long priority);
                                   }
                                   dishId = takenDish - 1;

                               }

                               if (dishId == -1 && Rank > 1 && Data.dividedOrder[Rank - 1].Count > 0)
                               {
                                   lock (Data.dividedOrder[Rank - 1])
                                   {
                                       Data.dividedOrder[Rank - 1].TryDequeue(out takenDish, out long priority);
                                   }
                                   dishId = takenDish - 1;
                               }

                               if (dishId != -1)
                               {
                                   string neededApparatus = Data.menuDishes[dishId].CookingApparatus;
                                   CookingApparatus takenApparatus = null;

                                   if (neededApparatus != null && !Kitchen.CookingApparatuses[neededApparatus].IsEmpty)
                                       Kitchen.CookingApparatuses[neededApparatus].TryDequeue(out takenApparatus);

                                   Thread.Sleep(Data.menuDishes[dishId].PrepTime ); // * DividedOrder.TIME_UNIT

                                   if (takenApparatus != null)
                                       Kitchen.CookingApparatuses[neededApparatus].Enqueue(takenApparatus);

                                   Data.preparedDishes[dishId].Enqueue(this.Id);
                               }
                           }
                       }));

                    dishThreads[i].Start();
                }

            })).Start();

        }
    }
}
