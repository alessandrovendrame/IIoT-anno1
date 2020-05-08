using System;
using System.Collections.Generic;
using System.Text;

namespace Vendrame.NorthWind.Models
{
    public class Category : EntityBase<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
