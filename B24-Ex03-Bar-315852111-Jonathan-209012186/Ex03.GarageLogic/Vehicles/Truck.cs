using Ex03.GarageLogic.VehicleComponents;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Truck : Vehicle
    {
        internal bool m_IsCarryingHazardousMaterials { get; set; }
        internal float m_CargoVolume { get; set; }

        internal Truck(string i_LicenseNumber, string i_Model, List<Tire> i_Tires, float i_MaxEnergyCapacity, Engine i_TruckEngine, float i_EnergyAvailable, bool i_IsCarryingHazardousMaterials, float i_CargoVolume)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_Model = i_Model;
            m_Tires = i_Tires;
            m_MaxEnergyCapacity = i_MaxEnergyCapacity;
            m_Engine = i_TruckEngine;
            m_CurrentEnergyAvailable = i_EnergyAvailable;
            m_IsCarryingHazardousMaterials = i_IsCarryingHazardousMaterials;
            m_CargoVolume = i_CargoVolume;
        }
    }
}
