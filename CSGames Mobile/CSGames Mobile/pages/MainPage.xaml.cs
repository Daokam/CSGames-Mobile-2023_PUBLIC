namespace CSGames_Mobile;
using CSGames_Mobile.Services;
using CSGames_Mobile.viewModel;

public partial class MainPage : ContentPage
{



    public MainPage(MainViewModel mv)
    {
        InitializeComponent();
        BindingContext = mv;
    }

}


