using AutoMapper;
using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Application.ViewModels.Orders;
using Restaurant.Core.Application.ViewModels.Tables;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Services
{
    public class TableService : GenericService<SaveTableViewModel, TableViewModel, Table>, ITableService
    {
        private readonly IGenericRepository<Table> _repository;
        private readonly IMapper _mapper;
        private readonly ITableRepository _repository2;

        public TableService(IGenericRepository<Table> repository, ITableRepository repository2, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _repository2 = repository2;
            _mapper = mapper;
        }

        public virtual async Task ChangesStatusTable(ChangeStatusTableViewModel table)
        {
            var existEntity = await _repository.GetByIdAsync(table.Id);
            if (existEntity is null) throw new Exception("La Mesa especificada no existe.");
            var tableEntity = _mapper.Map<Table>(existEntity);
            tableEntity.TableStatus = table.TableStatus;
            await _repository.UpdateAsync(tableEntity, tableEntity.Id);
        }

        public virtual async Task CustomUpdateTable(int id, UpdateTableViewModel table)
        {
            var tableEntity = _mapper.Map<Table>(table);
            await _repository.UpdateAsync(tableEntity, id);

        }

        public List<OrderDetailViewModel> GetTableOrden(int id)
        {
            return _repository2.GetAllCustomInclude(id);
        }
    }
}
