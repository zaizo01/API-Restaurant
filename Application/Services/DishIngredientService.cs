using AutoMapper;
using StockApp.Core.Application.Interfaces.Repositories;
using StockApp.Core.Application.Interfaces.Services;
using StockApp.Core.Application.ViewModels.Dishes;
using StockApp.Core.Application.ViewModels.DishIngredient;
using StockApp.Core.Application.ViewModels.Ingredients;
using StockApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.Services
{
    public class DishIngredientService : GenericService<SaveDishIngredientViewModel, DishIngredientViewModel, Dish>, IDishIngredientService
    {
        private readonly IMapper mapper;
        private readonly IDishIngredientRepository dishIngredientRepository;

        public DishIngredientService(IGenericRepository<DishIngredient> repository, IMapper mapper, IDishIngredientRepository dishIngredientRepository) : base(repository, mapper)
        {
            this.mapper = mapper;
            this.dishIngredientRepository = dishIngredientRepository;
        }

     
    }
}
