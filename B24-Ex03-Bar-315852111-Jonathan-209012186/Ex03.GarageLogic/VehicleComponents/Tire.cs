namespace Ex03.GarageLogic.VehicleComponents
{
    internal class Tire
    {
        public float m_TirePressure;
        public float m_MaxTirePressure;

        public float TirePressure
        {
            get { return m_TirePressure; }
            set { m_TirePressure = value; }   
        }
        public float MaxTirePressure
        {
            get { return MaxTirePressure; }
            set { MaxTirePressure = value; }   
        }  
        public void FillTirePressure(float i_AirPressureToFill)
        {
            m_TirePressure += i_AirPressureToFill;
        }
    }
}
