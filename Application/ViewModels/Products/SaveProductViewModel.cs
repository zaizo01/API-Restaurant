﻿using Microsoft.AspNetCore.Http;
using StockApp.Core.Application.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Application.ViewModels.Products
{
    public class SaveProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre del producto")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Debe colocar el precio del producto")]
        public double? Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar la categoria del producto")]
        public int CategoryId { get; set; }
        public List<CategoryViewModel>? Categories { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? File { get; set; }

        public string? UserId { get; set; }

    }
}
