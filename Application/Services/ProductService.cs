using Microsoft.AspNetCore.Http;
using StockApp.Core.Application.Interfaces.Repositories;
using StockApp.Core.Application.Interfaces.Services;
using StockApp.Core.Application.ViewModels.Products;
using StockApp.Core.Application.ViewModels.User;
using StockApp.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockApp.Core.Application.Helpers;
using AutoMapper;
using StockApp.Core.Application.Dtos.Account;

namespace StockApp.Core.Application.Services
{
    public class ProductService : GenericService<SaveProductViewModel, ProductViewModel, Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationResponse userViewModel;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(productRepository, mapper)
        {
            _productRepository = productRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
        }

        public override async Task<SaveProductViewModel> Add(SaveProductViewModel vm)
        {
            vm.UserId = userViewModel != null ? userViewModel.Id : vm.UserId;
            return await base.Add(vm);
        }

        public override async Task Update(SaveProductViewModel vm, int id)
        {
            vm.UserId = userViewModel != null ? userViewModel.Id : vm.UserId;
            await base.Update(vm, id);
        }

        public async Task<List<ProductViewModel>> GetAllViewModelWithInclude()
        {
            var productList = await _productRepository.GetAllWithIncludeAsync(new List<string> { "Category" });

            if (userViewModel != null)
            {
                productList = productList.Where(product => product.UserId == userViewModel.Id).ToList();
            }

            return productList.Select(product => new ProductViewModel
            {
                Name = product.Name,
                Description = product.Description,
                Id = product.Id,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryName = product.Category.Name,
                CategoryId = product.Category.Id
            }).ToList();
        }

        public async Task<List<ProductViewModel>> GetAllViewModelWithFilters(FilterProductViewModel filters)
        {
            var productList = await _productRepository.GetAllWithIncludeAsync(new List<string> { "Category" });

            if (userViewModel != null)
            {
                productList = productList.Where(product => product.UserId == userViewModel.Id).ToList();
            }

            var listViewModels = productList.Select(product => new ProductViewModel
            {
                Name = product.Name,
                Description = product.Description,
                Id = product.Id,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryName = product.Category.Name,
                CategoryId = product.Category.Id
            }).ToList();

            if (filters.CategoryId != null)
            {
                listViewModels = listViewModels.Where(product => product.CategoryId == filters.CategoryId.Value).ToList();
            }

            return listViewModels;
        }

    }
}
