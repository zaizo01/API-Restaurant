using Restaurant.Core.Application.ViewModels.Orders;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IOrderService : IGenericService<SaveOrderViewModel, OrderViewModel, Order>
    {
        Task SaveOrder(SaveOrderViewModel vm);
        Task DeleteOrderCustom(int id);
        List<OrderDetailViewModel> GetAllViewModelWithInclude();
        OrderDetailViewModel GetByIdViewModelWithInclude(int id);
    }
}
