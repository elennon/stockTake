using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class UserDetails : ContentPage
{
	public UserDetails()
	{
		InitializeComponent();
        BindingContext = new UserLoginPageViewModel(Navigation);
    }
}