using FrontEndDomain.Interfaces;
using Models.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEndDomain.Implementations
{
    public class WeatherCheckerService : IWeatherCheckerService
    {
        public async Task<int> GetWindSpeed()
        {
            try
            {
                var httpClient = new HttpClient();
                var apiResult = await httpClient.GetAsync("https://harbourcontrolsystemapi.azurewebsites.net/api/v1/WeatherForecast/windspeed");
                var content = await apiResult.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<ApiWeatherForecast>(content);
                return obj.WindSpeed;
            }
            catch (System.Exception)
            {
                return 0;
            }
           
        }
    }
}
