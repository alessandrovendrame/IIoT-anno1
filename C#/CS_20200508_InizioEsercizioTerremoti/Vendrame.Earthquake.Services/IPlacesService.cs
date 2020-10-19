using System;
using System.Collections.Generic;
using System.Text;
using Vendrame.Earthquake.Models;

namespace Vendrame.Earthquake.Services
{
    public interface IPlacesService
    {
        void DeletePlace(int id);

        IEnumerable<Place> GetAll();
    }
}
