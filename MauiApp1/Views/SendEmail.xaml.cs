
using MauiApp1.Models;
using System.Collections.ObjectModel;
using System.IO.Compression;
using MauiApp1.Helpers;

namespace MauiApp1.Views;

[QueryProperty(nameof(StockTake), "StockTake")]
public partial class SendEmail : ContentPage
{
    StockTake stockTake;
    private Gemmers gemmer;
    private string AppFolder => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
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
        gemmer = new Gemmers();
        Items items = new Items("Number of meter barcodes scaned", StockTake.barecodeNumber.Count(), 0);
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
        StockTake stg = new StockTake();
        stg.items = new List<Items>();
        stg.barecodeNumber = new List<string>();
        stg.items.AddRange(mks);
        List<string> toAddress = new List<string>();
        toAddress.Add("elennon@outlook.ie");
        var exfile = gemmer.GetGemmer(StockTake);
        Dispatcher.DispatchAsync(async () =>
        {
            await SendEmailer("feet", "poo", toAddress, exfile);
        });
    }
    public async Task SendEmailer(string subject, string body, List<string> recipients, string filename)
    {
        try
        {
            FileInfo fi = new FileInfo(filename);
            Environment.SetEnvironmentVariable("MONO_URI_DOTNETRELATIVEORABSOLUTE", "true");
            var message = new EmailMessage
            {
                Subject = subject,
                Body = body,
                To = recipients,
            };
            message.Attachments.Add(new EmailAttachment(filename));
            
            await Email.ComposeAsync(message);
        }
        catch (FeatureNotSupportedException fbsEx)
        {
            await DisplayAlert("Alert", "Exception: " + fbsEx.Message, "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Alert", "Exception: " + ex.Message, "OK");
        }
    }
}