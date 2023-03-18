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

    [ObservableProperty]
    Air air;

    [ObservableProperty]
    Water water;

    [ObservableProperty]
    Power power;

    [ObservableProperty]
    List<NewsItem> newsItems;

    [ObservableProperty]
    List<TransitItem> transitItems;

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

    [RelayCommand]
    public async void getAir()
    {
        Air = (await this.api.GetAirQuality());
    }

    [RelayCommand]
    public async void getWater()
    {
        Water = (await this.api.GetWaterQuality());     
    }

    [RelayCommand]
    public async void getPower()
    {
        Power = (await this.api.GetPower());
    }

    [RelayCommand]
    public async void getNews()
    {
        NewsItems = (await this.api.GetNews());
    }

    [RelayCommand]
    public async void getTransit()
    {
        TransitItems = (await this.api.GetTransit());
    }
}

