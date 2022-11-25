using Restaurant.Core.Application.ViewModels.Orders;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Interfaces.Repositories
{
    public interface ITableRepository : IGenericRepository<Table>
    {
        List<OrderDetailViewModel> GetAllCustomInclude(int id);
    }
}
