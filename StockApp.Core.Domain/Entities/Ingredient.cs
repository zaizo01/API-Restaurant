using Restaurant.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Ingredient: AuditableBaseEntity
    {
        public string Name { get; set; }
    }
}
