using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiDeviceFeatures.ViewModels
{
    public class FlashlightPageViewModel : ObservableObject
    {
        private bool _isOn;

        public bool IsOn
        {
            get => _isOn;
            private set => SetProperty(ref _isOn, value);
        }

        public IAsyncRelayCommand TurnOnOffCommand { get; }

        public FlashlightPageViewModel()
        {
            TurnOnOffCommand = new AsyncRelayCommand(TurnOnOffAsync);
        }

        private async Task TurnOnOffAsync()
        {
            try
            {
                if (IsOn)
                {
                    await Flashlight.Default.TurnOffAsync();
                }
                else
                {
                    await Flashlight.Default.TurnOnAsync();
                }

                IsOn = !IsOn;
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
