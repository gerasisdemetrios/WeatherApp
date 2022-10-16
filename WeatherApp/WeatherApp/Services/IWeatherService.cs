using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        Task<List<GeoData>> GetGeoDataAsync(string region);
        Task<Forecast> GetWeatherDataAsync(double latitude, double longitude);
    }
}