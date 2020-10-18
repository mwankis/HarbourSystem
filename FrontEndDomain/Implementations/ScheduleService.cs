using FrontEndDomain.Interfaces;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrontEndDomain.Implementations
{
    public class ScheduleService : IScheduleService
    {
        private List<Ship> ships;

        public ScheduleService()
        {
            ships = new List<Ship>();
        }
        public Task<List<Ship>> AddShip()
        {
            for (int i = 0; i < 8; i++)
            {
                var ship = new Ship
                {
                    Position = $"{ships.Count + 1}",
                    Key = $"key{ships.Count + 1}",
                    Name = $"Ship {ships.Count + 1}",
                    ShipType = ShipType.Cargo
                };
                ships.Add(ship);
            }
            RandomiseShipTypes();
            return Task.FromResult(ships);
        }

        public Task<List<Ship>> FreeHarbour()
        {
            ships[0].Status = ShipStatus.Done;
            ships[0].Position = "N/A";

            //swap positions
            Ship temp = ships[0];
            ships.RemoveAt(0);
            ships.Add(temp);

            return Task.FromResult(ships);
        }

        public Task<List<Ship>> Get()
        {
            return Task.FromResult(ships);
        }

        public Task<List<Ship>> HarbourBusy()
        {
            var firstShip = ships[0];
            firstShip.Status = ShipStatus.Offloading;
            firstShip.Position = "0";
            for (int i = 1; i < ships.Count; i++)
            {
                var curShip = ships[i];
                if (curShip.Status == ShipStatus.Waiting)
                {
                    curShip.Position = $"{int.Parse(curShip.Position) - 1}";
                }
            }
            return Task.FromResult(ships);
        }

        public Task<List<Ship>> Reset()
        {
            ships = new List<Ship>();
            return Task.FromResult(ships);
        }

        private void RandomiseShipTypes()
        {
            var shipTypes = new List<ShipType>
            { 
                ShipType.Cargo, ShipType.Sailboat, ShipType.SpeedBoat
            };

            var rn = new Random();
            foreach (var ship in ships)
            {
                var typ = rn.Next(0, 2);
                ship.ShipType = shipTypes[typ];
            }
            
        }
    }
}
