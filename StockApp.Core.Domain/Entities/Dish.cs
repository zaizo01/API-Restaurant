using Restaurant.Core.Domain.Common;
using Restaurant.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Dish: AuditableBaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DishCapacity { get; set; }
        public CategoryDish Category { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<OrderTableDish> OrderTableDishs { get; set; }
    }
}
