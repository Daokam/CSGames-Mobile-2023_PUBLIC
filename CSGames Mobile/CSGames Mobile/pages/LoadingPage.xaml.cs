namespace CSGames_Mobile;

public partial class LoadingPage : ContentPage
{
	public LoadingPage()
	{
		InitializeComponent();
		changePage();
	}

	async void changePage()
	{
		await Task.Delay(2000);
		await Shell.Current.GoToAsync("mainpage");
	}
}
