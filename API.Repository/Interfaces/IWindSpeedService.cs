using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Interfaces
{
    public interface IWindSpeedService
    {
        Task<int> GetWindSpeed();
    }
}
