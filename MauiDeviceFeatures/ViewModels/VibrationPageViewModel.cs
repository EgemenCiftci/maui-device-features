using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiDeviceFeatures.ViewModels
{
    public class VibrationPageViewModel : ObservableObject
    {
        public IAsyncRelayCommand VibrateCommand { get; }

        public VibrationPageViewModel()
        {
            VibrateCommand = new AsyncRelayCommand(VibrateAsync);
        }

        private async Task VibrateAsync()
        {
            try
            {
                if (Vibration.Default.IsSupported)
                {
                    Vibration.Default.Vibrate();
                }
                else
                {
                    if (Application.Current?.MainPage != null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Not supported", "OK");
                    }
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
