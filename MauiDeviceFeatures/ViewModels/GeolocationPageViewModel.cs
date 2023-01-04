using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiDeviceFeatures.ViewModels
{
    public class GeolocationPageViewModel : ObservableObject
    {
        private string _lastKnownLocation;
        public string LastKnownLocation
        {
            get => _lastKnownLocation;
            set => _ = SetProperty(ref _lastKnownLocation, value);
        }

        private string _currentLocation;
        public string CurrentLocation
        {
            get => _currentLocation;
            set => _ = SetProperty(ref _currentLocation, value);
        }

        private bool _isFromMockProvider;
        public bool IsFromMockProvider
        {
            get => _isFromMockProvider;
            set => _ = SetProperty(ref _isFromMockProvider, value);
        }

        public GeolocationPageViewModel()
        {
            _ = GetLastKnownLocationAsync();
            _ = GetCurrentLocationAsync();
        }

        private async Task GetLastKnownLocationAsync()
        {
            try
            {
                LastKnownLocation = (await Geolocation.Default.GetLastKnownLocationAsync())?.ToString() ?? "None";
            }
            catch (Exception ex)
            {
                if (Application.Current?.MainPage != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }

        private async Task GetCurrentLocationAsync()
        {
            try
            {
                Location location = await Geolocation.Default.GetLocationAsync();

                CurrentLocation = location?.ToString() ?? "None";
                IsFromMockProvider = location != null && location.IsFromMockProvider;
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
