﻿using StockApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Domain.Entities
{
    public class Product : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public double? Price { get; set; }

        public int CategoryId { get; set; }
        //Navigation Property
        public Category? Category { get; set; }

        public string? UserId { get; set; }  
        //Navigation Property
   
    }
}
