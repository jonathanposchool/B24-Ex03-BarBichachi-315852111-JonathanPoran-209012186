using Ex03.GarageLogic.Utils;

namespace Ex03.GarageLogic.Vehicles.Components
{
    internal class Tire
    {
        internal string TireManufacturer { get; }
        internal float MaxTirePressure { get; }
        internal float TirePressure { get; set; } = 0;

        internal Tire (string i_TireManufacturer, float i_MaxTirePressure)
        {
            TireManufacturer = i_TireManufacturer;
            MaxTirePressure = i_MaxTirePressure;
        } 

        internal void FillTirePressure(float i_AirPressureToFill)
        {
            float newTirePressure = TirePressure + i_AirPressureToFill;

            if (newTirePressure > MaxTirePressure)
            {
                throw new ValueOutOfRangeException($"Filling the tire with {i_AirPressureToFill} PSI would exceed the maximum tire pressure of {MaxTirePressure} PSI.", 0, MaxTirePressure);
            }

            TirePressure = newTirePressure;
        }
    }
}
