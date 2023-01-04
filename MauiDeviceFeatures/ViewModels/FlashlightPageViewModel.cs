using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiDeviceFeatures.ViewModels
{
    public class FlashlightPageViewModel : ObservableObject
    {
        private bool _isToggled;
        public bool IsToggled
        {
            get => _isToggled;
            set
            {
                _ = SetProperty(ref _isToggled, value);
                _ = ToggleAsync();
            }
        }


        private async Task ToggleAsync()
        {
            try
            {
                if (IsToggled)
                {
                    await Flashlight.Default.TurnOnAsync();
                }
                else
                {
                    await Flashlight.Default.TurnOffAsync();
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
