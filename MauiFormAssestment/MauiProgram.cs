using MauiFormAssestment.Data;
using MauiFormAssestment.Views;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.Maui.Storage;

namespace MauiFormAssestment
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
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // create DB path and register EntryDatabase as a singleton
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "entries.db3");
            builder.Services.AddSingleton(s => new EntryDatabase(dbPath));

            // register MainPage so DI can construct it (it depends on EntryDatabase)
            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}