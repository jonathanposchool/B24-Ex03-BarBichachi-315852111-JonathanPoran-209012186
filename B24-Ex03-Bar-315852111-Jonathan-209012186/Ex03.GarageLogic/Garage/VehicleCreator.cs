namespace Ex03.GarageLogic;
using Vehicles;
using Vehicles.Components;
using Utils;
internal static class VehicleCreator
{
    internal static Motorcycle CreateNewMotorcycle(string i_LicenseNumber, string i_Model, eVehicleTypes i_MotorcycleType, float i_EnergyAvailable, string i_TireManufacturer, float i_TiresAirPressure, eLicenseTypes i_LicenseType, int i_EngineVolume)
    {
        const float maxTirePressure = 33;
        
        Motorcycle newMotorcycle = new Motorcycle();
        newMotorcycle.MaxEnergyCapacity = i_MotorcycleType == eVehicleTypes.RegularCar? 5.5f: 2.5f;
        newMotorcycle.LicenseNumber = i_LicenseNumber;
        newMotorcycle.Model = i_Model;

        validateTirePrussure(i_TiresAirPressure, maxTirePressure);
        List<Tire> tires = createTiresSet(newMotorcycle.NumOfTires, i_TireManufacturer, i_TiresAirPressure, maxTirePressure);
        newMotorcycle.Tires = tires;

        validateEnergyAmount(i_EnergyAvailable, newMotorcycle.MaxEnergyCapacity);
        newMotorcycle.CurrentEnergyAvailable = i_EnergyAvailable;

        Engine motorcycleEngine = new(i_MotorcycleType == eVehicleTypes.RegularCar ? eEngineType.Combustion : eEngineType.Electric,
                                i_MotorcycleType == eVehicleTypes.RegularCar ? eEnergyType.Octan95 : eEnergyType.ElectricalPower);
        newMotorcycle.Engine = motorcycleEngine;

        newMotorcycle.LicenseType = i_LicenseType;
        newMotorcycle.EngineVolume = i_EngineVolume;

        return newMotorcycle;
    }

    internal static Car CreateNewCar(string i_LicenseNumber, string i_Model, eVehicleTypes i_CarType, float i_EnergyAvailable, string i_TireManufacturer, float i_TiresAirPressure, eCarColors i_Color, eCarDoors i_NumOfDoors)
    {
        const float maxTirePressure = 31;
        
        Car newCar = new Car();
        newCar.MaxEnergyCapacity = i_CarType == eVehicleTypes.RegularCar? 45f: 3.5f;
        newCar.LicenseNumber = i_LicenseNumber;
        newCar.Model = i_Model;

        validateTirePrussure(i_TiresAirPressure, maxTirePressure);
        List<Tire> tires = createTiresSet(newCar.NumOfTires, i_TireManufacturer, i_TiresAirPressure, maxTirePressure);
        newCar.Tires = tires;

        validateEnergyAmount(i_EnergyAvailable, newCar.MaxEnergyCapacity);
        newCar.CurrentEnergyAvailable = i_EnergyAvailable;

        Engine carEngine = new(i_CarType == eVehicleTypes.RegularCar ? eEngineType.Combustion : eEngineType.Electric,
                                i_CarType == eVehicleTypes.RegularCar ? eEnergyType.Octan95 : eEnergyType.ElectricalPower);
        newCar.Engine = carEngine;

        newCar.Color = i_Color;
        newCar.NumOfDoors = i_NumOfDoors;

        return newCar;
    }
    
