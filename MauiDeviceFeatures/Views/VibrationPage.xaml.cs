using MauiDeviceFeatures.ViewModels;

namespace MauiDeviceFeatures.Views;

public partial class VibrationPage : ContentPage
{
	public VibrationPage(VibrationPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}