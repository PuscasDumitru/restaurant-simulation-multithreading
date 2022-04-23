using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiningHallServer.DiningHallStuff
{
     static class Reputation
     {
          public static List<int> ratings = new List<int>();

          public static void ComputeRating(double coeff)
          {
               int rating = 0;

               if (coeff < 1.1)
                    rating = 5;
               else if (coeff >= 1.1 && coeff < 1.2)
                    rating = 4;
               else if (coeff >= 1.2 && coeff < 1.3)
                    rating = 3;
               else if (coeff >= 1.3 && coeff < 1.4)
                    rating = 2;
               else if (coeff >= 1.4 && coeff < 1.5)
                    rating = 1;
               else
                    rating = 0;

               ratings.Add(rating);
          }

          public static double GetFinalRating()
          {
               return ratings.Average();
          }
     }
}
