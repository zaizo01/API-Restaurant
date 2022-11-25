using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Core.Domain.Entities;
using Restaurant.Infrastructure.Persistence.Contexts;
using Restaurant.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastucture.Persistence.Repositories
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
