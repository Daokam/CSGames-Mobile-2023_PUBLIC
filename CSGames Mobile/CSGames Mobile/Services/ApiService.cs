using System;
using System.Diagnostics;
using System.Text.Json;

namespace CSGames_Mobile.Services;

	public partial class ApiService

	{
        const string apiUri = "http://15.222.250.19/";

		HttpClient _client;
        JsonSerializerOptions _serializerOptions;

		public ApiService()
		{
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        
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


