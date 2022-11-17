using StockApp.Core.Domain.Entities;
using StockApp.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.ViewModels.Dishes
{
    public class SaveDishViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del plato es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El precio del plato es requerido")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Cantidad de personas para la que da el plato es requeda")]
        public int DishCapacity { get; set; }
        [Required(ErrorMessage = "La categoria del plato es requerida")]
        public CategoryDish Category { get; set; }
        [Required(ErrorMessage = "Los ingredientes del plato son requeridos")]
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
