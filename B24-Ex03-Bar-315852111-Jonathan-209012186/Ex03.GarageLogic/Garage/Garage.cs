namespace Ex03.GarageLogic;
using Vehicles;
using VehicleComponents;
using Utils;

public class Garage
{
    private Dictionary<string, VehicleServiceInfo> m_GarageDatabase = new Dictionary<string, VehicleServiceInfo>();   

    public bool IsVehicleInGarage(string i_LicenseNumber)
    {
        bool isCarKnownForGarge = false;

        if (m_GarageDatabase.ContainsKey(i_LicenseNumber))
        {
            isCarKnownForGarge = true;
        }

        return isCarKnownForGarge;
    }

    private VehicleServiceInfo GetVehicleServiceInfoByLicenseNumber(string i_LicenseNumber)
    {
        VehicleServiceInfo wantedVehicleServiceInfo;
        if (m_GarageDatabase.TryGetValue(i_LicenseNumber, out wantedVehicleServiceInfo))
        {
            //return wantedVehicleServiceInfo;
        }
        else
        {
            //TODO throw Exception;
        }

        return wantedVehicleServiceInfo;
    }
    
    private Vehicle getVehicleByLicenseNumber(string i_LicenseNumber)
    {
        return (GetVehicleServiceInfoByLicenseNumber(i_LicenseNumber)).OwnersVehicle;
    }

    public void CreateAndInsertMotorcycleToGarage(string i_LicenseNumber, string i_Model, string i_OwnerName, string i_OwnerPhone, eVehicleTypes i_MotorcycleType, float i_EnergyAvailable, string i_TireManufacturer, float i_TireAirPressure, eLicenseTypes i_LicenseType, int i_EngineVolume)
    {
        Motorcycle newMotorcycle = VehicleCreator.CreateNewMotorcycle(i_LicenseNumber, i_Model, i_MotorcycleType, i_EnergyAvailable, i_TireManufacturer, i_TireAirPressure, i_LicenseType, i_EngineVolume);
        VehicleServiceInfo newMotorcycleServiceInfo = new VehicleServiceInfo(i_OwnerName, i_OwnerPhone, newMotorcycle, i_MotorcycleType);

        m_GarageDatabase.Add(i_LicenseNumber, newMotorcycleServiceInfo);
    }

    public void CreateAndInsertCarToGarage(string i_LicenseNumber, string i_Model, string i_OwnerName, string i_OwnerPhone, eVehicleTypes i_CarType, float i_EnergyAvailable, string i_TireManufacturer, float i_TireAirPressure, eCarColors i_Color, eCarDoors i_NumOfDoors)
    {
        Car newCar = VehicleCreator.CreateNewCar(i_LicenseNumber, i_Model, i_CarType, i_EnergyAvailable, i_TireManufacturer, i_TireAirPressure, i_Color, i_NumOfDoors);
        VehicleServiceInfo newCarServiceInfo = new VehicleServiceInfo(i_OwnerName, i_OwnerPhone, newCar, i_CarType);

        m_GarageDatabase.Add(i_LicenseNumber, newCarServiceInfo);
    }
    //vehicleLicenseNumber,
    // vehicleModel,
    // vehicleOwnerName,
    // vehicleOwnerPhone,
    public void CreateAndInsertTruckToGarage(string i_LicenseNumber, string i_Model, string i_OwnerName, string i_OwnerPhone, float i_EnergyAvailable, string i_TireManufacturer, float i_TireAirPressure, bool i_IsCarryingHazardousMaterials, float i_CargoVolume)
    {
        Truck newTruck = VehicleCreator.CreateNewTruck(i_LicenseNumber, i_Model, i_EnergyAvailable, i_TireManufacturer, i_TireAirPressure, i_IsCarryingHazardousMaterials, i_CargoVolume);
        VehicleServiceInfo newTruckServiceInfo = new VehicleServiceInfo(i_OwnerName, i_OwnerPhone, newTruck, eVehicleTypes.RegularTruck);

        m_GarageDatabase.Add(i_LicenseNumber, newTruckServiceInfo);
    }
    
