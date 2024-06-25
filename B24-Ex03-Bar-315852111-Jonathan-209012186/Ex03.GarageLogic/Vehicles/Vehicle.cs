using Ex03.GarageLogic.Vehicles.Components;

namespace Ex03.GarageLogic.Vehicles
{
    internal abstract class Vehicle
    {
        internal string? Model { get; set; }
        internal string? LicenseNumber { get; set; }
        internal List<Tire>? Tires { get; set; }
        internal Engine? Engine { get; set; }
        internal float MaxEnergyCapacity { get; set; }
        internal float CurrentEnergyAvailable { get; set; }

        internal float CurrentEnergyPercentage
        {
            get
            {
                float currentEnergyPercentage = 0;

                if (MaxEnergyCapacity != 0)
                {
                    currentEnergyPercentage = (CurrentEnergyAvailable / MaxEnergyCapacity) * 100;
                }
              
                return currentEnergyPercentage;
            }
        }

        internal string TiresManufacturer
        {
            // NOTE: This assumes that all tires of the vehicle have the same manufacturer.
            get
            {
                if (Tires == null || Tires.Count == 0)
                {
                    throw new Exception($"Can't bring the tire manufacturer because the vehicle has no tires!");
                }

                return Tires.First().TireManufacturer;
            }
        }
    }
}
