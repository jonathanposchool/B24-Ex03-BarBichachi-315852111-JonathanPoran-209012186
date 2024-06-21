using Ex03.GarageLogic.Utils;
using Ex03.GarageLogic.VehicleComponents;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Car : Vehicle
    {
        internal eCarColors m_Colors { get; set; }
        internal eCarDoors m_NumOfDoors { get; set; }

        public Car(string i_LicenseNumber, string i_Model, List<Tire> i_Tires, float i_MaxEnergyCapacity, Engine i_CarEngine, float i_EnergyAvailable, eCarColors i_Color, eCarDoors i_NumOfDoors)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_Model = i_Model;
            m_Tires = i_Tires;
            m_MaxEnergyCapacity = i_MaxEnergyCapacity;
            m_Engine = i_CarEngine;
            m_CurrentEnergyAvailable = i_EnergyAvailable;
            m_Colors = i_Color;
            m_NumOfDoors = i_NumOfDoors;
        }
    }
}
