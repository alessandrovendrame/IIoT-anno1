using System;
using System.Collections.Generic;
using System.Text;
using Vendrame.Earthquake.Models;

namespace Vendrame.Earthquake.Services
{
    public interface IEarthquakesService
    {
        void DeleteEarthquake(int id);

        IEnumerable<EarthquakeC> GetAll();
    }
}
