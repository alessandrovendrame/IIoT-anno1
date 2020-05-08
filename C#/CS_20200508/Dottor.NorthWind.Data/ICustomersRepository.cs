using System;
using System.Collections.Generic;
using System.Text;
using Vendrame.NorthWind.Models;

namespace Vendrame.NorthWind.Data
{
    interface ICustomersRepository : IRepository<Customer, string>
    {
        IEnumerable<Customer> GetByCountry(string country);
    }
}
