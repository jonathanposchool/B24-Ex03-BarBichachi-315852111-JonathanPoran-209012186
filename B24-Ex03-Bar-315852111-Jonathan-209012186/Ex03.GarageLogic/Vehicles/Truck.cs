using Ex03.GarageLogic.VehicleComponents;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Truck : Vehicle
    {
        internal bool IsCarryingHazardousMaterials { get; set; } = false;
        internal float CargoVolume { get; set; } = 0;

        internal Truck()
        {
            const int numOfTruckTires = 12;
            const float maxEnergyCapacity = 120;

            MaxEnergyCapacity = maxEnergyCapacity;
            NumOfTires = numOfTruckTires;
        }
    }
}
