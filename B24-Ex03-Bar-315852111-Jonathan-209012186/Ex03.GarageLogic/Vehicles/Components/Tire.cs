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
    }
}
