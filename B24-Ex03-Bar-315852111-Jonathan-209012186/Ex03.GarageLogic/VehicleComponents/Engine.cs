using Ex03.GarageLogic.Utils;

namespace Ex03.GarageLogic.VehicleComponents
{
    internal class Engine
    {
        internal eEngineType m_EngineType { get; }
        internal eEnergyType m_EnergyType { get; }
        
        internal Engine (eEngineType i_EngineType, eEnergyType i_EnergyType)
        {
            m_EngineType = i_EngineType;
            m_EnergyType = i_EnergyType;
        }
    }
}
