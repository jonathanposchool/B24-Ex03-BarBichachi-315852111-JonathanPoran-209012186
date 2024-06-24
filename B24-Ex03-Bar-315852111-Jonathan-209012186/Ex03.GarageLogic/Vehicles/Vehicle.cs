﻿using System.Dynamic;
using Ex03.GarageLogic.VehicleComponents;
using Ex03.GarageLogic.Utils;

namespace Ex03.GarageLogic.Vehicles
{
    internal abstract class Vehicle
    {
        internal string? Model { get; set; }
        internal string? LicenseNumber { get; set; }
        internal int NumOfTires { get; set;}
        internal List<Tire>? Tires { get; set; }
        internal Engine? Engine { get; set; }
        internal float MaxEnergyCapacity { get; set; }
        internal float CurrentEnergyAvailable { get; set; }

        internal float CurrentEnergyPercentage
        {
            get
            {
                if (MaxEnergyCapacity != 0)
                {
                    return float.Parse(string.Format("{0:0.00}", (CurrentEnergyAvailable / MaxEnergyCapacity) * 100));
                }
                else
                {
                    return 0;
                }
            }
        }

        internal string TiresManufacturer
        {
            // NOTE: This assumes that all tires of the vehicle have the same manufacturer.
            get { return Tires.First().TireManufacturer; }
        }

        internal void FillEnergy(float i_EnergyToFill)
        {
            if ((CurrentEnergyAvailable + i_EnergyToFill) > MaxEnergyCapacity)
            {
                string unit = (Engine.EnergyType == eEnergyType.Electric) ? "hours" : "liters";
                throw new ValueOutOfRangeException($"Not enough capacity to fill up. The maximum capacity is: {MaxEnergyCapacity} {unit}", 0, MaxEnergyCapacity);
            }

            CurrentEnergyAvailable += i_EnergyToFill;
        }
    }
}
