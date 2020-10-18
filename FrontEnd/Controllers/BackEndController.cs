using FrontEnd.Interfaces;
using FrontEnd.ViewModels;
using FrontEndDomain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class BackEndController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBackEndService _backEndService;


        private List<Ship> _ships;
        public BackEndController(ILogger<HomeController> logger, IBackEndService backEndService )
        {
            _logger = logger;
            _backEndService = backEndService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddShips()
        {
            var viewModel = await _backEndService.AddShips();
            return PartialView("ShipsTable", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Reset()
        {
            await _backEndService.Reset();
            return PartialView("Reset");
        }

        [HttpPost]
        public async Task<IActionResult> BusyHarbour()
        {
            var viewmodel = await _backEndService.HarbourBusy();
            return PartialView("ShipsTable", viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> FreeHarbour()
        {
            var viewmodel = await _backEndService.FreeHarbour();
            return PartialView("ShipsTable", viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWindSpeed()
        {
            var viewmodel = await _backEndService.WeatherInfo();
            return PartialView("WindSpeed", viewmodel);
        }
    }
}
