namespace Ex03.GarageLogic.Vehicles
{
    internal class Truck : Vehicle
    {
        internal bool IsCarryingHazardousMaterials { get; set; } = false;
        internal float CargoVolume { get; set; } = 0;

        internal Truck()
        {
            NumOfTires = 12;
            MaxEnergyCapacity = 120;
        }
    }
}
