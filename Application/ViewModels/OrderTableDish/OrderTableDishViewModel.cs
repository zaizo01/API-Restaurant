using Restaurant.Core.Application.ViewModels.Dishes;
using Restaurant.Core.Application.ViewModels.Orders;
using Restaurant.Core.Application.ViewModels.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.ViewModels.OrderTableDish
{
    public class OrderTableDishViewModel
    {
        public int OrderId { get; set; }
        public int TableId { get; set; }
        public int DishId { get; set; }
        public virtual OrderViewModel Order { get; set; }
        public virtual TableViewModel Table { get; set; }
        public virtual DishViewModel Dish { get; set; }
    }
}
