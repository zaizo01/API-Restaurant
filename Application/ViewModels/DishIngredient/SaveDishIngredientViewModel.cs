﻿using StockApp.Core.Application.ViewModels.Dishes;
using StockApp.Core.Application.ViewModels.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.ViewModels.DishIngredient
{
    public class SaveDishIngredientViewModel
    {
        public int DishId { get; set; }
        public virtual DishViewModel Dish { get; set; }

        public int IngredientId { get; set; }
        public virtual IngredientViewModel Ingredient { get; set; }
    }
}
