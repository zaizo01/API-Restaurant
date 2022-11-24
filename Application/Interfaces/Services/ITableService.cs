using StockApp.Core.Application.ViewModels.Orders;
using StockApp.Core.Application.ViewModels.Tables;
using StockApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.Interfaces.Services
{
    public interface ITableService : IGenericService<SaveTableViewModel, TableViewModel, Table>
    {
        Task CustomUpdateTable(int id, UpdateTableViewModel table);
        List<OrderDetailViewModel> GetTableOrden(int id);
        Task ChangesStatusTable(ChangeStatusTableViewModel table);
    }
}
