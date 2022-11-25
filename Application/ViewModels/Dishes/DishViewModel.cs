using Restaurant.Core.Application.ViewModels.Ingredients;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.ViewModels.Dishes
{
    public class DishViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DishCapacity { get; set; }
        public CategoryDish Category { get; set; }
        public virtual ICollection<IngredientViewModel> Ingredients { get; set; }
    }
}
