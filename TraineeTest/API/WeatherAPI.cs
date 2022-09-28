using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;

namespace TraineeTest.API
{
    public class WeatherAPI
    {
        ApiInitializer _apiInitializer = new ApiInitializer();
        string apiKey = "d6600f6bfd7952a7ae098a33d17a5178";

        public async Task<WeatherModelData.root> GetCurrentWeather(string city)
        {
            try
            {
                using (HttpResponseMessage response = await ApiInitializer.apiClient.GetAsync($"/data/2.5/weather?q={city}&units=Metric&appid={apiKey}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var responseValue = JsonSerializer.Deserialize<WeatherModelData.root>(responseBody);
                        return responseValue;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
            catch(Exception) { return new WeatherModelData.root(); }
        }
    }
}
