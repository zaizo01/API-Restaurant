using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Application.ViewModels.Dishes;

namespace Restaurant.WebApi.Controllers.v1
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DishController : ControllerBase
    {

        private readonly IDishService _DishService;
        private readonly IIngredientService _IngredientService;

        public DishController(IDishService DishService, IIngredientService ingredientService)
        {
            _DishService = DishService;
            _IngredientService = ingredientService;
        }

      

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DishViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            try
            {
                var dishes = await _DishService.GetAllViewModelWithInclude();

                if (dishes == null || dishes.Count == 0)
                {
                    return NotFound("No existen platos.");
                }

                return Ok(dishes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveDishViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var dishList = await _DishService.GetAllViewModelWithInclude();
                var Dish = dishList.FirstOrDefault(d => d.Id == id);

                if (Dish == null)
                {
                    return NotFound("No existe el plato.");
                }

                return Ok(Dish);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(SaveDishViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                foreach (var ingredientId in vm.Ingredients)
                {
                    var ingredient = await _IngredientService.GetByIdSaveViewModel(ingredientId);
                    if (ingredient is null) return NotFound("El ingrediente engresado no ha sido encontrado.");
                }

                if (vm.Ingredients.Count() == 0) return BadRequest("Es neceario indicar los ingredientes del plato.");
                await _DishService.AddIngredients(vm);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

      
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaveDishViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, SaveDishViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _DishService.Update(vm, id);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
