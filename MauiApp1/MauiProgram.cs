using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace MauiApp1
{
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
                .ConfigureMopups();
            

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.UseBarcodeReader();
            return builder.Build();
        }
    }
}
