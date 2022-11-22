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
    public class DishService : GenericService<SaveDishViewModel, DishViewModel, Dish>, IDishService
    {
        private readonly IMapper mapper;
        private readonly IDishRepository _dishRepository;
        private readonly IDishIngredientRepository _dishIngredientRepository;
        private readonly IDishIngredientService _dishIngredientService;

        public DishService(IGenericRepository<Dish> repository, IMapper mapper, IDishIngredientRepository dishIngredientRepository, IDishRepository DishRepository, IDishIngredientService dishIngredientService) : base(repository, mapper)
        {
            this.mapper = mapper;
            _dishRepository = DishRepository;
            _dishIngredientService = dishIngredientService;
            _dishIngredientRepository = dishIngredientRepository;
        }

        public async Task AddIngredients(int id, List<int> ingredients)
        {
            
            foreach (var ingredient in ingredients)
            {
                var saveIngredientDTO = new SaveDishIngredientViewModel()
                {
                    DishId = id,
                    IngredientId = ingredient
                };
                
                await _dishIngredientService.Add(saveIngredientDTO);
            }
        }

        public async Task<List<DishViewModel>> GetAllViewModelWithInclude()
        {
            var dishList = await _dishRepository.GetAllWithIncludeAsync(new List<string> { "Ingredients" });

            return dishList.Select(dish => new DishViewModel
            {
                Id = dish.Id,
                Name = dish.Name,
                DishCapacity = dish.DishCapacity,
                Price = dish.Price,
                Category = dish.Category,
                Ingredients = dish.Ingredients.Select(ig => new IngredientViewModel()
                {
                    Id = ig.Id,
                    Name = ig.Name
                }).ToList()
            }).ToList();
        }
    }
}
