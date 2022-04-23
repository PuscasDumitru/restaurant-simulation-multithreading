using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.KitchenStuff
{
    public static class Data
    {
        static public Random rand = new Random();
        public const int TIME_UNIT = 250;

        public static ConcurrentQueue<Order> orders = new ConcurrentQueue<Order>();
        static public Dictionary<int, PriorityQueue<int, long>> dividedOrder = new Dictionary<int, PriorityQueue<int, long>>();
        static public Dictionary<int, ConcurrentQueue<int>> preparedDishes = new Dictionary<int, ConcurrentQueue<int>>();
        static public Dish[] menuDishes = new Dish[]
          {
            new Dish { Id = 1, Name = "pizza", PrepTime = 20, Complexity = 2, CookingApparatus = "oven"},
            new Dish { Id = 2, Name = "salad", PrepTime = 10, Complexity = 1, CookingApparatus = null},
            new Dish { Id = 3, Name = "zeama", PrepTime = 7, Complexity = 1, CookingApparatus = "stove"},
            new Dish { Id = 4, Name = "Scallop Sashimi with Meyer Lemon Confit", PrepTime = 32, Complexity = 3, CookingApparatus = null},
            new Dish { Id = 5, Name = "Island Duck with Mulberry Mustard", PrepTime = 35, Complexity = 3, CookingApparatus = "oven"},
            new Dish { Id = 6, Name = "Waffles", PrepTime = 10, Complexity = 1, CookingApparatus = "stove"},
            new Dish { Id = 7, Name = "Aubergine", PrepTime = 20, Complexity = 2, CookingApparatus = null},
            new Dish { Id = 8, Name = "Lasagna", PrepTime = 30, Complexity = 2, CookingApparatus = "oven"},
            new Dish { Id = 9, Name = "Burger", PrepTime = 15, Complexity = 1, CookingApparatus = "oven"},
            new Dish { Id = 10, Name = "Gyros", PrepTime = 15, Complexity = 1, CookingApparatus = null}
          };
        static Data()
        {
            for (int complexity = 1; complexity <= 3; complexity++)
            {
                Data.dividedOrder.Add(complexity, new PriorityQueue<int, long>());
            }

            for (int i = 0; i < menuDishes.Length; i++)
            {
                Data.preparedDishes.Add(i, new ConcurrentQueue<int>());
            }
        }

        static public List<Cook> rank1 = new List<Cook>
          {
            new Cook { Id = 1, Rank = 1, Proficiency = 2, Name = "Gordon Ramsay", CatchPhrase = "This pizza is so disgusting, if you take it to Italy you'll get arrested."},
            new Cook { Id = 2, Rank = 1, Proficiency = rand.Next(1,2), Name = "Tim Hamilton", CatchPhrase = "Vestibulum congue turpis erat, at pulvinar magna elementum at."},
            new Cook { Id = 3, Rank = 1, Proficiency = rand.Next(1,2), Name = "Gordon Ramsay", CatchPhrase = "This pizza is so disgusting, if you take it to Italy you'll get arrested."},
            new Cook { Id = 4, Rank = 1, Proficiency = rand.Next(1,2), Name = "Tim Hamilton", CatchPhrase = "Vestibulum congue turpis erat, at pulvinar magna elementum at."},
            new Cook { Id = 5, Rank = 1, Proficiency = rand.Next(1,2), Name = "Gordon Ramsay", CatchPhrase = "This pizza is so disgusting, if you take it to Italy you'll get arrested."},
            new Cook { Id = 6, Rank = 1, Proficiency = rand.Next(1,2), Name = "Tim Hamilton", CatchPhrase = "Vestibulum congue turpis erat, at pulvinar magna elementum at."},
            new Cook { Id = 7, Rank = 1, Proficiency = rand.Next(1,2), Name = "Gordon Ramsay", CatchPhrase = "This pizza is so disgusting, if you take it to Italy you'll get arrested."},
            new Cook { Id = 8, Rank = 1, Proficiency = rand.Next(1,2), Name = "Tim Hamilton", CatchPhrase = "Vestibulum congue turpis erat, at pulvinar magna elementum at."},
            new Cook { Id = 9, Rank = 1, Proficiency = rand.Next(1,2), Name = "Gordon Ramsay", CatchPhrase = "This pizza is so disgusting, if you take it to Italy you'll get arrested."},
            new Cook { Id = 10, Rank = 1, Proficiency = rand.Next(1,2), Name = "Tim Hamilton", CatchPhrase = "Vestibulum congue turpis erat, at pulvinar magna elementum at."},

          };

        static public List<Cook> rank2 = new List<Cook>
          {
            new Cook { Id = 11, Rank = 2, Proficiency = 2, Name = "Gordon Ramsay", CatchPhrase = "This pizza is so disgusting, if you take it to Italy you'll get arrested."},
            new Cook { Id = 12, Rank = 2, Proficiency = 3, Name = "Tim Hamilton", CatchPhrase = "Vestibulum congue turpis erat, at pulvinar magna elementum at."},
            new Cook { Id = 13, Rank = 2, Proficiency = rand.Next(2,3), Name = "Gordon Ramsay", CatchPhrase = "This pizza is so disgusting, if you take it to Italy you'll get arrested."},
            new Cook { Id = 14, Rank = 2, Proficiency = rand.Next(2,3), Name = "Tim Hamilton", CatchPhrase = "Vestibulum congue turpis erat, at pulvinar magna elementum at."},
            new Cook { Id = 15, Rank = 2, Proficiency = rand.Next(2,3), Name = "Gordon Ramsay", CatchPhrase = "This pizza is so disgusting, if you take it to Italy you'll get arrested."},
            new Cook { Id = 16, Rank = 2, Proficiency = rand.Next(2,3), Name = "Tim Hamilton", CatchPhrase = "Vestibulum congue turpis erat, at pulvinar magna elementum at."},
            new Cook { Id = 17, Rank = 2, Proficiency = rand.Next(2,3), Name = "Gordon Ramsay", CatchPhrase = "This pizza is so disgusting, if you take it to Italy you'll get arrested."},
            new Cook { Id = 18, Rank = 2, Proficiency = rand.Next(2,3), Name = "Tim Hamilton", CatchPhrase = "Vestibulum congue turpis erat, at pulvinar magna elementum at."},
            new Cook { Id = 19, Rank = 2, Proficiency = rand.Next(2,3), Name = "Gordon Ramsay", CatchPhrase = "This pizza is so disgusting, if you take it to Italy you'll get arrested."},
            new Cook { Id = 20, Rank = 2, Proficiency = rand.Next(2,3), Name = "Tim Hamilton", CatchPhrase = "Vestibulum congue turpis erat, at pulvinar magna elementum at."},
          };

        static public List<Cook> rank3 = new List<Cook>
          {
            new Cook { Id = 21, Rank = 3, Proficiency = 4, Name = "Gordon Ramsay", CatchPhrase = "This pizza is so disgusting, if you take it to Italy you'll get arrested."},
            new Cook { Id = 22, Rank = 3, Proficiency = rand.Next(3,4), Name = "Tim Hamilton", CatchPhrase = "Vestibulum congue turpis erat, at pulvinar magna elementum at."},
            new Cook { Id = 23, Rank = 3, Proficiency = rand.Next(3,4), Name = "Gordon Ramsay", CatchPhrase = "This pizza is so disgusting, if you take it to Italy you'll get arrested."},
            new Cook { Id = 24, Rank = 3, Proficiency = rand.Next(3,4), Name = "Tim Hamilton", CatchPhrase = "Vestibulum congue turpis erat, at pulvinar magna elementum at."},
            new Cook { Id = 25, Rank = 3, Proficiency = rand.Next(3,4), Name = "Gordon Ramsay", CatchPhrase = "This pizza is so disgusting, if you take it to Italy you'll get arrested."},
            new Cook { Id = 26, Rank = 3, Proficiency = rand.Next(3,4), Name = "Tim Hamilton", CatchPhrase = "Vestibulum congue turpis erat, at pulvinar magna elementum at."},
            new Cook { Id = 27, Rank = 3, Proficiency = rand.Next(3,4), Name = "Gordon Ramsay", CatchPhrase = "This pizza is so disgusting, if you take it to Italy you'll get arrested."},
            new Cook { Id = 28, Rank = 3, Proficiency = rand.Next(3,4), Name = "Tim Hamilton", CatchPhrase = "Vestibulum congue turpis erat, at pulvinar magna elementum at."},
            new Cook { Id = 29, Rank = 3, Proficiency = rand.Next(3,4), Name = "Gordon Ramsay", CatchPhrase = "This pizza is so disgusting, if you take it to Italy you'll get arrested."},
            new Cook { Id = 30, Rank = 3, Proficiency = rand.Next(3,4), Name = "Tim Hamilton", CatchPhrase = "Vestibulum congue turpis erat, at pulvinar magna elementum at."},
          };
    }
}
