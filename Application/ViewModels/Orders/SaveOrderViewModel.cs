using Restaurant.Core.Application.ViewModels.Dishes;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.ViewModels.Orders
{
    public class SaveOrderViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe especificar la mesa a la que pertecene la orden")]
        public int TableId { get; set; }
        [Required(ErrorMessage = "Debe contener platos la orden")]
        public List<int> Dishes { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
