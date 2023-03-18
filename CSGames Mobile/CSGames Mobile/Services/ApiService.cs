using System;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace CSGames_Mobile.Services
{
	public class ApiService

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
            Uri uri = new Uri(string.Format(apiUri + "temp"));
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

        public async Task<Air> GetAirQuality()
        {
            Uri uri = new Uri(apiUri + "air");
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var json = JsonSerializer.Deserialize<JsonElement>(content);
                    var info = json.GetProperty("information");
                    int airQuality = info.GetProperty("int_air_quality").GetInt32();
                    return new Air(airQuality);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<Water> GetWaterQuality()
        {
            Uri uri = new Uri(apiUri + "water");
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var json = JsonSerializer.Deserialize<JsonElement>(content);
                    var info = json.GetProperty("information");
                    int waterQuality = info.GetProperty("int_water_quality").GetInt32();
                    return new Water(waterQuality);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<Power> GetPower()
        {
            Uri uri = new Uri(apiUri + "power");
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var json = JsonSerializer.Deserialize<JsonElement>(content);
                    var info = json.GetProperty("information");
                    int power = info.GetProperty("power_levels").GetInt32();
                    return new Power(power);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<List<NewsItem>> GetNews()
        {
            Uri uri = new Uri(apiUri + "news");
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var json = JsonSerializer.Deserialize<JsonElement>(content);
                    var newsItems = json.GetProperty("news").EnumerateArray();
                    List<NewsItem> result = new List<NewsItem>();
                    foreach (var item in newsItems)
                    {
                        int id = item.GetProperty("id").GetInt32();
                        string message = item.GetProperty("message").GetString();
                        string title = item.GetProperty("title").GetString();
                        int type = item.GetProperty("type").GetInt32();
                        result.Add(new NewsItem(id, message, title, type));
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<List<TransitItem>> GetTransit()
        {
            Uri uri = new Uri(apiUri + "transit");
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var json = JsonSerializer.Deserialize<JsonElement>(content);
                    var transitArray = json.GetProperty("transit");
                    List<TransitItem> transitItems = new List<TransitItem>();

                    foreach (var transitItemJson in transitArray.EnumerateArray())
                    {
                        int id = transitItemJson.GetProperty("id").GetInt32();
                        int frequency = transitItemJson.GetProperty("frequency").GetInt32();
                        int line = transitItemJson.GetProperty("line").GetInt32();
                        string description = transitItemJson.GetProperty("description").GetString();
                        string schedule = transitItemJson.GetProperty("schedule").GetString();
                        TransitItem transitItem = new TransitItem(id, frequency, line, description, schedule);
                        transitItems.Add(transitItem);
                    }

                    return transitItems;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return null;
        }

        /*public async Task SendSOS(string name, string location)
        {
            Uri uri = new Uri(apiUri + "sos");
            try
            {
                var data = new
                {
                    sos_signal = new
                    {
                        name = name,
                        location = location
                    }
                };
                string jsonData = JsonSerializer.Serialize(data);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("SOS signal sent successfully.");
                }
                else
                {
                    Debug.WriteLine("Failed to send SOS signal.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }*/

    }
}