     internal static Truck CreateNewTruck(string i_LicenseNumber, string i_Model, float i_EnergyAvailable, string i_TireManufacturer, float i_TiresAirPressure, bool i_IsCarryingHazardousMaterials, float i_CargoVolume)
    {
        const float maxTirePressure = 28;

        Truck newTruck = new Truck();        
        newTruck.LicenseNumber = i_LicenseNumber;
        newTruck.Model = i_Model;
        
        validateTirePrussure(i_TiresAirPressure, maxTirePressure);
        List<Tire> tires = createTiresSet(newTruck.NumOfTires, i_TireManufacturer, i_TiresAirPressure, maxTirePressure);
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

    private static List<Tire> createTiresSet(int i_NumOfTires, string i_TireManufacturer, float i_TiresAirPressure, float i_MaxTirePressure)
    {
        List<Tire> tires = [];

        for (int i = 0; i < i_NumOfTires; i++)
        {
            Tire tire = new(i_TireManufacturer, i_MaxTirePressure)
            {
                TirePressure = i_TiresAirPressure
            };

            tires.Add(tire);
        }

        return tires;
    }

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private static void setVehicleBaseProprtiesByType(Vehicle i_currVehicle, string i_LicenseNumber, string i_Model, eVehicleTypes i_VehicleType, float i_EnergyAvailable, string i_TiresManufacturer, float i_TiresAirPressure)
    {
        i_currVehicle.LicenseNumber = i_LicenseNumber;
        i_currVehicle.Model = i_Model;
        i_currVehicle.MaxEnergyCapacity = setEnergyCapacityByVehicleType(i_VehicleType);
        validateEnergyAmount(i_EnergyAvailable, i_currVehicle.MaxEnergyCapacity);
        float maxTiresPressure = setMaxTirePressureByVehicleType(i_VehicleType);
        validateTirePrussure(i_TiresAirPressure,maxTiresPressure);
        i_currVehicle.Tires = createTiresSet(i_currVehicle.NumOfTires, i_TiresManufacturer, i_TiresAirPressure, maxTiresPressure);
        i_currVehicle.Engine = createEngninByVehicleType(i_VehicleType);
    }

    internal static Motorcycle CreateNewMotorcycle2(string i_LicenseNumber, string i_Model, eVehicleTypes i_MotorcycleType, float i_EnergyAvailable, string i_TireManufacturer, float i_TireAirPressure, eLicenseTypes i_LicenseType, int i_EngineVolume)
    {
        Motorcycle newMotorcycle = new Motorcycle();
        setVehicleBaseProprtiesByType(newMotorcycle, i_LicenseNumber, i_Model, i_MotorcycleType, i_EnergyAvailable, i_TireManufacturer, i_TireAirPressure);
        
        newMotorcycle.LicenseType = i_LicenseType;
        newMotorcycle.EngineVolume = i_EngineVolume;

        return newMotorcycle;
    }

    internal static Car CreateNewCar2(string i_LicenseNumber, string i_Model, eVehicleTypes i_CarType, float i_EnergyAvailable, string i_TireManufacturer, float i_TireAirPressure, eCarColors i_Color, eCarDoors i_NumOfDoors)
    {
        Car newCar = new Car();
        setVehicleBaseProprtiesByType(newCar, i_LicenseNumber, i_Model, i_CarType, i_EnergyAvailable, i_TireManufacturer, i_TireAirPressure);
        
        newCar.Color = i_Color;
        newCar.NumOfDoors = i_NumOfDoors;

        return newCar;
    }
    
     internal static Truck CreateNewTruck2(string i_LicenseNumber, string i_Model, eVehicleTypes i_TruckType, float i_EnergyAvailable, string i_TireManufacturer, float i_TireAirPressure, bool i_IsCarryingHazardousMaterials, float i_CargoVolume)
    {
       Truck newTruck = new Truck();
        setVehicleBaseProprtiesByType(newTruck, i_LicenseNumber, i_Model, i_TruckType, i_EnergyAvailable, i_TireManufacturer, i_TireAirPressure);
        
        newTruck.IsCarryingHazardousMaterials = i_IsCarryingHazardousMaterials;
        newTruck.CargoVolume = i_CargoVolume;

        return newTruck;
    }

    private static float setEnergyCapacityByVehicleType(eVehicleTypes i_VehicleType)
    {
        //if ussing remove maxEnergyCapacity=120 form Truck
        float maxEnergyCapacity;
        switch (i_VehicleType)
        {
            case eVehicleTypes.RegularMotorcycle:
                maxEnergyCapacity = 5.5f;
                break;
            case eVehicleTypes.ElectricMotorcycle:
                maxEnergyCapacity = 2.5f;
                break;
            case eVehicleTypes.RegularCar:
                maxEnergyCapacity = 45f;
                break;
            case eVehicleTypes.ElectricCar:
                maxEnergyCapacity = 3.5f;
                break;
            case eVehicleTypes.RegularTruck:
                maxEnergyCapacity = 120f;
                break;
            //todo check exception
            case eVehicleTypes.AllTypes:
                throw new Exception($"Hey programmer, you didn't set a type for the vehicle!");
            default:
                throw new Exception($"Hey programmer, you didn't set a maxEnergyCapacity for a {i_VehicleType} type!");
        }

        return maxEnergyCapacity;
    }

    private static float setMaxTirePressureByVehicleType(eVehicleTypes i_VehicleType)
    {
        float maxTirePressure;
        switch (i_VehicleType)
        {
            case eVehicleTypes.RegularMotorcycle:
            case eVehicleTypes.ElectricMotorcycle:
                maxTirePressure = 33f;
                break;
            case eVehicleTypes.RegularCar:
            case eVehicleTypes.ElectricCar:
                maxTirePressure = 31f;
                break;
            case eVehicleTypes.RegularTruck:
                maxTirePressure = 28f;
                break;
            //todo check exception
            case eVehicleTypes.AllTypes:
                throw new Exception($"Hey programmer, you didn't set a type for the vehicle!");
            default:
                throw new Exception($"Hey programmer, you didn't set a maxTirePressure for a {i_VehicleType} type!");
        }

        return maxTirePressure;
    }

    private static Engine createEngninByVehicleType(eVehicleTypes i_VehicleType)
    {
        Engine newEngine = null;
        switch (i_VehicleType)
        {
            case eVehicleTypes.RegularMotorcycle:
                newEngine = new Engine(eEngineType.Combustion,eEnergyType.Octan98);
                break;
            case eVehicleTypes.ElectricMotorcycle:
                newEngine = new Engine(eEngineType.Electric,eEnergyType.ElectricalPower);
                break;
            case eVehicleTypes.RegularCar:
                newEngine = new Engine(eEngineType.Combustion,eEnergyType.Octan95);
                break;
            case eVehicleTypes.ElectricCar:
                newEngine = new Engine(eEngineType.Electric,eEnergyType.ElectricalPower);
                break;
            case eVehicleTypes.RegularTruck:
                newEngine = new Engine(eEngineType.Combustion,eEnergyType.Soler);
                break;
            //todo check exception
            case eVehicleTypes.AllTypes:
                throw new Exception($"Hey programmer, you didn't set a type for the vehicle!");
            default:
                throw new Exception($"Hey programmer, you didn't set a maxEnergyCapacity for a {i_VehicleType} type!");
        }

        return newEngine;
    }
}
