using Mopups.Services;
using ZXing.Net.Maui;
using MauiApp1.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MauiApp1.Views;

public partial class NewStockTake : ContentPage
{
    StockTake stockTake = new StockTake();
    public ObservableCollection<Items> mks { get; set; } = new ObservableCollection<Items>();
    public NewStockTake()
	{
		InitializeComponent();
        
        mks.Add(new Items("Meters", 0));
        mks.Add(new Items("Low pressure regulators", 0));
        mks.Add(new Items("High pressure regulators", 0));
        mks.Add(new Items("Resessed doors", 0));
        mks.Add(new Items("Surface boxes", 0));
        foreach (var item in stockTake.SeedItems())
        {
            mks.Add(item);
        }
        
        //lst.ItemsSource = mks;
        BindingContext = this;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        stockTake.items = mks.ToList();
        IDictionary<string, object> parms = new Dictionary<string, object>();
        parms.Add(new KeyValuePair<string, object>("StockTake", stockTake));
        Dispatcher.DispatchAsync(async () =>
        {
            await Shell.Current.GoToAsync("mainPage", parms);
            //await Navigation.PopAsync();
        });
    }
}
