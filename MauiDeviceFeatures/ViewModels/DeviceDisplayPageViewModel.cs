using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiDeviceFeatures.ViewModels
{
    public class DeviceDisplayPageViewModel : ObservableObject
    {
        public double Density => DeviceDisplay.Current.MainDisplayInfo.Density;

        public double Height => DeviceDisplay.Current.MainDisplayInfo.Height;

        public bool KeepScreenOn => DeviceDisplay.Current.KeepScreenOn;

        public string Orientation => DeviceDisplay.Current.MainDisplayInfo.Orientation.ToString();

        public float RefreshRate => DeviceDisplay.Current.MainDisplayInfo.RefreshRate;

        public string Rotation => DeviceDisplay.Current.MainDisplayInfo.Rotation.ToString();

        public double Width => DeviceDisplay.Current.MainDisplayInfo.Width;
    }
}
