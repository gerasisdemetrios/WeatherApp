using Android.Media;
using WeatherApp.Droid.Services;
using WeatherApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(PlaySoundService))]
namespace WeatherApp.Droid.Services
{
    public class PlaySoundService : IPlaySoundService
    {
        private MediaPlayer _mediaPlayer;
        public void PlaySucessSound()
        {
            _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.Success);
            _mediaPlayer.Start();
        }
        public void PlayErrorSound()
        {
            _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.Error);
            _mediaPlayer.Start();
        }
    }
}