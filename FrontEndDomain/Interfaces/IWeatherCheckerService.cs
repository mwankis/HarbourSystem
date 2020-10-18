using System.Threading.Tasks;

namespace FrontEndDomain.Interfaces
{
    public interface IWeatherCheckerService
    {
        Task<int> GetWindSpeed();
    }
}
