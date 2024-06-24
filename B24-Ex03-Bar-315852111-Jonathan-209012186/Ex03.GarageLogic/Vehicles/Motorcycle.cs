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
        internal Motorcycle(string i_LicenseNumber, string i_Model, List<Tire> i_Tires, float i_MaxEnergyCapacity, Engine i_MotorcycleEngine, float i_EnergyAvailable, eLicenseTypes i_LicenseType, int i_EngineVolume)
        {
            LicenseNumber = i_LicenseNumber;
            Model = i_Model;
            Tires = i_Tires;
            MaxEnergyCapacity = i_MaxEnergyCapacity;
            Engine = i_MotorcycleEngine;
            CurrentEnergyAvailable = i_EnergyAvailable;
            LicenseType = i_LicenseType;
            EngineVolume = i_EngineVolume;
        }
    }
}
