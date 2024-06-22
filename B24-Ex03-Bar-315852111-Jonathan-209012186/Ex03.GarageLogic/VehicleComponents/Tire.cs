using Ex03.GarageLogic.Utils;

namespace Ex03.GarageLogic.VehicleComponents
{
    internal class Tire
    {
        internal string m_TireManufacturer { get; }
        internal float m_MaxTirePressure { get; }
        internal float m_TirePressure { get; set; }

        internal Tire (string i_TireManufacturer, float i_MaxTirePressure)
        {
            m_TireManufacturer = i_TireManufacturer;
            m_MaxTirePressure = i_MaxTirePressure;
        } 

        internal void FillTirePressure(float i_AirPressureToFill)
        {
            float newTirePressure = m_TirePressure + i_AirPressureToFill;

            if (newTirePressure > m_MaxTirePressure)
            {
                throw new ValueOutOfRangeException($"Filling the tire with {i_AirPressureToFill} PSI would exceed the maximum tire pressure of {m_MaxTirePressure} PSI.", 0, m_MaxTirePressure);
            }

            m_TirePressure = newTirePressure;
        }
    }
}
