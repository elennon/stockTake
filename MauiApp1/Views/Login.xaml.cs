using MauiApp1.ViewModels;
namespace MauiApp1.Views;

public partial class Login : ContentPage
{
    public static Label label { get; set; }
    public static Entry passWd { get; set; }
    public Login()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetHasBackButton(this, false);
        BindingContext = new UserLoginPageViewModel(Navigation);
        label = label1;
        passWd = passWd1;
    }
}