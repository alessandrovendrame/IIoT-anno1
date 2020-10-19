using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vendrame.ApiBoredWorkService.VendrameWorker
{
    class Activity
    {
        [JsonProperty("activity")]
        public string ActivityProposed { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

    }
}
