using StockApp.Core.Application.ViewModels.Orders;
using StockApp.Core.Domain.Entities;

namespace StockApp.Core.Application.Interfaces.Repositories
{
    public interface ITableRepository : IGenericRepository<Table>
    {
        List<OrderDetailViewModel> GetAllCustomInclude(int id);
    }
}
