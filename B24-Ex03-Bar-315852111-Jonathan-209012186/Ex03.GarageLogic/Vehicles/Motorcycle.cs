using Ex03.GarageLogic.Utils;

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
