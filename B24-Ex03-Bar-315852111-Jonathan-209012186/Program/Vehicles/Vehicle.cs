using Program.VehicleComponents;
using static Program.Utils.Enums;

namespace Program.Vehicles
{
    internal abstract class Vehicle
    {
        string m_VehicleModel = string.Empty;
        uint m_LicenseNumber; // DETERMINE IF UINT IS OKAY
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

        public abstract void FillUpVehicleEnergy(float i_EnergyToFill, eEnergyType i_EnergyType = eEnergyType.Electricity);
    }
}
