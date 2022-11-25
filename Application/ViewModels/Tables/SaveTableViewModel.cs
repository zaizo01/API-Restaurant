using Restaurant.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.ViewModels.Tables
{
    public class SaveTableViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La cantidad de personas que puede tener la mesa es requerida")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "La descripción es requerida")]
        public string Description { get; set; }
        [Required(ErrorMessage = "El estatus de la mesa esre querido")]
        public TableStatus TableStatus { get; set; }
    }
}
