using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_20200424
{
    class StudentClass
    {
        [JsonProperty("class")]
        public String Class { get; set; }
    }
}
