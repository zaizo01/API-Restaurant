using Restaurant.Core.Application.ViewModels.Orders;
using Restaurant.Core.Application.ViewModels.Tables;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface ITableService : IGenericService<SaveTableViewModel, TableViewModel, Table>
    {
        Task CustomUpdateTable(int id, UpdateTableViewModel table);
        List<OrderDetailViewModel> GetTableOrden(int id);
        Task ChangesStatusTable(ChangeStatusTableViewModel table);
    }
}
