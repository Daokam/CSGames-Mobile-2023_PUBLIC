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
    double temp;

    public MainViewModel()
    {
        getTemp();
    }



    async void getTemp()
    {
        Temp = (await GetTemperature()).Ext_water_temp;
    }






    const string apiUri = "http://15.222.250.19/";

    HttpClient _client;
    JsonSerializerOptions _serializerOptions;


    public async Task<Temperature> GetTemperature()
    {
        Uri uri = new Uri(apiUri + "temp");
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var json = JsonSerializer.Deserialize<JsonElement>(content);
                var info = json.GetProperty("information");
                double extWaterTemp = info.GetProperty("ext_water_temp").GetDouble();
                double intTemp = info.GetProperty("int_temp").GetDouble();
                return new Temperature(extWaterTemp, intTemp);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return null;
    }


}

