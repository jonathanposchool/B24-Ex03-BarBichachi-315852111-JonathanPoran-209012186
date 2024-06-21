using System.Drawing;

using Ex03.GarageLogic.Utils;
using Ex03.GarageLogic.VehicleComponents;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        internal eLicenseTypes m_LicenseType { get; set; }
        internal int m_EngineVolume { get; set; }

        public Motorcycle(string i_LicenseNumber, string i_Model, List<Tire> i_Tires, float i_MaxEnergyCapacity, Engine i_MotorcycleEngine, float i_EnergyAvailable, eLicenseTypes i_LicenseType, int i_EngineVolume)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_Model = i_Model;
            m_Tires = i_Tires;
            m_MaxEnergyCapacity = i_MaxEnergyCapacity;
            m_Engine = i_MotorcycleEngine;
            m_CurrentEnergyAvailable = i_EnergyAvailable;
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
        }
    }
}
