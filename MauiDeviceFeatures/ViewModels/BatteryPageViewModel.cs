using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiDeviceFeatures.ViewModels
{
    public class BatteryPageViewModel : ObservableObject
    {
        public double ChargeLevel => Battery.Default.ChargeLevel;

        public string EnergySaverStatus => Battery.Default.EnergySaverStatus.ToString();

        public string PowerSource => Battery.Default.PowerSource.ToString();

        public string State => Battery.Default.State.ToString();
    }
}
