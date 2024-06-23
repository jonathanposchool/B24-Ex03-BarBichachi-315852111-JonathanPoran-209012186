using System.Dynamic;
using Ex03.GarageLogic.VehicleComponents;
using Ex03.GarageLogic.Utils;

namespace Ex03.GarageLogic.Vehicles
{
    internal abstract class Vehicle
    {
        internal string? m_Model { get; set; }
        internal string? m_LicenseNumber { get; set; }
        internal List<Tire> m_Tires { get; set; }
        internal Engine m_Engine { get; set; }
        internal float m_MaxEnergyCapacity { get; set; }
        internal float m_CurrentEnergyAvailable { get; set; }

        internal float CurrentEnergyPercentage
        {
            get
            {
                if (m_MaxEnergyCapacity != 0)
                {
                    return float.Parse(string.Format("{0:0.00}", (m_CurrentEnergyAvailable / m_MaxEnergyCapacity) * 100));
                }
                else
                {
                    return 0;
                }
            }
        }

        internal void FillEnergy(float i_EnergyToFill, eEnergyType i_EnergyType = eEnergyType.Electric)
        {
            if (m_Engine.m_EnergyType != i_EnergyType)
            {
                throw new ArgumentException($"Invalid energy type. Only {m_Engine.m_EnergyType} is supported for this vehicle.");
            }

            if ((m_CurrentEnergyAvailable + i_EnergyToFill) > m_MaxEnergyCapacity)
            {
                string unit = (i_EnergyType == eEnergyType.Electric) ? "hours" : "liters";
                throw new ValueOutOfRangeException($"Not enough capacity to fill up. The maximum capacity is: {m_MaxEnergyCapacity} {unit}", 0, m_MaxEnergyCapacity);
            }

            m_CurrentEnergyAvailable += i_EnergyToFill;
        }

        internal string TiresManufacturer
        {
            // NOTE: This assumes that all tires of the vehicle have the same manufacturer.
            get { return m_Tires[0].m_TireManufacturer; }
        }
    }
}
