using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.ViewModels.Orders
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public List<int> Dishes { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
