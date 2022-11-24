using AutoMapper;
using StockApp.Core.Application.Interfaces.Repositories;
using StockApp.Core.Application.Interfaces.Services;
using StockApp.Core.Application.ViewModels.DishIngredient;
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
    public class OrderTableDishService : GenericService<SaveOrderTableDishViewModel, OrderTableDishViewModel, OrderTableDish>, IOrderTableDishService
    {
        private readonly IGenericRepository<OrderTableDish> _repository;
        private readonly IMapper _mapper;
        public OrderTableDishService(IGenericRepository<OrderTableDish> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
