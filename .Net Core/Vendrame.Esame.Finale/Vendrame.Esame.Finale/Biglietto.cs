using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Vendrame.Esame.Finale
{
    class Biglietto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("SectionCode")]
        public string SectionCode { get; set; }
        [JsonProperty("IndexCode")]
        public int IndexCode { get; set; }
        [JsonProperty("CreationDate")]
        public DateTime CreationDate { get; set; }
        [JsonProperty("ServingDate")]
        public DateTime? ServingDate { get; set; }
    }
}
