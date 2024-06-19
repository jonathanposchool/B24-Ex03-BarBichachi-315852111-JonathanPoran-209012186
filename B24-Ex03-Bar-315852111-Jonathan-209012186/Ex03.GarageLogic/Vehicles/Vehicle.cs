using Ex03.GarageLogic.VehicleComponents;
using static Ex03.GarageLogic.Utils.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    internal abstract class Vehicle
    {
        string m_VehicleModel = string.Empty;
        string m_LicenseNumber = string.Empty;
        List<Wheel> m_VehicleWheels = new List<Wheel>();
        Engine m_VehicleEngine = new Engine();
        float m_MaxEnergyCapacity;
        float m_CurrentEnergyAvailable;

        public float m_CurrentEnergyPercentage
        {
            get
            {
                float currentPercentage = 0;

                if (m_MaxEnergyCapacity != 0)
                {
                    currentPercentage = m_CurrentEnergyAvailable / m_MaxEnergyCapacity * 100;
                }

                return currentPercentage;
            }
        }

        public Vehicle()
        {

        }

        public abstract void FillUpVehicleEnergy(float i_EnergyToFill, eEngineType i_EngineType = eEngineType.Electricity);
    }
}
