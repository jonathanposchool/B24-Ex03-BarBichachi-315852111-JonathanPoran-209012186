using Ex03.GarageLogic.Utils;

namespace Ex03.GarageLogic.VehicleComponents
{
    internal class Engine
    {
        private eEnergyType m_EnergyType;
        private eEngineType m_EngineType;
        
        public eEnergyType EnergyType
        {
            get { return m_EnergyType; }
            set { m_EnergyType = value; }   
        }
        public eEngineType EngineType
        {
            get { return m_EngineType; }
            set { m_EngineType = value; }   
        }  
    }
}
