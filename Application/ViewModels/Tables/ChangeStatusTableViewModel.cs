using Restaurant.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.ViewModels.Tables
{
    public class ChangeStatusTableViewModel
    {
        [Required(ErrorMessage = "El id de la mesa es requerido")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El estatus de la mesa esre querido")]
        public TableStatus TableStatus { get; set; }
    }
}
