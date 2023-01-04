using MauiDeviceFeatures.ViewModels;
using MauiDeviceFeatures.Views;
using Microsoft.Extensions.Logging;

namespace MauiDeviceFeatures;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .ConfigureEssentials(async essentials =>
            {
                essentials.UseMapServiceToken(await SecureStorage.Default.GetAsync("mapServiceToken"));
            })
            .RegisterAppServices()
            .RegisterViewModels()
            .RegisterViews()
            .RegisterModels();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        _ = mauiAppBuilder.Services.AddSingleton<AppShell>();

        return mauiAppBuilder;
    }

    private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        _ = mauiAppBuilder.Services.AddTransient<BatteryPageViewModel>();
        _ = mauiAppBuilder.Services.AddTransient<DeviceDisplayPageViewModel>();
        _ = mauiAppBuilder.Services.AddTransient<DeviceInformationPageViewModel>();
        _ = mauiAppBuilder.Services.AddTransient<DeviceSensorsPageViewModel>();
        _ = mauiAppBuilder.Services.AddTransient<FlashlightPageViewModel>();
        _ = mauiAppBuilder.Services.AddTransient<GeocodingPageViewModel>();
        _ = mauiAppBuilder.Services.AddTransient<GeolocationPageViewModel>();
        _ = mauiAppBuilder.Services.AddTransient<HapticFeedbackPageViewModel>();
        _ = mauiAppBuilder.Services.AddTransient<VibrationPageViewModel>();

        return mauiAppBuilder;
    }

    private static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        _ = mauiAppBuilder.Services.AddTransient<BatteryPage>();
        _ = mauiAppBuilder.Services.AddTransient<DeviceDisplayPage>();
        _ = mauiAppBuilder.Services.AddTransient<DeviceInformationPage>();
        _ = mauiAppBuilder.Services.AddTransient<DeviceSensorsPage>();
        _ = mauiAppBuilder.Services.AddTransient<FlashlightPage>();
        _ = mauiAppBuilder.Services.AddTransient<GeocodingPage>();
        _ = mauiAppBuilder.Services.AddTransient<GeolocationPage>();
        _ = mauiAppBuilder.Services.AddTransient<HapticFeedbackPage>();
        _ = mauiAppBuilder.Services.AddTransient<VibrationPage>();

        return mauiAppBuilder;
    }

    private static MauiAppBuilder RegisterModels(this MauiAppBuilder mauiAppBuilder)
    {
        return mauiAppBuilder;
    }
}
