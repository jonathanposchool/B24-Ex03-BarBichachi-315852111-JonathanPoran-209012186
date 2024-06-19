namespace Ex03.GarageLogic;
using Vehicles;
using VehicleComponents;
using Utils;
using System.Globalization;

public class Garage
{
    private Dictionary<string, VehicleServiceInfo> m_GarageDatabase = new Dictionary<string, VehicleServiceInfo>();   
    
    public bool IsVehicleInGarage(string i_LicenseNumber)
    {
        bool carIsNotKnownForGarge = true;
        if (m_GarageDatabase.ContainsKey(i_LicenseNumber))
        {
            carIsNotKnownForGarge = false;
        }
        return carIsNotKnownForGarge;
    }


    public VehicleServiceInfo GetVehicleByLicenseNumber(string i_LicenseNumber)
    {
        if (m_GarageDatabase.TryGetValue(i_LicenseNumber, out VehicleServiceInfo wantedVehicleServiceInfo))
        {
            return wantedVehicleServiceInfo;
        }
        else
        {
            // TODO to do to-do To-do To-Do ToDo 
            throw new Exception("//Todo");
        }
    }

    public Motorcycle CreateNewRegularMotorcycle(string i_LicenseNumber, float i_EnergyAvailable, float i_TireAirPressure, eLicenseType i_LicenseType, int i_EngineVolume)
    {
        int numOfTires = 2;
        float maxRegularMotorcycleEnergyCapacity = 5.5f;
        List<Tire> tires = createTires(numOfTires,i_TireAirPressure);
        
        Engine newMotorcycleEngine = new Engine(eEnergyType.Octan98, eEngineType.Combustion);
        return new Motorcycle(i_LicenseNumber, i_VehicleTires, maxRegularMotorcycleEnergyCapacity, newMotorcycleEngine, i_EnergyAvailable, i_LicenseType, i_EngineVolume);
    }
    public Motorcycle CreateNewElectricMotorcycle(string i_LicenseNumber, float i_EnergyAvailable, float i_TireAirPressure, eLicenseType i_LicenseType, int i_EngineVolume)
    {
        int numOfTires = 2;
        float maxElectricMotorcycleEnergyCapacity = 2.5f;
        List<Tire> tires = createTires(numOfTires,i_TireAirPressure);

        Engine newMotorcycleEngine = new Engine(eEnergyType.Electric, eEngineType.Electricity);
        return new Motorcycle(i_LicenseNumber, i_VehicleTires, maxElectricMotorcycleEnergyCapacity, newMotorcycleEngine, i_EnergyAvailable, i_LicenseType, i_EngineVolume);
    }
    public Car CreateNewRegularCar(string i_LicenseNumber, float i_EnergyAvailable, float i_TireAirPressure, eCarColors i_Color, eCarDoors i_NumOfDoors)
    {
        int numOfTires = 5;
        float maxRegularCarEnergyCapacity = 45;
        List<Tire> tires = createTires(numOfTires,i_TireAirPressure);

        Engine newCarEngine = new Engine(eEnergyType.Octan95, eEngineType.Combustion);
        return new Car(i_LicenseNumber, i_VehicleTires, maxRegularCarEnergyCapacity, newCarEngine, i_EnergyAvailable, i_Color, i_NumOfDoors);
    }
    public Car CreateNewElectricCar(string i_LicenseNumber, float i_EnergyAvailable, float i_TireAirPressure, eCarColors i_Color, eCarDoors i_NumOfDoors)
    {
        int numOfTires = 5;
        float maxElectricCarEnergyCapacity = 3.5f;
        List<Tire> tires = createTires(numOfTires,i_TireAirPressure);

        Engine newCarEngine = new Engine(eEnergyType.Electric, eEngineType.Electricity);
        return new Car(i_LicenseNumber, tires, maxElectricCarEnergyCapacity, newCarEngine, i_EnergyAvailable, i_Color, i_NumOfDoors);
    }
    public Truck CreateNewTruck(string i_LicenseNumber, float i_EnergyAvailable, float i_TireAirPressure, bool i_IsCarryingHazardousMaterials, float i_CargoVolume)
    {
        int numOfTires = 12;
        float maxTruckEnergyCapacity = 120;
        List<Tire> tires = createTires(numOfTires,i_TireAirPressure);

        Engine newCarEngine = new Engine(eEnergyType.Soler, eEngineType.Combustion);
        return new Truck(i_LicenseNumber, i_VehicleTires, maxTruckEnergyCapacity, newCarEngine, i_EnergyAvailable, i_IsCarryingHazardousMaterials, i_CargoVolume);
    }

    public eGarageVehicleStatus ChangeVehicleStatus(string i_LicenseNumber)
    {
        if(m_GarageDatabase.TryGetValue(i_LicenseNumber,out VehicleServiceInfo currentVehicleServiceInfo))
    }

    public static List<eVehicleTypes> GetAllVehicleTypes()
    {
        List<eVehicleTypes> allVehicleTypes = new List<eVehicleTypes>();

        foreach (eVehicleTypes type in Enum.GetValues(typeof(eVehicleTypes)))
        {
            allVehicleTypes.Add(type);
        }

        return allVehicleTypes;
    }
}



/*
        insert new car to Garage
        show garge vehicle list status with filters
        Garage change status
        Garage -> fill up air wheel to max
        garage -> fill uo fuel/electricity
*/