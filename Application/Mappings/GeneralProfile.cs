using AutoMapper;
using Restaurant.Core.Application.Dtos.Account;
using Restaurant.Core.Application.ViewModels.Categories;
using Restaurant.Core.Application.ViewModels.Dishes;
using Restaurant.Core.Application.ViewModels.DishIngredient;
using Restaurant.Core.Application.ViewModels.Ingredients;
using Restaurant.Core.Application.ViewModels.Orders;
using Restaurant.Core.Application.ViewModels.OrderTableDish;
using Restaurant.Core.Application.ViewModels.Products;
using Restaurant.Core.Application.ViewModels.Tables;
using Restaurant.Core.Application.ViewModels.User;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {

            #region TableProfile

            CreateMap<Table, TableViewModel>()
               .ReverseMap()
               .ForMember(x => x.Created, opt => opt.Ignore())
               .ForMember(x => x.CreatedBy, opt => opt.Ignore())
               .ForMember(x => x.LastModified, opt => opt.Ignore())
               .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Table, SaveTableViewModel>()
              .ReverseMap()
              .ForMember(x => x.Created, opt => opt.Ignore())
              .ForMember(x => x.CreatedBy, opt => opt.Ignore())
              .ForMember(x => x.LastModified, opt => opt.Ignore())
              .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Table, UpdateTableViewModel>()
            .ReverseMap()
            .ForMember(x => x.Created, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.LastModified, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedBy, opt => opt.Ignore()); 
            
            
            CreateMap<Table, ChangeStatusTableViewModel>()
            .ReverseMap()
            .ForMember(x => x.Created, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.LastModified, opt => opt.Ignore())
            .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            #endregion

            #region OrderProfile

            CreateMap<Order, OrderViewModel>()
               .ReverseMap()
               .ForMember(x => x.OrderTableDishs, opt => opt.Ignore())
               .ForMember(x => x.Dishes, opt => opt.Ignore())
               .ForMember(x => x.Table, opt => opt.Ignore())
               .ForMember(x => x.Created, opt => opt.Ignore())
               .ForMember(x => x.CreatedBy, opt => opt.Ignore())
               .ForMember(x => x.LastModified, opt => opt.Ignore())
               .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Order, SaveOrderViewModel>()
              .ReverseMap()
              .ForMember(x => x.OrderTableDishs, opt => opt.Ignore())
              .ForMember(x => x.Dishes, opt => opt.Ignore())
              .ForMember(x => x.Table, opt => opt.Ignore())
              .ForMember(x => x.Created, opt => opt.Ignore())
              .ForMember(x => x.CreatedBy, opt => opt.Ignore())
              .ForMember(x => x.LastModified, opt => opt.Ignore())
              .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            #endregion

            #region IngredientProfile

            CreateMap<Ingredient, SaveIngredientViewModel>()
             .ReverseMap()
             .ForMember(x => x.Created, opt => opt.Ignore())
             .ForMember(x => x.CreatedBy, opt => opt.Ignore())
             .ForMember(x => x.LastModified, opt => opt.Ignore())
             .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Ingredient, IngredientViewModel>()
             .ReverseMap()
             .ForMember(x => x.Created, opt => opt.Ignore())
             .ForMember(x => x.CreatedBy, opt => opt.Ignore())
             .ForMember(x => x.LastModified, opt => opt.Ignore())
             .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            #endregion

            #region DishProfile

            CreateMap<Dish, DishViewModel>()
              .ReverseMap()
              .ForMember(x => x.Ingredients, opt => opt.Ignore())
              .ForMember(x => x.Created, opt => opt.Ignore())
              .ForMember(x => x.CreatedBy, opt => opt.Ignore())
              .ForMember(x => x.LastModified, opt => opt.Ignore())
              .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            CreateMap<Dish, SaveDishViewModel>()
                .ReverseMap()
                .ForMember(x => x.Ingredients, opt => opt.Ignore())
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.LastModified, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedBy, opt => opt.Ignore());

            #endregion

            #region DishIngredientProfile

            CreateMap<DishIngredient, DishIngredientViewModel>()
              .ReverseMap();

            CreateMap<DishIngredient, SaveDishIngredientViewModel>()
                .ReverseMap();
            #endregion

            #region OrderTableDishProfile
            CreateMap<OrderTableDish, OrderTableDishViewModel>()
             .ReverseMap();

            CreateMap<OrderTableDish, SaveOrderTableDishViewModel>()
                .ReverseMap();
            #endregion

            #region UserProfile
            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgotPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();
            #endregion

        }
    }
}
