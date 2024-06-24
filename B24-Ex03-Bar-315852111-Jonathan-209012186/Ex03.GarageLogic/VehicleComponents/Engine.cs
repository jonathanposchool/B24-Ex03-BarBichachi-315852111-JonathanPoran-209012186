using Ex03.GarageLogic.Utils;

namespace Ex03.GarageLogic.VehicleComponents
{
    internal class Engine
    {
        internal eEngineType EngineType { get; } 
        internal eEnergyType EnergyType { get; } 
        
        internal Engine (eEngineType i_EngineType, eEnergyType i_EnergyType)
        {
            EngineType = i_EngineType;
            EnergyType = i_EnergyType;
        }
    }
}
