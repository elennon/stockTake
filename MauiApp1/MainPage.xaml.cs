using MauiApp1.Models;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Internals;
using Mopups.Services;
using ZXing.Net.Maui;

namespace MauiApp1
{
    [QueryProperty(nameof(StockTake), "StockTake")]
    public partial class MainPage : ContentPage
    {
        StockTake stockTake;
        public StockTake StockTake
        {
            get => stockTake;
            set
            {
                stockTake = value;
                OnPropertyChanged();
            } 
        }
        public MainPage()
        {
            InitializeComponent();
            var yy = StockTake;
        }

        protected override void OnAppearing()
        {
            if (StockTake == null)
            {
                scanButton.IsEnabled = false;
                emailButton.IsEnabled = false;
                return;
            }
            
            if (StockTake.items != null)
            {
                scanButton.IsEnabled = true;
                emailButton.IsEnabled = false;
            }
            if (StockTake.items != null && StockTake.barecodeNumber != null)
            {
                scanButton.IsEnabled = true;
                emailButton.IsEnabled = true;
            }
        }

        private void stockTakeBtn_Clicked(object sender, EventArgs e)
        {
            Dispatcher.DispatchAsync(async () =>
            {
                await Shell.Current.GoToAsync("newStockTake");
            });
        }

        private void scanButton_Clicked(object sender, EventArgs e)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add(new KeyValuePair<string, object>("StockTake", stockTake));
            Dispatcher.DispatchAsync(async () =>
            {
                await Shell.Current.GoToAsync("scanBarcode", parms);
            });
        }

        private void emailButton_Clicked(object sender, EventArgs e)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add(new KeyValuePair<string, object>("StockTake", stockTake));
            Dispatcher.DispatchAsync(async () =>
            {
                await Shell.Current.GoToAsync("sendEmail", parms);
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Dispatcher.DispatchAsync(async () =>
            {
                await Shell.Current.GoToAsync("userDetails");
            });
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Dispatcher.DispatchAsync(async () =>
            {
                await Shell.Current.GoToAsync("userDetails");
            });
        }
    }

}
