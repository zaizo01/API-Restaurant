using StockApp.Core.Application.Interfaces.Repositories;
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

        public OrderRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
