using Ex03.GarageLogic.Utils;
using Ex03.GarageLogic.VehicleComponents;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Car : Vehicle
    {
        internal eCarColors Colors { get; set; }
        internal eCarDoors NumOfDoors { get; set; }

        internal Car()
        {
            NumOfTires = 5;
        }
        internal Car(string i_LicenseNumber, string i_Model, List<Tire> i_Tires, float i_MaxEnergyCapacity, Engine i_CarEngine, float i_EnergyAvailable, eCarColors i_Color, eCarDoors i_NumOfDoors)
        {
            LicenseNumber = i_LicenseNumber;
            Model = i_Model;
            Tires = i_Tires;
            MaxEnergyCapacity = i_MaxEnergyCapacity;
            Engine = i_CarEngine;
            CurrentEnergyAvailable = i_EnergyAvailable;
            Colors = i_Color;
            NumOfDoors = i_NumOfDoors;
        }
    }
}
