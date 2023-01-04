using MauiDeviceFeatures.ViewModels;

namespace MauiDeviceFeatures.Views;

public partial class GeocodingPage : ContentPage
{
	public GeocodingPage(GeocodingPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}