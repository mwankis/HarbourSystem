using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWindSpeedService _windSpeedService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
            IWindSpeedService windSpeedService)
        {
            _logger = logger;
            _windSpeedService = windSpeedService;
        }

        [HttpGet]
        [Route("windspeed")]
        public async Task<WeatherForecast> Get()
        {
            var windSpeed = await _windSpeedService.GetWindSpeed();
            var rng = new Random();
            var weatherObj = new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                WindSpeed = windSpeed
            };

            return weatherObj;
        }
    }
}
