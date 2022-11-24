using Microsoft.EntityFrameworkCore;
using StockApp.Core.Application.Interfaces.Repositories;
using StockApp.Core.Application.ViewModels.Dishes;
using StockApp.Core.Application.ViewModels.Orders;
using StockApp.Core.Domain.Entities;
using StockApp.Infrastructure.Persistence.Contexts;
using StockApp.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Infrastucture.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationContext _dbContext;
        private DbSet<Order> order = null;

        public OrderRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            order = _dbContext.Set<Order>();
        }

        public List<OrderDetailViewModel> GetAllCustomInclude()
        {
            var orderQuery = order.AsQueryable();

            var result = orderQuery.
                Include(t=>t.Table).
                Include(x => x.OrderTableDishs)
               .ThenInclude(x => x.Dish);

            var OrderDetailViewModels = new List<OrderDetailViewModel>();

            foreach (var item in result)
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

        public OrderDetailViewModel GetAllCustomInclude(int id)
        {
            var orderQuery = order.AsQueryable();

            var result = orderQuery
                .Include(t => t.Table)
                .Include(x => x.OrderTableDishs)
                .ThenInclude(x => x.Dish)
                .FirstOrDefaultAsync(x => x.Id == id);

          
             var OrderDetailViewModels = new OrderDetailViewModel
                {
                    Id =  result.Result.Id,
                    TableId = result.Result.TableId,
                    Subtotal = result.Result.Subtotal,
                    OrderStatus = result.Result.OrderStatus,
                    Dishes = result.Result.OrderTableDishs.Select(d => new DishViewModel
                    {
                        Id = d.Dish.Id,
                        Name = d.Dish.Name
                    }).ToList()
                };

            return OrderDetailViewModels;
        }
    }
}
