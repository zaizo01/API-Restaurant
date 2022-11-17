using StockApp.Core.Domain.Common;
using StockApp.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Domain.Entities
{
    public class Order: AuditableBaseEntity
    {
        public int TableId { get; set; }
        public ICollection<Dish> Dishes { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
