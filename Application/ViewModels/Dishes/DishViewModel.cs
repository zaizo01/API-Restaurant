using StockApp.Core.Application.ViewModels.Ingredients;
using StockApp.Core.Domain.Entities;
using StockApp.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.ViewModels.Dishes
{
    public class DishViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DishCapacity { get; set; }
        public CategoryDish Category { get; set; }
        public ICollection<IngredientViewModel> Ingredients { get; set; }
    }
}
