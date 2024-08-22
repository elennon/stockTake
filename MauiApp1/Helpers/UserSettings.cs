using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MauiApp1.Helpers
{
    public static class UserSettings
    {
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        public static string IsLoggedIn
        {
            get => AppSettings.GetValueOrDefault(nameof(IsLoggedIn), Boolean.FalseString);
            set => AppSettings.AddOrUpdateValue(nameof(IsLoggedIn), value);
        }

        public static string UserName
        {
            get => AppSettings.GetValueOrDefault(nameof(UserName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserName), value);
        }
        public static string SuperV
        {
            get => AppSettings.GetValueOrDefault(nameof(SuperV), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(SuperV), value);
        }
        public static string Email
        {
            get => AppSettings.GetValueOrDefault(nameof(Email), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Email), value);
        }
        public static string Password //{ get; set; }
        {
            get => AppSettings.GetValueOrDefault(nameof(Password), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Password), value);
        }
        public static bool IsFirstTime //{ get; set; }
        {
            get => AppSettings.GetValueOrDefault(nameof(IsFirstTime), true);
            set => AppSettings.AddOrUpdateValue(nameof(IsFirstTime), value);
        }

        public static string WrongPassword { get; set; }

        public static void ClearAllData()
        {
            AppSettings.Clear();
        }

    }
}