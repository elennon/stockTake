using MauiApp1.Views;
using MauiApp1.Helpers;

namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var Foo = UserSettings.IsLoggedIn;

            if (Foo == Boolean.FalseString)
            {
                MainPage = new AppShell();
                GoToLogin();
                //MainPage = new NavigationPage(new UserLogin());
            }
            else
            {
                MainPage = new AppShell();
                //MainPage = new NavigationPage(new UserLogin());
            }
        }
        private async void GoToLogin()
        {
            await Shell.Current.GoToAsync("login");
        }
    }
}
