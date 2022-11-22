using StockApp.Core.Domain.Common;
using StockApp.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Domain.Entities
{
    public class Dish: AuditableBaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DishCapacity { get; set; }
        public CategoryDish Category { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
