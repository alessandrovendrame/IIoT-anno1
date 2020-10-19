using Microsoft.EntityFrameworkCore;
using Northwind.Vendrame.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Vendrame.Data
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
