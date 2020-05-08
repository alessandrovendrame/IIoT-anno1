using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CS_20200424.Models
{
    class Student
    {
        [JsonProperty("studentid")]
        public int ID { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }
    }
}
