using MauiApp1.Models;
using System.Collections.ObjectModel;

namespace MauiApp1.Views;

[QueryProperty(nameof(StockTake), "StockTake")]
public partial class SendEmail : ContentPage
{
    StockTake stockTake;
    public ObservableCollection<Items> mks { get; set; } = new ObservableCollection<Items>();
    public StockTake StockTake
    {
        get => stockTake;
        set
        {
            stockTake = value;
            OnPropertyChanged();
        }
    }
    public SendEmail()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        Items items = new Items("Number of meter barcodes scaned", StockTake.barecodeNumber.Count());
        mks.Add(items);
        var stt = StockTake.items.Where(x => x.ItemNumber > 0).ToList();
        foreach (var item in stt)
        {
            mks.Add(item);
        }
        BindingContext = this;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}