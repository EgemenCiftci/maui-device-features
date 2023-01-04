using MauiDeviceFeatures.ViewModels;

namespace MauiDeviceFeatures.Views;

public partial class DeviceInformationPage : ContentPage
{
	public DeviceInformationPage(DeviceInformationPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}