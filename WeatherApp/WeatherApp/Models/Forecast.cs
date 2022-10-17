using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models
{
    public class Forecast
    {
        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }
        
        [JsonProperty("name")]
        public string Location { get; set; }
        public Main Main { get; set; }
    }
}
