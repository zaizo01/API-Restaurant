﻿using StockApp.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Core.Domain.Entities
{
    public class Ingredient: AuditableBaseEntity
    {
        public string Name { get; set; }
        public ICollection<Dish> Dishes { get; set; }
    }
}
