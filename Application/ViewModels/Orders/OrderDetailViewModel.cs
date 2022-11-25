using Restaurant.Core.Application.ViewModels.Dishes;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.ViewModels.Orders
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int TableId { get; set; }

        public decimal Subtotal { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public virtual ICollection<DishViewModel> Dishes { get; set; }

        //public virtual Table Table { get; set; }
    }
}
