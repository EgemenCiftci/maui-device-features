using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiDeviceFeatures.ViewModels
{
    public class GeocodingPageViewModel : ObservableObject
    {
        private string _mapServiceToken;
        public string MapServiceToken
        {
            get => _mapServiceToken;
            set => _ = SetProperty(ref _mapServiceToken, value);
        }

        private string _address;
        public string Address
        {
            get => _address;
            set => _ = SetProperty(ref _address, value);
        }

        private double? _latitude;
        public double? Latitude
        {
            get => _latitude;
            set => _ = SetProperty(ref _latitude, value);
        }

        private double? _longitude;
        public double? Longitude
        {
            get => _longitude;
            set => _ = SetProperty(ref _longitude, value);
        }

        public IAsyncRelayCommand SaveMapServiceTokenCommand { get; }
        public IAsyncRelayCommand GetLocationCommand { get; }
        public IAsyncRelayCommand GetPlacemarkCommand { get; }

        public GeocodingPageViewModel()
        {
            MapServiceToken = SecureStorage.Default.GetAsync("mapServiceToken").GetAwaiter().GetResult();
            SaveMapServiceTokenCommand = new AsyncRelayCommand(SaveMapServiceTokenAsync);
            GetLocationCommand = new AsyncRelayCommand(GetLocationAsync);
            GetPlacemarkCommand = new AsyncRelayCommand(GetPlacemarkAsync);
        }

        private async Task GetLocationAsync()
        {
            try
            {
                string location = (await Geocoding.Default.GetLocationsAsync(Address))?.FirstOrDefault()?.ToString() ?? "None";

                if (Application.Current?.MainPage != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Location", location, "OK");
                }
            }
            catch (Exception ex)
            {
                if (Application.Current?.MainPage != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }

        private async Task GetPlacemarkAsync()
        {
            try
            {
                string placemark = (await Geocoding.Default.GetPlacemarksAsync(Latitude.GetValueOrDefault(), Longitude.GetValueOrDefault()))?.FirstOrDefault()?.ToString() ?? "None";

                if (Application.Current?.MainPage != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Placemark", placemark, "OK");
                }
            }
            catch (Exception ex)
            {
                if (Application.Current?.MainPage != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }

        private async Task SaveMapServiceTokenAsync()
        {
            try
            {
                await SecureStorage.Default.SetAsync("mapServiceToken", MapServiceToken);

                if (Application.Current?.MainPage != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Warning", "Restart the application for the changes to take effect.", "OK");
                }
            }
            catch (Exception ex)
            {
                if (Application.Current?.MainPage != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }
    }
}
