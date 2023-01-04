using MauiDeviceFeatures.ViewModels;

namespace MauiDeviceFeatures.Views;

public partial class DeviceDisplayPage : ContentPage
{
	public DeviceDisplayPage(DeviceDisplayPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}