using FrontEnd.ViewModels;
using Models.Models;
using System.Threading.Tasks;

namespace FrontEnd.Interfaces
{
    public interface IBackEndService
    {
        Task<ShipsListViewModel> FreeHarbour();
        Task<ShipsListViewModel> HarbourBusy();
        Task<ShipsListViewModel> AddShips();
        Task Reset();
        Task<ApiWeatherForecast> WeatherInfo();
    }
}
