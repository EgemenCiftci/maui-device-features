using MauiDeviceFeatures.ViewModels;

namespace MauiDeviceFeatures.Views;

public partial class DeviceSensorsPage : ContentPage
{
	public DeviceSensorsPage(DeviceSensorsPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}