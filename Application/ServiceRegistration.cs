using Restaurant.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Core.Application.Interfaces.Repositories;
using Restaurant.Core.Application.Interfaces.Services;
using System.Reflection;

namespace Restaurant.Core.Application
{

    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDishService, DishService>();
            services.AddTransient<IIngredientService, IngredientService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ITableService, TableService>();
            services.AddTransient<IDishIngredientService, DishIngredientService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderTableDishService, OrderTableDishService>();
            #endregion
        }
    }
}
