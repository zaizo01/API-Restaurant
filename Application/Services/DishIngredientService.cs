using AutoMapper;
using StockApp.Core.Application.Interfaces.Repositories;
using StockApp.Core.Application.Interfaces.Services;
using StockApp.Core.Application.ViewModels.DishIngredient;
using StockApp.Core.Application.ViewModels.Orders;
using StockApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.Services
{
    public class DishIngredientService : GenericService<SaveDishIngredientViewModel, DishIngredientViewModel , DishIngredient>, IDishIngredientService
    {
        public DishIngredientService(IGenericRepository<DishIngredient> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
