using API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repository.Implementations
{
    public class WindSpeedService : IWindSpeedService
    {
        public Task<int> GetWindSpeed()
        {
            var windSpeeds = new List<int>
            {
                35, 5 , 12, 20, 22, 24, 25 
            };

            var rnd = new Random();
            var speedIndex = rnd.Next(0,6);

            return Task.FromResult(windSpeeds[speedIndex]);
        }
    }
}
