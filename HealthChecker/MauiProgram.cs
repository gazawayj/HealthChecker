using CommunityToolkit.Maui;
using HealthChecker.ViewModel;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Toolkit.Hosting;


namespace HealthChecker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            }).UseMauiCommunityToolkit();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<MainPageModel>();
            builder.Services.AddSingleton<HealthLogService>();
            builder.Services.AddSingleton<HealthLogViewModel>();

            return builder.Build();
        }
    }
}