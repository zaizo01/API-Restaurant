using AutoMapper;
using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Application.ViewModels.Ingredients;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Services
{
    public class IngredientService : GenericService<SaveIngredientViewModel, IngredientViewModel, Ingredient>, IIngredientService
    {
        public IngredientService(IGenericRepository<Ingredient> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
