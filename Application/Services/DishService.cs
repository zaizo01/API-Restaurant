using AutoMapper;
using Dapper;
using Microsoft.Data.SqlClient;
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

        public async Task AddIngredients(SaveDishViewModel dish)
        {
            var dishEntity = mapper.Map<Dish>(dish);
            await _dishRepository.AddAsync(dishEntity);

            foreach (var ingredient in dish.Ingredients)
            {
                var saveIngredientDTO = new SaveDishIngredientViewModel()
                {
                    DishId = dishEntity.Id,
                    IngredientId = ingredient
                };
                
                await _dishIngredientService.Add(saveIngredientDTO);
            }
        }

        public async Task<List<DishViewModel>> GetAllViewModelWithInclude()
        {
            var dishList = await _dishRepository.GetAllAsync();
            foreach (var item in dishList)
            {
                var dishIngredient = await _dishIngredientRepository.GetAllWithIncludeAsync(new List<string> { "Ingredient", "Dish" });
                item.Ingredients = dishIngredient.Where(x => x.DishId == item.Id).Select(ig => new Ingredient
                {
                    Id = ig.IngredientId,
                    Name = ig.Ingredient.Name
                }).ToList();
            }

            //var cs = "Server=.;Database=NewStockAppApiDB2;Trusted_Connection=true;MultipleActiveResultSets=True";
            //using var con = new SqlConnection(cs);
            //con.Open();

            //var query = @"SELECT [Dishs].Id,  [Dishs].Name, [Dishs].Price, [Dishs].DishCapacity, [Dishs].Category, [Ingredients].Name IngredientName
            //              FROM [NewStockAppApiDB2].[dbo].[DishIngredient]
            //              JOIN [NewStockAppApiDB2].[dbo].[Dishs] ON [DishIngredient].DishId = [Dishs].Id
            //              JOIN [NewStockAppApiDB2].[dbo].[Ingredients] ON [DishIngredient].IngredientId = [Ingredients].Id";

            //var queryResult = await con.QueryAsync<DishViewModel>(query);

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
