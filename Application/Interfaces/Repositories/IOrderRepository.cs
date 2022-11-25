using Restaurant.Core.Application.ViewModels.Orders;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Interfaces.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        List<OrderDetailViewModel> GetAllCustomInclude();
        OrderDetailViewModel GetAllCustomInclude(int id);
    }
}
