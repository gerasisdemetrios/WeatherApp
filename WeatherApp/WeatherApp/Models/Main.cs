using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("pressure")]
        public string Pressure { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }        
    }
}