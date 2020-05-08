using System;
using System.Collections.Generic;
using System.Text;

namespace Vendrame.Earthquake.Models
{
    public class EarthquakeC : EntityBase<int>
    {
        public string EarthquakeUsgsId { get; set; }

        public string Title { get; set; }

        public string Place { get; set; }

        public double Mag { get; set; }

        public DateTime Time { get; set; }

        public int PlaceId { get; set; }
    }
}
