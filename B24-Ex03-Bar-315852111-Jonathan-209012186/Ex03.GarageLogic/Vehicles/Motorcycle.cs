using Ex03.GarageLogic.Utils;
using Ex03.GarageLogic.VehicleComponents;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        internal eLicenseTypes LicenseType { get; set; } = eLicenseTypes.AllTypes;
        internal int EngineVolume { get; set; } = 0;

        internal Motorcycle()
        {
            NumOfTires = 2;
        }
    }
}
