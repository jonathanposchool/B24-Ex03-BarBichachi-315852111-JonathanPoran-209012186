namespace Ex03.GarageLogic.Manufacturing
{
    using VehicleComponents;
    using Vehicles;
    using Utils;

    public class ManufacturingPlant
    {
        readonly float r_MaxRegularMotorcycleEnergyCapacity = 5.5f;
        readonly float r_MaxElectricMotorcycleEnergyCapacity = 2.5f;
        readonly float r_MaxRegularCarEnergyCapacity = 45;
        readonly float r_MaxElectricCarEnergyCapacity = 3.5f;
        readonly float r_MaxTruckEnergyCapacity = 120;

        
        public Motorcycle CreateNewRegularMotorcycle(string i_LicenseNumber, float i_EnergyAvailable, List<Tire> i_VehicleTires)
        {
            //*remainder in ctor of spec vehicle should check air pressure
            Engine newMotorcycleEngine = new Engine(eEnergyType.Octan98, eEngineType.Combustion);
            return new Motorcycle(i_LicenseNumber, i_VehicleTires, r_MaxRegularMotorcycleEnergyCapacity, newMotorcycleEngine, i_EnergyAvailable);
        }
        public Motorcycle CreateNewElectricMotorcycle(string i_LicenseNumber, float i_EnergyAvailable, List<Tire> i_VehicleTires)
        {
            Engine newMotorcycleEngine = new Engine(eEnergyType.Electric, eEngineType.Electricity);
            return new Motorcycle(i_LicenseNumber, i_VehicleTires, r_MaxElectricMotorcycleEnergyCapacity, newMotorcycleEngine, i_EnergyAvailable);
        }
        public Car CreateNewRegularCar(string i_LicenseNumber, float i_EnergyAvailable, List<Tire> i_VehicleTires, eCarColors i_Color, eCarDoors i_NumOfDoors)
        {
            Engine newCarEngine = new Engine(eEnergyType.Octan95, eEngineType.Combustion);
            return new Car(i_LicenseNumber, i_VehicleTires, r_MaxRegularCarEnergyCapacity, newCarEngine, i_EnergyAvailable, i_Color, i_NumOfDoors);
        }
        public Car CreateNewElectricCar(string i_LicenseNumber, float i_EnergyAvailable, List<Tire> i_VehicleTires, eCarColors i_Color, eCarDoors i_NumOfDoors)
        {
            Engine newCarEngine = new Engine(eEnergyType.Electric, eEngineType.Electricity);
            return new Car(i_LicenseNumber, i_VehicleTires, r_MaxElectricCarEnergyCapacity, newCarEngine, i_EnergyAvailable, i_Color, i_NumOfDoors);
        }
        public Truck CreateNewTruck(string i_LicenseNumber, float i_EnergyAvailable, List<Tire> i_VehicleTires, bool i_IsCarryingHazardousMaterials, float i_CargoVolume)
        {
            Engine newCarEngine = new Engine(eEnergyType.Soler, eEngineType.Combustion);
            return new Truck(i_LicenseNumber, i_VehicleTires, r_MaxTruckEnergyCapacity, newCarEngine, i_EnergyAvailable, i_IsCarryingHazardousMaterials, i_CargoVolume);
        }
    }
}
