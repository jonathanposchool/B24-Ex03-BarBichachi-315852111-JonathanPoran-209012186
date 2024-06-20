using System.Dynamic;
using Ex03.GarageLogic.VehicleComponents;
using Ex03.GarageLogic.Utils;

namespace Ex03.GarageLogic.Vehicles
{
    internal abstract class Vehicle
    {
        // Fields
        protected string? m_Model { get; set; }
        public string? m_LicenseNumber { get; set; }
        protected List<Tire>? m_Tires { get; set; }
        protected Engine? m_Engine { get; set; }
        protected float m_MaxEnergyCapacity { get; set; }
        protected float m_CurrentEnergyAvailable { get; set; }
        protected float m_CurrentEnergyPercentage = 0;

        // Properties
        protected float CurrentEnergyPercentage
        {
            get
            {
                if (m_MaxEnergyCapacity != 0)
                {
                    m_CurrentEnergyPercentage = (m_CurrentEnergyAvailable / m_MaxEnergyCapacity) * 100;
                }

                return (float)Math.Round(m_CurrentEnergyPercentage, 2);
            }
        }

        // Methods
        protected void FillEnergy(float i_EnergyToFill, eEnergyType i_EnergyType = eEnergyType.Electric)
        {

            if (m_Engine.EnergyType == i_EnergyType)
            {
                if ((m_CurrentEnergyAvailable + i_EnergyToFill) <= m_MaxEnergyCapacity)
                {
                    m_CurrentEnergyAvailable += i_EnergyToFill;
                }
                else
                {
                    string unit = (i_EnergyType == eEnergyType.Electric) ? "hours" : "liters";
                    throw new Exception($"Not enough capacity to fill up. The maximum capacity is: {m_MaxEnergyCapacity} {unit}");
                }
            }
            else
            {
                throw new Exception($"Invalid energy type. Only {m_Engine.EnergyType} is supported for this vehicle.");
            }
        }

        protected void FillTirePressure(float i_AirPressureToAdd)
        {
            if ((m_Tires.First().m_TirePressure + i_AirPressureToAdd) <= m_Tires.First().m_MaxTirePressure)
            {
                foreach (Tire tire in m_Tires)
                {
                    tire.FillTirePressure(i_AirPressureToAdd);
                }
            }
            else
            {
                throw new Exception($"Adding {i_AirPressureToAdd} PSI would exceed the maximum tire pressure of {m_Tires.First().m_MaxTirePressure} PSI.");
            }
        }
    }
}
