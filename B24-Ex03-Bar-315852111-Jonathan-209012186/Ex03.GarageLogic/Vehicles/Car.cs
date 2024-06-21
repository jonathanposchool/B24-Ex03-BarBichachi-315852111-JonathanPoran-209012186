using Ex03.GarageLogic.Utils;
using Ex03.GarageLogic.VehicleComponents;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Car : Vehicle
    {
        internal eCarColors m_Colors { get; set; }
        internal eCarDoors m_NumOfDoors { get; set; }

        public Car(string i_LicenseNumber, List<Tire> tires, float maxEnergyCapacity, Engine carEngine, float i_EnergyAvailable, eCarColors i_Color, eCarDoors i_NumOfDoors)
        {
            // Model
            m_LicenseNumber = i_LicenseNumber;
            m_Tires = tires;
            m_MaxEnergyCapacity = maxEnergyCapacity;
            m_Engine = carEngine;
            m_CurrentEnergyAvailable = i_EnergyAvailable;
            m_Colors = i_Color;
            m_NumOfDoors = i_NumOfDoors;
        }
    }
}
