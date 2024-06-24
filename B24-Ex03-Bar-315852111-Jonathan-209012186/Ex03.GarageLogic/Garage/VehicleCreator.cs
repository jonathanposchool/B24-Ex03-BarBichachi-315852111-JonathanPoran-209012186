namespace Ex03.GarageLogic;
using Vehicles;
using VehicleComponents;
using Utils;
internal static class VehicleCreator
{
    internal static Motorcycle CreateNewMotorcycle(string i_LicenseNumber, string i_Model, eVehicleTypes i_MotorcycleType, float i_EnergyAvailable, string i_TireManufacturer, float i_TireAirPressure, eLicenseTypes i_LicenseType, int i_EngineVolume)
    {
        const float maxTirePressure = 33;
        
        Motorcycle newMotorcycle = new Motorcycle();
        newMotorcycle.MaxEnergyCapacity = i_MotorcycleType == eVehicleTypes.RegularCar? 5.5f: 2.5f;
        newMotorcycle.LicenseNumber = i_LicenseNumber;
        newMotorcycle.Model = i_Model;

        validateTirePrussure(i_TireAirPressure, maxTirePressure);
        List<Tire> tires = createTires(newMotorcycle.NumOfTires, i_TireManufacturer, i_TireAirPressure, maxTirePressure);
        newMotorcycle.Tires = tires;

        validateEnergyAmount(i_EnergyAvailable, newMotorcycle.MaxEnergyCapacity);
        newMotorcycle.CurrentEnergyAvailable = i_EnergyAvailable;

        Engine motorcycleEngine = new(i_MotorcycleType == eVehicleTypes.RegularCar ? eEngineType.Combustion : eEngineType.Electricity,
                                i_MotorcycleType == eVehicleTypes.RegularCar ? eEnergyType.Octan95 : eEnergyType.Electric);
        newMotorcycle.Engine = motorcycleEngine;

        newMotorcycle.LicenseType = i_LicenseType;
        newMotorcycle.EngineVolume = i_EngineVolume;

        return newMotorcycle;
    }

    internal static Car CreateNewCar(string i_LicenseNumber, string i_Model, eVehicleTypes i_CarType, float i_EnergyAvailable, string i_TireManufacturer, float i_TireAirPressure, eCarColors i_Color, eCarDoors i_NumOfDoors)
    {
        const float maxTirePressure = 31;
        
        Car newCar = new Car();
        newCar.MaxEnergyCapacity = i_CarType == eVehicleTypes.RegularCar? 45f: 3.5f;
        newCar.LicenseNumber = i_LicenseNumber;
        newCar.Model = i_Model;

        validateTirePrussure(i_TireAirPressure, maxTirePressure);
        List<Tire> tires = createTires(newCar.NumOfTires, i_TireManufacturer, i_TireAirPressure, maxTirePressure);
        newCar.Tires = tires;

        validateEnergyAmount(i_EnergyAvailable, newCar.MaxEnergyCapacity);
        newCar.CurrentEnergyAvailable = i_EnergyAvailable;

        Engine carEngine = new(i_CarType == eVehicleTypes.RegularCar ? eEngineType.Combustion : eEngineType.Electricity,
                                i_CarType == eVehicleTypes.RegularCar ? eEnergyType.Octan95 : eEnergyType.Electric);
        newCar.Engine = carEngine;

        newCar.Colors = i_Color;
        newCar.NumOfDoors = i_NumOfDoors;

        return newCar;
    }
    
     internal static Truck CreateNewTruck(string i_LicenseNumber, string i_Model, float i_EnergyAvailable, string i_TireManufacturer, float i_TireAirPressure, bool i_IsCarryingHazardousMaterials, float i_CargoVolume)
    {
        const float maxTirePressure = 28;

        Truck newTruck = new Truck();        
        newTruck.LicenseNumber = i_LicenseNumber;
        newTruck.Model = i_Model;
        
        validateTirePrussure(i_TireAirPressure, maxTirePressure);
        List<Tire> tires = createTires(newTruck.NumOfTires, i_TireManufacturer, i_TireAirPressure, maxTirePressure);
        newTruck.Tires = tires;
        
        validateEnergyAmount(i_EnergyAvailable, newTruck.MaxEnergyCapacity);
        newTruck.CurrentEnergyAvailable = i_EnergyAvailable;

        Engine truckEngine = new(eEngineType.Combustion, eEnergyType.Soler);
        newTruck.Engine = truckEngine;

        newTruck.CargoVolume = i_CargoVolume;
        newTruck.IsCarryingHazardousMaterials = i_IsCarryingHazardousMaterials;

        return newTruck;
    }

    private static void validateTirePrussure(float i_TireAirPressure, float maxTirePressure)
    {
        if (i_TireAirPressure > maxTirePressure)
        {
            throw new ValueOutOfRangeException("Tire air pressure exceeds maximum allowed.", 0, maxTirePressure);
        }
    }

    private static void validateEnergyAmount( float i_EnergyAvailable, float maxEnergyCapacity)
    {
        if (i_EnergyAvailable > maxEnergyCapacity)
        {
            throw new ValueOutOfRangeException("Energy available exceeds maximum capacity.", 0, maxEnergyCapacity);
        }
    }

    private static List<Tire> createTires(int i_NumOfTires, string i_TireManufacturer, float i_TireAirPressure, float i_MaxTirePressure)
    {
        List<Tire> tires = [];

        for (int i = 0; i < i_NumOfTires; i++)
        {
            Tire tire = new(i_TireManufacturer, i_MaxTirePressure)
            {
                TirePressure = i_TireAirPressure
            };

            tires.Add(tire);
        }

        return tires;
    }
}
