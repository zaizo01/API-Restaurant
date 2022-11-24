using StockApp.Core.Application.ViewModels.Orders;
using StockApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.Interfaces.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        List<OrderDetailViewModel> GetAllCustomInclude();
        OrderDetailViewModel GetAllCustomInclude(int id);
    }
}
