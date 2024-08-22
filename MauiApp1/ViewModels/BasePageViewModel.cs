using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Helpers;

namespace MauiApp1.ViewModels
{
    public class BasePageViewModel : INotifyPropertyChanged
    {
        public INavigation _navigation;
        public string UserName
        {
            get => UserSettings.UserName;
            set
            {
                UserSettings.UserName = value;
                NotifyPropertyChanged("UserName");
            }
        }

        public string IsLoggedIn
        {
            get => UserSettings.IsLoggedIn;
            set
            {
                UserSettings.IsLoggedIn = value;
                NotifyPropertyChanged("IsLoggedIn");
            }
        }
        public string SuperV
        {
            get => UserSettings.SuperV;
            set
            {
                UserSettings.SuperV = value;
                NotifyPropertyChanged("SuperV");
            }
        }
        public string Email
        {
            get => UserSettings.Email;
            set
            {
                UserSettings.Email = value;
                NotifyPropertyChanged("Email");
            }
        }
        public string WrongPassword { get; set; }

        public string Password
        {
            get => UserSettings.Password;
            set
            {
                UserSettings.Password = value;
                NotifyPropertyChanged("Password");
            }
        }
        public bool IsFirstTime
        {
            get => UserSettings.IsFirstTime;
            set
            {
                UserSettings.IsFirstTime = value;
                NotifyPropertyChanged("IsFirstTime");
            }
        }
        #region INotifyPropertyChanged  
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion      
    }
}
