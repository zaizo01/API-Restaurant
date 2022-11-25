using Restaurant.Core.Application.ViewModels.Dishes;
using Restaurant.Core.Application.ViewModels.DishIngredient;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IDishIngredientService : IGenericService<SaveDishIngredientViewModel, DishIngredientViewModel, DishIngredient>
    {
       
    }
}
