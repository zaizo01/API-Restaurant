using AutoMapper;
using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Application.ViewModels.DishIngredient;
using Restaurant.Core.Application.ViewModels.Orders;
using Restaurant.Core.Application.ViewModels.OrderTableDish;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Services
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
