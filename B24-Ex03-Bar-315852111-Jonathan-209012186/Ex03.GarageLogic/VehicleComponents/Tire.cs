namespace Ex03.GarageLogic.VehicleComponents
{
    internal class Tire //TODO make it stract?
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
            m_TirePressure += i_AirPressureToFill;
        }
    }
}
