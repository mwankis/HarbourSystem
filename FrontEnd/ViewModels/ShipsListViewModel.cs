using Models.Models;
using System.Collections.Generic;

namespace FrontEnd.ViewModels
{
    public class ShipsListViewModel
    {
        public bool WindSpeedOk { get; set; } = true;

        public List<Ship> Ships { get; set; } = new List<Ship>();
    }
}
