using System.Drawing;

using Ex03.GarageLogic.Utils;
using Ex03.GarageLogic.VehicleComponents;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        private eLicenseTypes m_LicenseType { get; set; }
        private int m_EngineVolume { get; set; }

        public Motorcycle(string i_LicenseNumber, List<Tire> tires, float maxEnergyCapacity, Engine motorcycleEngine, float i_EnergyAvailable, eLicenseTypes i_LicenseType, int i_EngineVolume)
        {
            // Model
            m_LicenseNumber = i_LicenseNumber;
            m_Tires = tires;
            m_MaxEnergyCapacity = maxEnergyCapacity;
            m_Engine = motorcycleEngine;
            m_CurrentEnergyAvailable = i_EnergyAvailable;
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
        }
    }
}
