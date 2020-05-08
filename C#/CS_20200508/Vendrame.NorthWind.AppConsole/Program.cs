using System;
using Vendrame.NorthWind.Services;

namespace Vendrame.NorthWind.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ICategoriesService categoriesService = new CategoriesService();

            var categories = categoriesService.GetAll();

            categoriesService.DeleteCategory(12);
        }
    }
}
