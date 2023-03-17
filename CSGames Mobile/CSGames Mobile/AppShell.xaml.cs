namespace CSGames_Mobile;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("loadingpage", typeof(LoadingPage));
		Routing.RegisterRoute("mainpage", typeof(MainPage));
	}
}

