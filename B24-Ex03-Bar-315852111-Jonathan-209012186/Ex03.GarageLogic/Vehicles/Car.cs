using Ex03.GarageLogic.Utils;
using Ex03.GarageLogic.VehicleComponents;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Car : Vehicle
    {
        internal eCarColors Color { get; set; }
        internal eCarDoors NumOfDoors { get; set; }

        internal Car()
        {
            NumOfTires = 5;
        }
    }
}
