using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Kneat.Domain
{
    public class StartshipHeaderModel
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }

        [JsonProperty("results")]
        public List<StarshipModel> Starships { get; set; }
    }
}
