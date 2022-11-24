
using Microsoft.EntityFrameworkCore;
using StockApp.Core.Application.Interfaces.Repositories;
using StockApp.Core.Application.ViewModels.Dishes;
using StockApp.Core.Application.ViewModels.Orders;
using StockApp.Core.Domain.Entities;
using StockApp.Infrastructure.Persistence.Contexts;
using StockApp.Infrastructure.Persistence.Repository;

namespace StockApp.Infrastucture.Persistence.Repositories
{
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        private readonly ApplicationContext _dbContext;
        private DbSet<Table> table = null;
        private DbSet<Order> order = null;
        public TableRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            table = _dbContext.Set<Table>();
            order = _dbContext.Set<Order>();
        }

        public List<OrderDetailViewModel> GetAllCustomInclude(int id)
        {
             var orderQuery = order.AsQueryable();

            var result = orderQuery
                .Include(t => t.Table)
                .Include(x => x.OrderTableDishs)
                .ThenInclude(x => x.Dish)
                .Where(x => x.TableId == id);

          

            var OrderDetailViewModels = new List<OrderDetailViewModel>();

            foreach (var item in result.Where(x => x.OrderStatus == 0))
            {
                var data = new OrderDetailViewModel
                {
                    Id = item.Id,
                    TableId = item.TableId,
                    Subtotal = item.Subtotal,
                    OrderStatus = item.OrderStatus,
                    Dishes = item.OrderTableDishs.Select(d => new DishViewModel
                    {
                        Id = d.Dish.Id,
                        Name = d.Dish.Name
                    }).ToList()
                };

                OrderDetailViewModels.Add(data);
            }

            return OrderDetailViewModels;
        }
    }
}
