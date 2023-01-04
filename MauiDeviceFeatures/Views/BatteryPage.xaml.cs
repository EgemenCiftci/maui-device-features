using MauiDeviceFeatures.ViewModels;

namespace MauiDeviceFeatures.Views;

public partial class BatteryPage : ContentPage
{
	public BatteryPage(BatteryPageViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }
}

