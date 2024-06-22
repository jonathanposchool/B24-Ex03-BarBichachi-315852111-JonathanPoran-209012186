namespace Ex03.GarageLogic;
using Vehicles;
using VehicleComponents;
using Utils;
internal static class VehicleCreator
{
    internal static Motorcycle CreateNewMotorcycle(string i_LicenseNumber, string i_Model, eVehicleTypes i_MotorcycleType, float i_EnergyAvailable, string i_TireManufacturer, float i_TireAirPressure, eLicenseTypes i_LicenseType, int i_EngineVolume)
    {
        int numOfTires = 2;
        float maxMotorcycleTirePressure = 31;
        float maxEnergyCapacity = i_MotorcycleType == eVehicleTypes.RegularMotorcycle ? 5.5f : 2.5f;

        if (i_TireAirPressure > maxMotorcycleTirePressure)
        {
            throw new ValueOutOfRangeException("Tire air pressure exceeds maximum allowed for Motorcycle.", 0, maxMotorcycleTirePressure);
        }

        if (i_EnergyAvailable > maxEnergyCapacity)
        {
            throw new ValueOutOfRangeException("Energy available exceeds maximum capacity for Motorcycle.", 0, maxEnergyCapacity);
        }

        if (i_EngineVolume <= 0)
        {
            throw new ArgumentException("Engine volume must be a positive value.");
        }

        List<Tire> tires = createTires(numOfTires, i_TireManufacturer, i_TireAirPressure, maxMotorcycleTirePressure);
        Engine motorcycleEngine = new(i_MotorcycleType == eVehicleTypes.RegularMotorcycle ? eEngineType.Combustion : eEngineType.Electricity,
            i_MotorcycleType == eVehicleTypes.RegularMotorcycle ? eEnergyType.Octan98 : eEnergyType.Electric);

        return new Motorcycle(i_LicenseNumber, i_Model, tires, maxEnergyCapacity, motorcycleEngine, i_EnergyAvailable, i_LicenseType, i_EngineVolume);
    }

    internal static Car CreateNewCar(string i_LicenseNumber, string i_Model, eVehicleTypes i_CarType, float i_EnergyAvailable, string i_TireManufacturer, float i_TireAirPressure, eCarColors i_Color, eCarDoors i_NumOfDoors)
    {
        int numOfTires = 5;
        float maxCarTirePressure = 31;
        float maxEnergyCapacity = (i_CarType == eVehicleTypes.RegularCar ? 45 : 3.5f);

        if (i_TireAirPressure > maxCarTirePressure)
        {
            throw new ValueOutOfRangeException("Tire air pressure exceeds maximum allowed for Car.", 0, maxCarTirePressure);
        }

        if (i_EnergyAvailable > maxEnergyCapacity)
        {
            throw new ValueOutOfRangeException("Energy available exceeds maximum capacity for Car.", 0, maxEnergyCapacity);
        }

        List<Tire> tires = createTires(numOfTires, i_TireManufacturer, i_TireAirPressure, maxCarTirePressure);
        Engine carEngine = new(i_CarType == eVehicleTypes.RegularCar ? eEngineType.Combustion : eEngineType.Electricity,
        i_CarType == eVehicleTypes.RegularCar ? eEnergyType.Octan95 : eEnergyType.Electric);

        return new Car(i_LicenseNumber, i_Model, tires, maxEnergyCapacity, carEngine, i_EnergyAvailable, i_Color, i_NumOfDoors);
    }
    
     internal static Truck CreateNewTruck(string i_LicenseNumber, string i_Model, float i_EnergyAvailable, string i_TireManufacturer, float i_TireAirPressure, bool i_IsCarryingHazardousMaterials, float i_CargoVolume)
    {
        int numOfTruckTires = 12;
        float maxTruckTirePressure = 28;
        float maxEnergyCapacity = 120;

        if (i_TireAirPressure > maxTruckTirePressure)
        {
            throw new ValueOutOfRangeException("Tire air pressure exceeds maximum allowed for Truck.", 0, maxTruckTirePressure);
        }

        if (i_EnergyAvailable > maxEnergyCapacity)
        {
            throw new ValueOutOfRangeException("Energy available exceeds maximum capacity for Truck.", 0, maxEnergyCapacity);
        }

        if (i_CargoVolume <= 0)
        {
            throw new ArgumentException("Cargo volume must be a positive value.");
        }

        List<Tire> tires = createTires(numOfTruckTires, i_TireManufacturer, i_TireAirPressure, maxTruckTirePressure);
        Engine truckEngine = new(eEngineType.Combustion, eEnergyType.Soler);

        return new Truck(i_LicenseNumber, i_Model, tires, maxEnergyCapacity, truckEngine, i_EnergyAvailable, i_IsCarryingHazardousMaterials, i_CargoVolume);
    }

    private static List<Tire> createTires(int i_NumOfTires, string i_TireManufacturer, float i_TireAirPressure, float i_MaxTirePressure)
    {
        List<Tire> tires = [];

        for (int i = 0; i < i_NumOfTires; i++)
        {
            Tire tire = new(i_TireManufacturer, i_MaxTirePressure)
            {
                m_TirePressure = i_TireAirPressure
            };

            tires.Add(tire);
        }

        return tires;
    }
}
