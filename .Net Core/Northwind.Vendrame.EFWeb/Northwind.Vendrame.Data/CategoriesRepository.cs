using Microsoft.EntityFrameworkCore;
using Northwind.Vendrame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Vendrame.Data
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly NorthwindContext _northwindContext;

        public int Count()
        {
            return _northwindContext.Categories.Count();
        }

        public void Delete(int categoryId)
        {
            var category = new Category
            {
                CategoryID = categoryId
            };
            _northwindContext.Entry(category).State = EntityState.Deleted;

            _northwindContext.SaveChanges();
        }

        public Category Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            return _northwindContext.Categories.OrderBy(p => p.CategoryName).ToArray();
        }

        public void Insert(Category category)
        {
            _northwindContext.Categories.Add(category);
            _northwindContext.SaveChanges();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
}