    public void ChangeVehicleStatus(string i_LicenseNumber, eGarageVehicleStatus i_NewStatus)
    {
        if (m_GarageDatabase.TryGetValue(i_LicenseNumber, out VehicleServiceInfo currentVehicleServiceInfo))
        {
            currentVehicleServiceInfo.VehicleStatus = i_NewStatus;
        }
        else
        {
            //TODO throw new ArgumentException("Vehicle with the provided license number does not exist in the database.");
        }
    }

    public List<string> GetLicenseNumbersByFilter(eGarageVehicleStatus i_StatusFilter)
    {
        List<string> listOfLicenseNumberVehicleWithStatusFilter = new List<string>();

        if (m_GarageDatabase != null)
        {
            foreach (KeyValuePair<string, VehicleServiceInfo> element in m_GarageDatabase)
            {
                VehicleServiceInfo currentVehicleServiceInfo = element.Value;
                string currentVehicleLicenseNumber = element.Key;
                if (currentVehicleServiceInfo.VehicleStatus == i_StatusFilter 
                    || i_StatusFilter == eGarageVehicleStatus.AllTypes)
                {
                    listOfLicenseNumberVehicleWithStatusFilter.Add(currentVehicleLicenseNumber);
                }
            }
        }

        return listOfLicenseNumberVehicleWithStatusFilter;
    }

    public void RefuelAVehicle(string i_VehicleLicenseNumber, eEnergyType i_VehicleEnergyType, float i_AmountToRefill)
    {
        Vehicle vehicleToFillEnergy = getVehicleByLicenseNumber(i_VehicleLicenseNumber);
        
        if(vehicleToFillEnergy.m_Engine.EnergyType == i_VehicleEnergyType)
        {
            if ((vehicleToFillEnergy.m_CurrentEnergyAvailable + i_AmountToRefill) <= vehicleToFillEnergy.m_MaxEnergyCapacity)
            {
                vehicleToFillEnergy.FillEnergy(i_AmountToRefill,i_VehicleEnergyType);
            }
            else
            {
            string unit = (i_VehicleEnergyType == eEnergyType.Electric) ? "hours" : "liters";
            throw new Exception($"Too much amount of {i_VehicleEnergyType}. The maximum capacity is: {vehicleToFillEnergy.m_MaxEnergyCapacity} {unit}");
            }
        }
        else
        {
            throw new Exception($"Invalid energy type. Only {vehicleToFillEnergy.m_Engine.EnergyType} is supported for this vehicle.");
        }
    }
    
    public void FillEnergyToVehicleByLicenseNumber(string i_LicenseNumber, float i_EnergyToAdd, eEnergyType i_EnergyType)
    {
        Vehicle vehicleToFillEnrgey = getVehicleByLicenseNumber(i_LicenseNumber);
        vehicleToFillEnrgey.FillEnergy(i_EnergyToAdd, i_EnergyType);
    }

    public void FillTirePressureToMax(string i_VehicleLicenseNumber)
    {
        Vehicle vehicleToFillAirTires = getVehicleByLicenseNumber(i_VehicleLicenseNumber);
        List<Tire> currentVehicleTires = vehicleToFillAirTires.m_Tires;

        foreach(Tire tire in currentVehicleTires)
        {
            float amountOfAirToReachMax = tire.m_MaxTirePressure - tire.m_TirePressure;
            tire.FillTirePressure(amountOfAirToReachMax);
        }
        // {
        //     throw new Exception($"Adding {i_AirPressureToAdd} PSI would exceed the maximum tire pressure of {Tires.First().m_MaxTirePressure} PSI.");
        // }
    }
    
