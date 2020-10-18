using Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrontEndDomain.Interfaces
{
    public interface IScheduleService
    {
        Task<List<Ship>> AddShip();
        Task<List<Ship>> FreeHarbour();
        Task<List<Ship>> HarbourBusy();
        Task<List<Ship>> Reset();
        Task<List<Ship>> Get();
    }
}
