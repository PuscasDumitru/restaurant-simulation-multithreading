﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DiningHallServer.DiningHallStuff
{
    public class CookingDetails
    {
        public int CookId { get; set; }
        public int FoodId { get; set; }

        public CookingDetails(int cookId, int foodId)
        {
            CookId = cookId;
            FoodId = foodId;
        }
    }
}
