using MauiDeviceFeatures.ViewModels;

namespace MauiDeviceFeatures.Views;

public partial class GeolocationPage : ContentPage
{
    public GeolocationPage(GeolocationPageViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}