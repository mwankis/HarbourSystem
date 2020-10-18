using System;

namespace Models.Models
{
    public class Ship
    {
        public string Position { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public ShipStatus Status { get; set; } = ShipStatus.Waiting;

        public ShipType ShipType { get; set; }

    }

    public enum ShipStatus
    {
        Waiting,
        Offloading,
        Done
    }

    public enum ShipType
    {
        SpeedBoat,
        Sailboat,
        Cargo
    }
}
