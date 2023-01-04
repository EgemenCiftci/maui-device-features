using MauiDeviceFeatures.ViewModels;

namespace MauiDeviceFeatures.Views;

public partial class HapticFeedbackPage : ContentPage
{
	public HapticFeedbackPage(HapticFeedbackPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}