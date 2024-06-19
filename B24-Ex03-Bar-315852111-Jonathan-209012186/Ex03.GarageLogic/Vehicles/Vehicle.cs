using Ex03.GarageLogic.VehicleComponents;
using Ex03.GarageLogic.Utils;

namespace Ex03.GarageLogic.Vehicles
{
    internal abstract class Vehicle
    {
        private string m_VehicleModel = string.Empty;
        private string m_LicenseNumber = string.Empty;
        private List<Wheel>? m_VehicleWheels = null;
        private Engine? m_VehicleEngine = null;
        private float m_MaxEnergyCapacity { get; set; }
        private float m_CurrentEnergyAvailable { get; set; }
        public float m_CurrentEnergyPercentage 
        {
            get
            {
                float currentPercentage = 0;

                if (m_MaxEnergyCapacity != 0)
                {
                    currentPercentage = m_CurrentEnergyAvailable / m_MaxEnergyCapacity * 100;
                }

                return (float)Math.Round(currentPercentage, 2);
            }
        }
        public string VehicleModel
        {
            get { return m_VehicleModel; }
            set { m_VehicleModel = value; }
        }
        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }
        public List<Wheel> Wheels
        {
            get { return m_VehicleWheels; }
            set { m_VehicleWheels = value; }
        }
        public Engine Engine
        {
            get { return m_VehicleEngine; }
            set { m_VehicleEngine = value; }
        }

        public abstract void FillUpVehicleEnergy(float i_EnergyToFill, eEngineType i_EngineType = eEngineType.Electricity);
    }
}
