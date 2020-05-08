using System;
using System.Collections.Generic;
using System.Text;
using Vendrame.Earthquake.Models;

namespace Vendrame.Earthquake.Data
{
    public interface IEarthquakesRepository : IRepository<EarthquakeC,int>
    {
        
    }
}
