using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiDeviceFeatures.ViewModels
{
    public class DeviceInformationPageViewModel : ObservableObject
    {
        public string DeviceType => DeviceInfo.Current.DeviceType.ToString();

        public string Idiom => DeviceInfo.Current.Idiom.ToString();

        public string Manufacturer => DeviceInfo.Current.Manufacturer;

        public string Model => DeviceInfo.Current.Model;

        public string Name => DeviceInfo.Current.Name;

        public string Platform => DeviceInfo.Current.Platform.ToString();

        public string Version => DeviceInfo.Current.Version.ToString();

        public string VersionString => DeviceInfo.Current.VersionString;
    }
}
