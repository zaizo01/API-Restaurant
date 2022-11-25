using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.ViewModels.Ingredients
{
    public class SaveIngredientViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del ingrediente es requerido")]
        public string Name { get; set; }
    }
}
