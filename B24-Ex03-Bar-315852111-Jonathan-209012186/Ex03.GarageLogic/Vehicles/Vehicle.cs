using Ex03.GarageLogic.Utils;
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
                    currentEnergyPercentage = (float)Math.Round((CurrentEnergyAvailable / MaxEnergyCapacity) * 100, 2) ;
                }
              
                return currentEnergyPercentage;
            }
        }

        internal string TiresManufacturer
        {
            // NOTE: This assumes that all tires of the vehicle have the same manufacturer.
            get {
                if(Tires == null || Tires.Count == 0)
                {
                    //TODO check exception
                    throw new Exception($"There is no tires exists!");
                }
                return Tires.First().TireManufacturer; 
            }
        }

        internal void FillEnergy(float i_EnergyToFill)
        {
            if ((CurrentEnergyAvailable + i_EnergyToFill) > MaxEnergyCapacity)
            {
                throw new ValueOutOfRangeException($"Not enough capacity to fill up. The maximum capacity is: {MaxEnergyCapacity}!", 0, MaxEnergyCapacity);
            }

            CurrentEnergyAvailable += i_EnergyToFill;
        }
    }
}
