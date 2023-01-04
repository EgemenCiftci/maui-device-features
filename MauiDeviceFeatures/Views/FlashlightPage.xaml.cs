using MauiDeviceFeatures.ViewModels;

namespace MauiDeviceFeatures.Views;

public partial class FlashlightPage : ContentPage
{
	public FlashlightPage(FlashlightPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}