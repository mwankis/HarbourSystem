using FrontEnd.Interfaces;
using FrontEnd.ViewModels;
using FrontEndDomain.Interfaces;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Implementations
{
    public class BackEndService : IBackEndService
    {
        private readonly IScheduleService _scheduleService;
        private readonly IWeatherCheckerService _weatherCheckerService;

        public BackEndService(IScheduleService scheduleService, IWeatherCheckerService weatherCheckerService)
        {
            _scheduleService = scheduleService;
            _weatherCheckerService = weatherCheckerService;
        }

        public async Task<ShipsListViewModel> AddShips()
        {
            var ships = await _scheduleService.AddShip();
            return new ShipsListViewModel
            {
                Ships = ships
            };
        }

        public async Task<ShipsListViewModel> FreeHarbour()
        {
            var windspeed = await _weatherCheckerService.GetWindSpeed();
            var list = await _scheduleService.Get();
            if (list == null || list.Count == 0)
            {
                return new ShipsListViewModel();
            }
            ShipsListViewModel viewmodel = null;
            if (list[0].ShipType == ShipType.Sailboat && (windspeed < 10 || windspeed > 30))
            {
                viewmodel = new ShipsListViewModel
                {
                    WindSpeedOk = false,
                    Ships = list
                };
                return  viewmodel;
            }
            var ships = await _scheduleService.FreeHarbour();
            viewmodel = new ShipsListViewModel
            {
                WindSpeedOk = true,
                Ships = ships
            };
            return viewmodel;
        }

        public async Task<ShipsListViewModel> HarbourBusy()
        {
            var windspeed = await _weatherCheckerService.GetWindSpeed();
            var list = await _scheduleService.Get();
            ShipsListViewModel viewmodel = null;
            if (list== null || list.Count == 0)
            {
                return new ShipsListViewModel();
            }
            if (list[0].ShipType == ShipType.Sailboat && (windspeed < 10 || windspeed > 30))
            {
                viewmodel = new ShipsListViewModel
                {
                    WindSpeedOk = false,
                    Ships = list
                };
                return viewmodel;
            }
            var ships = await _scheduleService.HarbourBusy();
            viewmodel = new ShipsListViewModel
            {
                WindSpeedOk = true,
                Ships = ships
            };
            return viewmodel;
        }

        public async Task Reset()
        {
            await _scheduleService.Reset();
        }

        public async Task<ApiWeatherForecast> WeatherInfo()
        {
            var windspeed = await _weatherCheckerService.GetWindSpeed();
            return new ApiWeatherForecast { WindSpeed = windspeed};
        }
    }
}
