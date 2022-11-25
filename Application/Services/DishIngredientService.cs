using AutoMapper;
using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Application.ViewModels.DishIngredient;
using Restaurant.Core.Application.ViewModels.Orders;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Services
{
    public class DishIngredientService : GenericService<SaveDishIngredientViewModel, DishIngredientViewModel , DishIngredient>, IDishIngredientService
    {
        public DishIngredientService(IGenericRepository<DishIngredient> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
