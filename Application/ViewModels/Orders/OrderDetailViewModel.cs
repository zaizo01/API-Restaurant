using StockApp.Core.Application.ViewModels.Dishes;
using StockApp.Core.Domain.Entities;
using StockApp.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.ViewModels.Orders
{
    public class OrderDetailViewModel
    {
        public int TableId { get; set; }

        public decimal Subtotal { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public virtual ICollection<DishViewModel> Dishes { get; set; }

        public virtual Table Table { get; set; }
    }
}
