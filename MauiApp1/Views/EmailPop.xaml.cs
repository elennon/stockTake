using Mopups.Pages;
using Mopups.Services;

namespace MauiApp1.Views;

public partial class EmailPop : PopupPage
{
	public EmailPop()
	{
		InitializeComponent();
        BackgroundColor = Color.FromArgb("#80000000");
    }
    private void LoginButton_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }
}