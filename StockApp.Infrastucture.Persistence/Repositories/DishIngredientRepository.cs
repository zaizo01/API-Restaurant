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
    public class DishIngredientRepository : GenericRepository<DishIngredient>, IDishIngredientRepository
    {
        private readonly ApplicationContext _dbContext;

        public DishIngredientRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
