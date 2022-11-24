using StockApp.Core.Domain.Common;
using StockApp.Core.Domain.Enums;

namespace StockApp.Core.Domain.Entities
{
    public class Order: AuditableBaseEntity
    {
        public int TableId { get; set; }

        public decimal Subtotal { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
        public virtual ICollection<OrderTableDish> OrderTableDishs { get; set; }

        public virtual Table Table { get; set; }

    }
}
