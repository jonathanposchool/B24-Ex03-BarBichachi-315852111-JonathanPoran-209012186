namespace Ex03.GarageLogic.VehicleComponents
{
    internal class Tire
    {
        public float m_TirePressure { get; set; }
        public float m_MaxTirePressure { get; set; }

        public void FillTirePressure(float i_AirPressureToFill)
        {
            m_TirePressure += i_AirPressureToFill;
        }
    }
}
