using AutoMapper;
using StockApp.Core.Application.Interfaces.Repositories;
using StockApp.Core.Application.Interfaces.Services;
using StockApp.Core.Application.ViewModels.Orders;
using StockApp.Core.Application.ViewModels.OrderTableDish;
using StockApp.Core.Domain.Entities;

namespace StockApp.Core.Application.Services
{
    public class OrderService : GenericService<SaveOrderViewModel, OrderViewModel, Order>, IOrderService
    {
        private readonly IGenericRepository<Order> _repository;
        private readonly IOrderRepository _repository2;
        private readonly IGenericRepository<OrderTableDish> _orderTableDishRepository;
        private readonly IMapper _mapper;
        private readonly IOrderTableDishService _orderTableDishService;

        public OrderService(IGenericRepository<Order> repository, IOrderRepository repository2, IGenericRepository<OrderTableDish> orderTableDishRepository, IMapper mapper, IOrderTableDishService orderTableDishService) : base(repository,  mapper)
        {
            _repository = repository;
            _repository2 = repository2;
            _orderTableDishRepository = orderTableDishRepository;
            _mapper = mapper;
            _orderTableDishService = orderTableDishService;
        }

        public async Task DeleteOrderCustom(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            var records = await _orderTableDishRepository.GetAllAsync();
            foreach (var item in records.Where(x => x.OrderId == entity.Id))
            {
                await _orderTableDishRepository.DeleteAsync(item);
            }
            await _repository.DeleteAsync(entity);
        }

        public List<OrderDetailViewModel> GetAllViewModelWithInclude()
        {

            var result = _repository2.GetAllCustomInclude();
           
            return result;
        }

        public OrderDetailViewModel GetByIdViewModelWithInclude(int id)
        {
            var result = _repository2.GetAllCustomInclude(id);
            return result;
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

        
    }
}
