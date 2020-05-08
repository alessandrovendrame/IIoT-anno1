using System;
using System.Collections.Generic;
using System.Text;
using Vendrame.NorthWind.Models;

namespace Vendrame.NorthWind.Services
{
    public interface ICategoriesService
    {
        void DeleteCategory(int id);

        IEnumerable<Category> GetAll();
    }
}
