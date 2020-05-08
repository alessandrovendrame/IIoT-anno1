using System;
using System.Collections.Generic;
using System.Text;

namespace Vendrame.NorthWind.Models
{
    public class Customer : EntityBase<string>
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
    }
}
