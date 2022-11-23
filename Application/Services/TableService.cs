using AutoMapper;
using StockApp.Core.Application.Interfaces.Repositories;
using StockApp.Core.Application.Interfaces.Services;
using StockApp.Core.Application.ViewModels.Tables;
using StockApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.Services
{
    public class TableService : GenericService<SaveTableViewModel, TableViewModel, Table>, ITableService
    {
        private readonly IGenericRepository<Table> _repository;
        private readonly IMapper _mapper;

        public TableService(IGenericRepository<Table> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
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

        public virtual async Task GetTableOrden(int id)
        {
            throw new NotImplementedException();
        }
    }
}
