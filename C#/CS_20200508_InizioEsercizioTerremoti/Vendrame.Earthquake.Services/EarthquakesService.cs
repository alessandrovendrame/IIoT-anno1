using System;
using System.Collections.Generic;
using System.Text;
using Vendrame.Earthquake.Data;
using Vendrame.Earthquake.Models;

namespace Vendrame.Earthquake.Services
{
    public class EarthquakesService : IEarthquakesService
    {
        private readonly IEarthquakesRepository _earthquakesRepository;

        public EarthquakesService()
        {
            _earthquakesRepository = new EarthquakesRepository();
        }

        public void DeleteEarthquake(int id)
        {
            _earthquakesRepository.Delete(id);
        }

        public void InsertEartquake()
        {
            
        }

        public IEnumerable<EarthquakeC> GetAll()
        {
            return _earthquakesRepository.GetAll();
        }
    }
}
