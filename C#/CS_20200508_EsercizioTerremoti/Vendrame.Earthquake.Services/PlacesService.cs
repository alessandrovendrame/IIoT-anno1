using System;
using System.Collections.Generic;
using System.Text;
using Vendrame.Earthquake.Data;
using Vendrame.Earthquake.Models;

namespace Vendrame.Earthquake.Services
{
    public class PlacesService : IPlacesService
    {
        private readonly IPlacesRepository _placeRepository;

        public PlacesService()
        {
            _placeRepository = new PlacesRepository();
        }

        public void DeletePlace(int id)
        {
            _placeRepository.Delete(id);
        }

        public IEnumerable<Place> GetAll()
        {
            return _placeRepository.GetAll();
        }
    }
}
