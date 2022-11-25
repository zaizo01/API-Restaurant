using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class DishIngredient
    {
        [ForeignKey("Dish")]
        public int DishId { get; set; }
        public virtual Dish Dish { get; set; }
        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
