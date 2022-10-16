using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class GeoData
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
