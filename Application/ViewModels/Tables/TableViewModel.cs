using Restaurant.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.ViewModels.Tables
{
    public class TableViewModel
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public TableStatus TableStatus { get; set; }
    }
}
