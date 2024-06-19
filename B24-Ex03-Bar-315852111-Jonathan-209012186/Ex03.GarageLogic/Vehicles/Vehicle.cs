using Ex03.GarageLogic.VehicleComponents;
using Ex03.GarageLogic.Utils;

namespace Ex03.GarageLogic.Vehicles
{
    internal abstract class Vehicle
    {
        // Fields
        protected string m_Model = string.Empty;
        protected string m_LicenseNumber = string.Empty;
        protected List<Tire>? m_Tires = null;
        protected Engine? m_Engine = null;
        protected float m_MaxEnergyCapacity { get; set; }
        protected float m_CurrentEnergyAvailable { get; set; }
        protected float m_CurrentEnergyPercentage = 0;

        // Properties
        protected string Model
        {
            get { return m_Model; }
            set { m_Model = value; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        protected List<Tire> Tires
        {
            get { return m_Tires; }
            set { m_Tires = value; }
        }

        protected Engine Engine
        {
            get { return m_Engine; }
            set { m_Engine = value; }
        }
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
            if ((Tires.First().m_TirePressure + i_AirPressureToAdd) <= Tires.First().m_MaxTirePressure)
            {
                foreach (Tire tire in Tires)
                {
                    tire.FillTirePressure(i_AirPressureToAdd);
                }
            }
            else
            {
                throw new Exception($"Adding {i_AirPressureToAdd} PSI would exceed the maximum tire pressure of {Tires.First().m_MaxTirePressure} PSI.");
            }
        }
    }
}
