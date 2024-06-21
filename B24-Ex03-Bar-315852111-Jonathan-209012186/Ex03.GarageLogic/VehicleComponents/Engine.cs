using Ex03.GarageLogic.Utils;

namespace Ex03.GarageLogic.VehicleComponents
{
    internal class Engine //TODO make it stract?
    {
        private eEngineType m_EngineType;
        private eEnergyType m_EnergyType;
        
        internal Engine (eEngineType i_EngineType, eEnergyType i_EnergyType)
        {
            m_EngineType = i_EngineType;
            m_EnergyType = i_EnergyType;
        }

        public eEnergyType EnergyType
        {
            get { return m_EnergyType; }
        }

        public eEngineType EngineType
        {
            get { return m_EngineType; }
        }  
    }
}
