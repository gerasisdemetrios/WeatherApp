using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Models;
using WeatherApp.Services;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
    public class WeatherViewModel : BaseViewModel
    {
        public WeatherViewModel()
        {
            Title = "Weather";
            SearchCommand = new Command(async () => await ExecuteAsync());
        }

        string region = string.Empty;
        public string Region
        {
            get { return region; }
            set { SetProperty(ref region, value); }
        }

        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        string temperature = string.Empty;
        public string Temperature
        {
            get { return temperature; }
            set { SetProperty(ref temperature, value); }
        }

        string pressure = string.Empty;
        public string Pressure
        {
            get { return pressure; }
            set { SetProperty(ref pressure, value); }
        }

        string humidity = string.Empty;
        public string Humidity
        {
            get { return humidity; }
            set { SetProperty(ref humidity, value); }
        }

        private async Task ExecuteAsync()
        {
            IsBusy = true;

            if (string.IsNullOrWhiteSpace(Region))
            {
                return;
            }

            List<GeoData> items = await WeatherService.GetGeoDataAsync(Region);

            if (items.Count > 0)
            {
                double longitude = items.First().Longitude;
                double latitude = items.First().Latitude;

                Forecast forecast = await WeatherService.GetWeatherDataAsync(latitude, longitude);

                Description = forecast.Weather.FirstOrDefault()?.Description;
                Temperature = string.Format("{0} °C", forecast.Main.Temperature.ToString());
                Pressure = string.Format("{0} hPa", forecast.Main.Pressure.ToString());
                Humidity = string.Format("{0} %", forecast.Main.Humidity.ToString());

                DependencyService.Get<IPlaySoundService>().PlaySucessSound();
            }
            else
            {
                Description = string.Empty;
                Temperature = string.Empty;
                Pressure = string.Empty;
                Humidity = string.Empty;

                DependencyService.Get<IPlaySoundService>().PlayErrorSound();
            }

            IsBusy = false;
        }

        public ICommand SearchCommand { get; }
    }
}