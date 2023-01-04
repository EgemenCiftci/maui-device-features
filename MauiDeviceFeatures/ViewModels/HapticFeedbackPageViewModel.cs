using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiDeviceFeatures.ViewModels
{
    public class HapticFeedbackPageViewModel : ObservableObject
    {
        public IAsyncRelayCommand ClickCommand { get; }
        public IAsyncRelayCommand LongPressCommand { get; }

        public HapticFeedbackPageViewModel()
        {
            ClickCommand = new AsyncRelayCommand(ClickAsync);
            LongPressCommand = new AsyncRelayCommand(LongPressAsync);
        }

        private async Task ClickAsync()
        {
            try
            {
                if (HapticFeedback.Default.IsSupported)
                {
                    HapticFeedback.Default.Perform(HapticFeedbackType.LongPress);
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

        private async Task LongPressAsync()
        {
            try
            {
                if (HapticFeedback.Default.IsSupported)
                {
                    HapticFeedback.Default.Perform(HapticFeedbackType.Click);
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
