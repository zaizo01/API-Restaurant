using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class OrderTableDish
    {
        public int OrderId { get; set; }
        public int TableId { get; set; }
        public int DishId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Table Table { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
