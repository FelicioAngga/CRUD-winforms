using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTest.API
{
    public class ApiInitializer
    {
        public static HttpClient apiClient { get; set; }

        public ApiInitializer()
        {
            InitializeClient();
        }

        public static void InitializeClient()
        {
            string api = "https://api.openweathermap.org";
            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(api);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
