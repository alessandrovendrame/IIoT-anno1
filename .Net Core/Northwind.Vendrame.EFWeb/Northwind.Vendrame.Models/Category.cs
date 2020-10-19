using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Northwind.Vendrame.Models
{
    public class Category:EntityBase
    {
        /*
         [CategoryID]   INT           IDENTITY (1, 1) NOT NULL,
         [CategoryName] NVARCHAR (15) NOT NULL,
         [Description]  NTEXT         NULL,
         [Picture]      IMAGE         NULL,
         CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryID] ASC)
        */

        [Key]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        public string Description { get; set; }
    }
}
