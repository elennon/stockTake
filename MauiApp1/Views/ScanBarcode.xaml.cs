using Mopups.Services;
using ZXing.Net.Maui;
using MauiApp1.Models;
using System.Collections.Generic;

namespace MauiApp1.Views
{
    [QueryProperty(nameof(StockTake), "StockTake")]
    public partial class ScanBarcode : ContentPage
    {
        int count = 0;
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

        public ScanBarcode()
        {          
            InitializeComponent();
            Configeer();
        }
        protected override void OnAppearing()
        {
            StockTake.barecodeNumber = new List<string>();
        }
        protected override bool OnBackButtonPressed()
        {

            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add(new KeyValuePair<string, object>("StockTake", stockTake));
            Dispatcher.DispatchAsync(async () =>
            {
                await Shell.Current.GoToAsync("mainPage", parms);
                //await Navigation.PopAsync();
            });
            return true;
        }
        private void Configeer()
        {
            cameraBarcodeReaderView.Options = new BarcodeReaderOptions
            {
                Formats = BarcodeFormats.OneDimensional,
                AutoRotate = true,
                Multiple = false
            };
            cameraBarcodeReaderView.IsTorchOn = true;
        }

        protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
        {
            cameraBarcodeReaderView.IsDetecting = false;
            foreach (var barcode in e.Results)
                Console.WriteLine($"Barcodes: {barcode.Format} -> {barcode.Value}");
            var first = e.Results?.FirstOrDefault();
            if (first is null)
                return;
            stockTake.barecodeNumber.Add(first.Value as string);
            count++;
            Dispatcher.DispatchAsync(() =>
            {
                //await DisplayAlert("Barcode detected", first.Value, "OK");
                meterCount.Text = count.ToString() + " meters read";
            });
            MopupService.Instance.PushAsync(new NewPage1());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            cameraBarcodeReaderView.IsDetecting = true;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            IDictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add(new KeyValuePair<string, object>("StockTake", stockTake));
            Dispatcher.DispatchAsync(async () =>
            {
                //await Shell.Current.Navigation.PopAsync//GoToAsync("mainPage", parms);
                await Shell.Current.GoToAsync("..", parms);
            });
        }
    }
}
