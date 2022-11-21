using StockApp.Core.Application.ViewModels.Dishes;
using StockApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.Interfaces.Services
{
    public interface IDishService: IGenericService<SaveDishViewModel, DishViewModel, Dish>
    {
        Task<List<DishViewModel>> GetAllViewModelWithInclude();
        Task AddIngredients(int id, List<int> ingredients);
    }
}
