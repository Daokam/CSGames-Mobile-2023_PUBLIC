using System;
using System.Diagnostics;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CSGames_Mobile.Services;

namespace CSGames_Mobile.viewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    Temperature temp;

    ApiService api;

    public MainViewModel(ApiService api)
    {
        this.api = api;
        getTemp();
    }


    [RelayCommand]
    public async void getTemp()
    {
        Temp = (await this.api.GetTemperature());
    }



}

