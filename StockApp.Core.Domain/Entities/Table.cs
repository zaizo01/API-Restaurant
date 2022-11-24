using StockApp.Core.Domain.Common;
using StockApp.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Domain.Entities
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
