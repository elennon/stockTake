using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Helpers;
using System.Windows.Input;
using MauiApp1.Views;
using System.Text.Json;

namespace MauiApp1.ViewModels
{
    public class UserLoginPageViewModel : BasePageViewModel
    {
        public ICommand LoginCommand
        {
            get;
            private set;
        }
        public UserLoginPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            LoginCommand = new Command(() => UpdateUserInfo());
        }
        async void UpdateUserInfo()
        {
            var isfirst = GetPw("FirstTimeLogin").Result;
            if (isfirst == null)
            {
                SetPw("Password", UserSettings.Password).Wait();
                SetPw("FirstTimeLogin", Boolean.FalseString).Wait();
            }
            var pw = GetPw("Password").Result;
            if (pw != UserSettings.Password)
            {
                Login.label.Text = "wrong password";
            }
            else
            {
                Login.label.Text = "";
                //await _navigation.PushAsync(new ProjectsPage()); 
                //await Shell.Current.GoToAsync($"{nameof(CloseUp)}?{nameof(CloseUp.ID)}={"hhh"}");
                //await Shell.Current.Navigation.PopToRootAsync();
                //await Shell.Current.GoToAsync($"{nameof(ProjectsPage)}");
                //await .Navigation.PushModalAsync(new ProjectsPage());PopToRootAsync
                await Shell.Current.GoToAsync("mainPage");
            }

        }
        private async Task<string> GetPw(string key)
        {
            string oauthToken = null;
            try
            {
                //oauthToken = await SecureStorage.GetAsync(key);
                //oauthToken = await SecureStorage.Default.GetAsync(key);
                var someSecureValue = Task.Run(async () => await SecureStorage.Default.GetAsync(key)).Result;
                var f = someSecureValue;
            }
            catch (Exception e)
            {
                var ff = e.InnerException;
            }
            return oauthToken;
        }
        private async Task SetPw(string key, string value)
        {
            try
            {
                //await SecureStorage.SetAsync(key, value);
                var vaue = JsonSerializer.Serialize(value);
                await Task.Run(async () => await SecureStorage.Default.SetAsync(key, vaue));
                
            }
            catch (Exception e)
            {
                var ff = e.InnerException;
            }
        }
    }
}