using StockApp.Core.Application.ViewModels.Orders;
using StockApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.Interfaces.Services
{
    public interface IOrderService : IGenericService<SaveOrderViewModel, OrderViewModel, Order>
    {
        Task SaveOrder(SaveOrderViewModel vm);
        Task<List<OrderDetailViewModel>> GetAllViewModelWithInclude();
    }
}
