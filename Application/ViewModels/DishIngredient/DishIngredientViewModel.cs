using StockApp.Core.Application.ViewModels.Dishes;
using StockApp.Core.Application.ViewModels.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.ViewModels.DishIngredient
{
    public class DishIngredientViewModel
    {
        public int DishId { get; set; }
        public DishViewModel Dish { get; set; }

        public int IngredientId { get; set; }
        public IngredientViewModel Ingredient { get; set; }
    }
}
