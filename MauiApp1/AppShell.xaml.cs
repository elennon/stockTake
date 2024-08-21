using MauiApp1.Views;
using System.Windows.Input;

namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
        public ICommand HelpCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }
        void RegisterRoutes()
        {
            Routes.Add("mainPage", typeof(MainPage));
            Routes.Add("login", typeof(Login));
            Routes.Add("newStockTake", typeof(Views.NewStockTake));
            Routes.Add("scanBarcode", typeof(Views.ScanBarcode));
            Routes.Add("sendEmail", typeof(Views.SendEmail));

            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}
