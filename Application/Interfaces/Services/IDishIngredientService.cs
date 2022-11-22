using StockApp.Core.Application.ViewModels.Dishes;
using StockApp.Core.Application.ViewModels.DishIngredient;
using StockApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.Interfaces.Services
{
    public interface IDishIngredientService : IGenericService<SaveDishIngredientViewModel, DishIngredientViewModel, DishIngredient>
    {
       
    }
}
