using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        HttpClient client;

        static readonly string geoDataUrl = "http://api.openweathermap.org/geo/1.0/direct";
        static readonly string weatherDataUrl = "https://api.openweathermap.org/data/2.5/weather";
        static readonly string appId = "05a0c036a4ba41b929947002446fc649";

        public WeatherService()
        {
            client = new HttpClient();
        }

        public async Task<List<GeoData>> GetGeoDataAsync(string region)
        {

            var items = new List<GeoData>();
            Uri uri = new Uri($"{geoDataUrl}?q={region}&limit=1&appid={appId}");

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<GeoData>>(content);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return items;
        }

        public async Task<Forecast> GetWeatherDataAsync(double latitude, double longitude)
        {

            Forecast result = null;
            Uri uri = new Uri($"{weatherDataUrl}?lat={latitude}&lon={longitude}&units=metric&appid={appId}");

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<Forecast>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
