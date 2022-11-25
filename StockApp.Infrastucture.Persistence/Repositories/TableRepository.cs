
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Core.Application.ViewModels.Dishes;
using Restaurant.Core.Application.ViewModels.Orders;
using Restaurant.Core.Domain.Entities;
using Restaurant.Infrastructure.Persistence.Contexts;
using Restaurant.Infrastructure.Persistence.Repository;

namespace Restaurant.Infrastucture.Persistence.Repositories
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
