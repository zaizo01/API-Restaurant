using Restaurant.Core.Domain.Common;
using Restaurant.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Table: AuditableBaseEntity
    {
        public int Capacity { get; set; }
        public string Description { get; set; }
        public TableStatus TableStatus { get; set; }
        public ICollection<Order> Orders { get; set; }
        public virtual ICollection<OrderTableDish> OrderTableDishs { get; set; }
    }
}
