namespace Ex03.GarageLogic;
using Vehicles;
using VehicleComponents;
using Utils;

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

    internal VehicleServiceInfo GetVehicleServiceInfoByLicenseNumber(string i_LicenseNumber)
    {
        VehicleServiceInfo wantedVehicleServiceInfo;
        if (m_GarageDatabase.TryGetValue(i_LicenseNumber, out wantedVehicleServiceInfo))
        {
            //return wantedVehicleServiceInfo;
        }
        else
        {
            //todo throw Exception;
        }

        return wantedVehicleServiceInfo;
    }
    
    private Vehicle getVehicleByLicenseNumber(string i_LicenseNumber)
    {
        return (GetVehicleServiceInfoByLicenseNumber(i_LicenseNumber)).OwnersVehicle;
    }

    public void CreateAndInsertMotorcycleToGarage(string i_LicenseNumber, eVehicleTypes i_MotorcycleType, float i_EnergyAvailable, float i_TireAirPressure, eLicenseTypes i_LicenseType, int i_EngineVolume)
    {
        Motorcycle newMotorcycle = CreateNewMotorcycle(i_LicenseNumber, i_MotorcycleType, i_EnergyAvailable, i_TireAirPressure, i_LicenseType, i_EngineVolume);
        VehicleServiceInfo newMotorcycleServiceInfo = new VehicleServiceInfo(newMotorcycle);

        m_GarageDatabase.Add(i_LicenseNumber, newMotorcycleServiceInfo);
    }

    internal Motorcycle CreateNewMotorcycle(string i_LicenseNumber, eVehicleTypes i_MotorcycleType, float i_EnergyAvailable, float i_TireAirPressure, eLicenseTypes i_LicenseType, int i_EngineVolume)
    {
        int numOfTires = 2;
        float maxMotorcycleTirePressure = 31;
        float maxEnergyCapacity = i_MotorcycleType == eVehicleTypes.RegularMotorcycle ? 5.5f : 2.5f;

        if (i_TireAirPressure > maxMotorcycleTirePressure)
        {
            throw new ArgumentException("Tire air pressure exceeds maximum allowed for Motorcycle.");
        }

        List<Tire> tires = createTires(numOfTires, i_TireAirPressure, maxMotorcycleTirePressure);
        Engine motorcycleEngine = new Engine
        {
            EngineType = i_MotorcycleType == eVehicleTypes.RegularMotorcycle ? eEngineType.Combustion : eEngineType.Electricity,
            EnergyType = i_MotorcycleType == eVehicleTypes.RegularMotorcycle ? eEnergyType.Octan98 : eEnergyType.Electric
        };

        return new Motorcycle(i_LicenseNumber, tires, maxEnergyCapacity, motorcycleEngine, i_EnergyAvailable, i_LicenseType, i_EngineVolume);
    }

    public void CreateAndInsertCarToGarage(string i_LicenseNumber, eVehicleTypes i_CarType, float i_EnergyAvailable, float i_TireAirPressure, eCarColors i_Color, eCarDoors i_NumOfDoors)
    {
        Car newCar = CreateNewCar(i_LicenseNumber, i_CarType, i_EnergyAvailable, i_TireAirPressure, i_Color, i_NumOfDoors);
        VehicleServiceInfo newCarServiceInfo = new VehicleServiceInfo(newCar);

        m_GarageDatabase.Add(i_LicenseNumber, newCarServiceInfo);
    }

    internal Car CreateNewCar(string i_LicenseNumber, eVehicleTypes i_CarType, float i_EnergyAvailable, float i_TireAirPressure, eCarColors i_Color, eCarDoors i_NumOfDoors)
    {
        int numOfTires = 5;
        float maxCarTirePressure = 31;
        float maxEnergyCapacity = (i_CarType == eVehicleTypes.RegularCar ? 45 : 3.5f);

        if (i_TireAirPressure > maxCarTirePressure)
        {
            throw new ArgumentException("Tire air pressure exceeds maximum allowed for Car.");
        }

        List<Tire> tires = createTires(numOfTires, i_TireAirPressure, maxCarTirePressure);
        Engine carEngine = new Engine
        {
            EngineType = i_CarType == eVehicleTypes.RegularCar ? eEngineType.Combustion : eEngineType.Electricity,
            EnergyType = i_CarType == eVehicleTypes.RegularCar ? eEnergyType.Octan95 : eEnergyType.Electric
        };

        return new Car(i_LicenseNumber, tires, maxEnergyCapacity, carEngine, i_EnergyAvailable, i_Color, i_NumOfDoors);
    }
    
    public void CreateAndInsertTruckToGarage(string i_LicenseNumber, float i_EnergyAvailable, float i_TireAirPressure, bool i_IsCarryingHazardousMaterials, float i_CargoVolume)
    {
        Truck newTruck = CreateNewTruck(i_LicenseNumber, i_EnergyAvailable, i_TireAirPressure, i_IsCarryingHazardousMaterials, i_CargoVolume);
        VehicleServiceInfo newTruckServiceInfo = new VehicleServiceInfo(newTruck);

        m_GarageDatabase.Add(i_LicenseNumber, newTruckServiceInfo);
    }
    
    internal Truck CreateNewTruck(string i_LicenseNumber, float i_EnergyAvailable, float i_TireAirPressure, bool i_IsCarryingHazardousMaterials, float i_CargoVolume)
    {
        int numOfTruckTires = 12;
        float maxTruckTirePressure = 28;
        float maxEnergyCapacity = 120;

        if (i_TireAirPressure > maxTruckTirePressure)
        {
            throw new ArgumentException("Tire air pressure exceeds maximum allowed for Truck.");
        }

        List<Tire> tires = createTires(numOfTruckTires, i_TireAirPressure, maxTruckTirePressure);
        Engine truckEngine = new Engine();
        truckEngine.EngineType = eEngineType.Combustion;
        truckEngine.EnergyType = eEnergyType.Soler;

        return new Truck(i_LicenseNumber, tires, maxEnergyCapacity, truckEngine, i_EnergyAvailable, i_IsCarryingHazardousMaterials, i_CargoVolume);
    }

    public void ChangeVehicleStatus(string i_LicenseNumber, eGarageVehicleStatus i_NewStatus)
    {
        if (m_GarageDatabase.TryGetValue(i_LicenseNumber, out VehicleServiceInfo currentVehicleServiceInfo))
        {
            currentVehicleServiceInfo.VehicleStatus = i_NewStatus;
        }
        else
        {
            //todo throw new ArgumentException("Vehicle with the provided license number does not exist in the database.");
        }
    }

    public static string[] GetLicenseNumbersByFilter(eGarageVehicleStatus i_UserChoice)
    {
        throw new NotImplementedException();
    }

    private List<Tire> createTires(int i_NumOfTires, float i_TireAirPressure, float i_MaxTirePressure)
    {
        List<Tire> tires = new List<Tire>();

        for (int i = 0; i < i_NumOfTires; i++)
        {
            Tire tire = new Tire();
            tire.m_TirePressure = i_TireAirPressure;
            tire.m_MaxTirePressure = i_MaxTirePressure;
            tires.Add(tire);
        }

        return tires;
    }

    public List<string> ShowAllLicenseNumberVehicleWithStatus(eGarageVehicleStatus i_StatusFilter)
    {
        List<string> listOfLicenseNumberVehicleWithStatusFilter = new List<string>();
        if(m_GarageDatabase != null)
        {
            foreach (KeyValuePair<string, VehicleServiceInfo> element in m_GarageDatabase)
            {
                VehicleServiceInfo currentVehicleServiceInfo = element.Value;
                string currentVehicleLicenseNumber = element.Key;
                if(currentVehicleServiceInfo.VehicleStatus == i_StatusFilter)
                {
                        listOfLicenseNumberVehicleWithStatusFilter.Add(currentVehicleLicenseNumber);
                }
            }
        }

        return listOfLicenseNumberVehicleWithStatusFilter;
    }
    
    public void FillAirToVehicleByLicenseNumber(string i_LicenseNumber, float i_AirPressureToAdd)
    {
        Vehicle vehicleToFillAirTires = getVehicleByLicenseNumber(i_LicenseNumber);
        vehicleToFillAirTires.FillTiresPressure(i_AirPressureToAdd);
    } 

    public void FillEnergyToVehicleByLicenseNumber(string i_LicenseNumber, float i_EnergyToAdd, eEnergyType i_EnergyType)
    {
        Vehicle vehicleToFillEnrgey = getVehicleByLicenseNumber(i_LicenseNumber);
        vehicleToFillEnrgey.FillEnergy(i_EnergyToAdd, i_EnergyType);
    }
}



/*
    
    garage -> fill uo fuel/electricity
*/