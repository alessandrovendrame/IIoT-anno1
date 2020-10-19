using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Maccagnan.Northwind.Models
{
    public class Product
    {

        public int ProductId { get; set; }
        
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Discontinued { get; set; }

        [Required]
        public int UnitPrice { get; set; }
    }
}
