using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class Weather
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}