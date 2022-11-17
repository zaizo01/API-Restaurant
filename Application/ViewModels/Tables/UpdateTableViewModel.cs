using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.ViewModels.Tables
{
    public class UpdateTableViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La capacidad es requerida")] 
        public int Capacity { get; set; }
        [Required(ErrorMessage = "La descripción es requerida")]
        public string Description { get; set; }
    }
}
