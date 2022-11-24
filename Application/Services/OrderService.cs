using AutoMapper;
using Dapper;
using StockApp.Core.Application.Interfaces.Repositories;
using StockApp.Core.Application.Interfaces.Services;
using StockApp.Core.Application.ViewModels.Orders;
using StockApp.Core.Application.ViewModels.OrderTableDish;
using StockApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.Services
{
    public class OrderService : GenericService<SaveOrderViewModel, OrderViewModel, Order>, IOrderService
    {
        private readonly IGenericRepository<Order> _repository;
        private readonly IGenericRepository<OrderTableDish> _orderTableDishRepository;
        private readonly IMapper _mapper;
        private readonly IOrderTableDishService _orderTableDishService;

        public OrderService(IGenericRepository<Order> repository, IGenericRepository<OrderTableDish> orderTableDishRepository, IMapper mapper, IOrderTableDishService orderTableDishService) : base(repository, mapper)
        {
            _repository = repository;
            _orderTableDishRepository = orderTableDishRepository;
            _mapper = mapper;
            _orderTableDishService = orderTableDishService;
        }

        public async Task<List<OrderViewModel>> GetAllViewModelWithInclude()
        {
            var orderDetails = await _orderTableDishRepository.GetAllWithIncludeAsync(new List<string> { "Order", "Table", "Dish" });
            
            var orderList = await _repository.GetAllAsync();
            foreach (var item in orderList)
            {
                var order = await _orderTableDishRepository.GetAllWithIncludeAsync(new List<string> { "Order", "Table", "Dish" });
                //item.OrderTableDishs = order.Where(x => x.DishId == item.Id).Select(ig => new Ingredient
                //{
                //    Id = ig.IngredientId,
                //    Name = ig.Ingredient.Name
                //}).ToList();
            }

            var data = await _orderTableDishRepository.GetAllWithIncludeAsync(new List<string> { "Order", "Table", "Dish" });
            
            return orderList.Select(dish => new OrderViewModel
            {
                Id = dish.Id,
                TableId = dish.TableId,
                Subtotal = dish.Subtotal,
                OrderStatus = dish.OrderStatus,
                //Dishes = dish.Dishes  
            }).ToList();


            //var cs = "Server=.;Database=NewStockAppApiDB2;Trusted_Connection=true;MultipleActiveResultSets=True";
            //using var con = new SqlConnection(cs);
            //con.Open();

            //var query = @"SELECT [Dishs].Id,  [Dishs].Name, [Dishs].Price, [Dishs].DishCapacity, [Dishs].Category, [Ingredients].Name IngredientName
            //              FROM [NewStockAppApiDB2].[dbo].[DishIngredient]
            //              JOIN [NewStockAppApiDB2].[dbo].[Dishs] ON [DishIngredient].DishId = [Dishs].Id
            //              JOIN [NewStockAppApiDB2].[dbo].[Ingredients] ON [DishIngredient].IngredientId = [Ingredients].Id";

            //var queryResult = await con.QueryAsync<DishViewModel>(query);
        }

        public virtual async Task SaveOrder(SaveOrderViewModel vm)
        {
            
            var order = _mapper.Map<Order>(vm);
            var orderEntity = await _repository.AddAsync(order);
            foreach (var dishId in vm.Dishes)
            {
                await _orderTableDishService
                    .Add(new SaveOrderTableDishViewModel
                    {
                        OrderId = orderEntity.Id,
                        DishId = dishId,
                        TableId = order.TableId
                    });
            }
        }

        Task<List<OrderDetailViewModel>> IOrderService.GetAllViewModelWithInclude()
        {
            throw new NotImplementedException();
        }
    }
}