    // public void FillAirToVehicleByLicenseNumber(string i_LicenseNumber, float i_AirPressureToAdd)
    // {
    //     Vehicle vehicleToFillAirTires = getVehicleByLicenseNumber(i_LicenseNumber);
    //     vehicleToFillAirTires.FillTiresPressure(i_AirPressureToAdd);
    // } 
    
    public Dictionary<string, string> GetFullVehicleDetails(string i_VehicleLicenseNumber)
    {
        Dictionary<string, string> carInfoMessages = new Dictionary<string, string>();
        VehicleServiceInfo wantedDetailsServiceInfo = GetVehicleServiceInfoByLicenseNumber(i_VehicleLicenseNumber);

        if(wantedDetailsServiceInfo != null)
        {
            Vehicle vehicleToExtractdetails = wantedDetailsServiceInfo.OwnersVehicle;
            carInfoMessages["License Number"] = vehicleToExtractdetails.m_LicenseNumber;
            carInfoMessages["Model"] = vehicleToExtractdetails.m_Model;
            carInfoMessages["Vehicle Type"] = wantedDetailsServiceInfo.m_VehicleType.ToString();
            carInfoMessages["Owner's Name"] = wantedDetailsServiceInfo.OwnersName;
            carInfoMessages["Owner's Phone"] = wantedDetailsServiceInfo.OwnersPhone;
            carInfoMessages["Vehicle Status"] = wantedDetailsServiceInfo.VehicleStatus.ToString();
            carInfoMessages["Tires Manufacturer"] = vehicleToExtractdetails.TiresManufacturer;
            carInfoMessages["Tires Info"] = TiresInfo(vehicleToExtractdetails.m_Tires);

            if (vehicleToExtractdetails.m_Engine.EngineType == eEngineType.Combustion)
            {
                carInfoMessages["Energy Type"] = vehicleToExtractdetails.m_Engine.EnergyType.ToString();
            }

            carInfoMessages["Current Energy Available"] = vehicleToExtractdetails.CurrentEnergyPercentage + "%";

            //TODO i think we should change it to etch spesipic vehicle function that ui handel
            //adding spesipic vehicle type details:
            eVehicleTypes currentVehicleType = wantedDetailsServiceInfo.m_VehicleType;

            if (currentVehicleType == eVehicleTypes.RegularMotorcycle || currentVehicleType == eVehicleTypes.ElectricMotorcycle)
            {
                Motorcycle motorcycleToExtractdetails = vehicleToExtractdetails as Motorcycle;
                carInfoMessages["License Type"] = motorcycleToExtractdetails.m_LicenseType.ToString();
                carInfoMessages["Engine Volume"] = motorcycleToExtractdetails.m_EngineVolume.ToString();
            }
            else if (currentVehicleType == eVehicleTypes.RegularCar || currentVehicleType == eVehicleTypes.ElectricCar)
            {
                Car carToExtractdetails = vehicleToExtractdetails as Car;
                carInfoMessages["Color"] = carToExtractdetails.m_Colors.ToString();
                carInfoMessages["Number of Doors"] = carToExtractdetails.m_NumOfDoors.ToString();
            }
            else if (currentVehicleType == eVehicleTypes.RegularTruck)
            {
                Truck truckToExtractdetails = vehicleToExtractdetails as Truck;
                carInfoMessages["Carrying Hazardous Materials"] = truckToExtractdetails.m_IsCarryingHazardousMaterials.ToString();
                carInfoMessages["Cargo Volume"] = truckToExtractdetails.m_CargoVolume.ToString();
            }
        }

        return carInfoMessages;
    }

    private string TiresInfo(List<Tire> i_Tires)
    {
        string tiresInfo = string.Empty;
        for (int i = 0; i < i_Tires.Count; i++)
        {
            tiresInfo += $"\nTire {i + 1}: Pressure = {i_Tires[i].m_TirePressure}";
        }

        return tiresInfo;
    }
}
