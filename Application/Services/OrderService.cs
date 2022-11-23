using AutoMapper;
using StockApp.Core.Application.Interfaces.Repositories;
using StockApp.Core.Application.Interfaces.Services;
using StockApp.Core.Application.ViewModels.Orders;
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
        private readonly IMapper _mapper;
        public OrderService(IGenericRepository<Order> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public virtual async Task SaveOrder(SaveOrderViewModel vm)
        {
            
            foreach (var dishId in vm.Dishes)
            {
                var order = _mapper.Map<Order>(vm);
                order.TableId = dishId;
                await _repository.AddAsync(order);
            }
        }
    }
}
