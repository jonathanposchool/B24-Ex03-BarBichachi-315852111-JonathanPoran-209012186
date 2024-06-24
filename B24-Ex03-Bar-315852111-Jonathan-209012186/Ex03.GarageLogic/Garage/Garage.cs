namespace Ex03.GarageLogic;
using Vehicles;
using VehicleComponents;
using Utils;

public class Garage
{
    private readonly Dictionary<string, VehicleServiceInfo> r_GarageDatabase = new Dictionary<string, VehicleServiceInfo>();

    private VehicleServiceInfo GetVehicleServiceInfoByLicenseNumber(string i_LicenseNumber)
    {
        if (!r_GarageDatabase.TryGetValue(i_LicenseNumber, out VehicleServiceInfo wantedVehicleServiceInfo))
        {
            throw new ArgumentException("Vehicle with the provided license number does not exist in the database.");
        }

        return wantedVehicleServiceInfo;
    }
    
    private Vehicle getVehicleByLicenseNumber(string i_LicenseNumber)
    {
        return (GetVehicleServiceInfoByLicenseNumber(i_LicenseNumber)).OwnersVehicle;
    }

    public bool IsVehicleInGarage(string i_LicenseNumber)
    {
        return r_GarageDatabase.ContainsKey(i_LicenseNumber);
    }

    public void CreateAndInsertMotorcycleToGarage(string i_LicenseNumber, string i_Model, string i_OwnerName, string i_OwnerPhone, eVehicleTypes i_MotorcycleType, float i_EnergyAvailable, string i_TireManufacturer, float i_TireAirPressure, eLicenseTypes i_LicenseType, int i_EngineVolume)
    {
        Motorcycle newMotorcycle = VehicleCreator.CreateNewMotorcycle(i_LicenseNumber, i_Model, i_MotorcycleType, i_EnergyAvailable, i_TireManufacturer, i_TireAirPressure, i_LicenseType, i_EngineVolume);
        VehicleServiceInfo newMotorcycleServiceInfo = new(i_OwnerName, i_OwnerPhone, newMotorcycle, i_MotorcycleType);

        r_GarageDatabase.Add(i_LicenseNumber, newMotorcycleServiceInfo);
    }

    public void CreateAndInsertCarToGarage(string i_LicenseNumber, string i_Model, string i_OwnerName, string i_OwnerPhone, eVehicleTypes i_CarType, float i_EnergyAvailable, string i_TireManufacturer, float i_TireAirPressure, eCarColors i_Color, eCarDoors i_NumOfDoors)
    {
        Car newCar = VehicleCreator.CreateNewCar(i_LicenseNumber, i_Model, i_CarType, i_EnergyAvailable, i_TireManufacturer, i_TireAirPressure, i_Color, i_NumOfDoors);
        VehicleServiceInfo newCarServiceInfo = new(i_OwnerName, i_OwnerPhone, newCar, i_CarType);

        r_GarageDatabase.Add(i_LicenseNumber, newCarServiceInfo);
    }

    public void CreateAndInsertTruckToGarage(string i_LicenseNumber, string i_Model, string i_OwnerName, string i_OwnerPhone, float i_EnergyAvailable, string i_TireManufacturer, float i_TireAirPressure, bool i_IsCarryingHazardousMaterials, float i_CargoVolume)
    {
        Truck newTruck = VehicleCreator.CreateNewTruck(i_LicenseNumber, i_Model, i_EnergyAvailable, i_TireManufacturer, i_TireAirPressure, i_IsCarryingHazardousMaterials, i_CargoVolume);
        VehicleServiceInfo newTruckServiceInfo = new(i_OwnerName, i_OwnerPhone, newTruck, eVehicleTypes.RegularTruck);

        r_GarageDatabase.Add(i_LicenseNumber, newTruckServiceInfo);
    }

    public void ChangeVehicleStatus(string i_LicenseNumber, eGarageVehicleStatus i_NewStatus)
    {
        if (!r_GarageDatabase.TryGetValue(i_LicenseNumber, out VehicleServiceInfo currentVehicleServiceInfo))
        {
            throw new ArgumentException("Vehicle with the provided license number does not exist in the database.");
        }

        currentVehicleServiceInfo.VehicleStatus = i_NewStatus;
    }

    public List<string> GetLicenseNumbersByFilter(eGarageVehicleStatus i_StatusFilter)
    {
        List<string> listOfLicenseNumberVehicleWithStatusFilter = new List<string>();

        if (r_GarageDatabase != null)
        {
            foreach (KeyValuePair<string, VehicleServiceInfo> element in r_GarageDatabase)
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
        
        if (vehicleToFillEnergy.Engine.EnergyType != i_VehicleEnergyType)
        {
            throw new ArgumentException($"Invalid energy type. Only {vehicleToFillEnergy.Engine.EnergyType} is supported for this vehicle.");
        }

        if ((vehicleToFillEnergy.CurrentEnergyAvailable + i_AmountToRefill) > vehicleToFillEnergy.MaxEnergyCapacity)
        {
            throw new ValueOutOfRangeException("Too much amount of energy.", 0, vehicleToFillEnergy.MaxEnergyCapacity - vehicleToFillEnergy.CurrentEnergyAvailable);
        }

        vehicleToFillEnergy.FillEnergy(i_AmountToRefill);
    }

    public void FillTirePressureToMax(string i_VehicleLicenseNumber)
    {
        // NOTE: This assumes that all tires of the vehicle have the air pressure.
        Vehicle vehicleToFillAirTires = getVehicleByLicenseNumber(i_VehicleLicenseNumber);
        List<Tire> currentVehicleTires = vehicleToFillAirTires.Tires;
        float amountOfAirToReachMax = currentVehicleTires.First().MaxTirePressure - currentVehicleTires.First().TirePressure;

        foreach (Tire tire in currentVehicleTires)
        {
            tire.FillTirePressure(amountOfAirToReachMax);
        }
    }

    public Dictionary<string, string> GetFullVehicleDetails(string i_VehicleLicenseNumber)
    {
        Dictionary<string, string> carInfoMessages = new Dictionary<string, string>();
        VehicleServiceInfo wantedDetailsServiceInfo = GetVehicleServiceInfoByLicenseNumber(i_VehicleLicenseNumber);

        if (wantedDetailsServiceInfo != null)
        {
            Vehicle vehicleToExtractdetails = wantedDetailsServiceInfo.OwnersVehicle;
            carInfoMessages["License Number"] = vehicleToExtractdetails.LicenseNumber;
            carInfoMessages["Model"] = vehicleToExtractdetails.Model;
            carInfoMessages["Vehicle Type"] = wantedDetailsServiceInfo.VehicleType.ToString();
            carInfoMessages["Owner's Name"] = wantedDetailsServiceInfo.OwnersVehicleName;
            carInfoMessages["Owner's Phone"] = wantedDetailsServiceInfo.OwnersVehiclePhone;
            carInfoMessages["Vehicle Status"] = wantedDetailsServiceInfo.VehicleStatus.ToString();
            carInfoMessages["Tires Manufacturer"] = vehicleToExtractdetails.TiresManufacturer;
            carInfoMessages["Tires Info"] = tiresInfo(vehicleToExtractdetails.Tires);

            if (vehicleToExtractdetails.Engine.EngineType == eEngineType.Combustion)
            {
                carInfoMessages["Fuel Type"] = vehicleToExtractdetails.Engine.EnergyType.ToString();
                carInfoMessages["Current Fuel Available"] = vehicleToExtractdetails.CurrentEnergyPercentage.ToString();
            }
            else
            {
                carInfoMessages["Current Energy Available"] = vehicleToExtractdetails.CurrentEnergyPercentage.ToString();
            }

            eVehicleTypes currentVehicleType = wantedDetailsServiceInfo.VehicleType;

            if (currentVehicleType == eVehicleTypes.RegularMotorcycle || currentVehicleType == eVehicleTypes.ElectricMotorcycle)
            {
                Motorcycle motorcycleToExtractdetails = vehicleToExtractdetails as Motorcycle;
                carInfoMessages["License Type"] = motorcycleToExtractdetails.LicenseType.ToString();
                carInfoMessages["Engine Volume"] = motorcycleToExtractdetails.EngineVolume.ToString();
            }
            else if (currentVehicleType == eVehicleTypes.RegularCar || currentVehicleType == eVehicleTypes.ElectricCar)
            {
                Car carToExtractdetails = vehicleToExtractdetails as Car;
                carInfoMessages["Color"] = carToExtractdetails.Color.ToString();
                carInfoMessages["Number of Doors"] = carToExtractdetails.NumOfDoors.ToString();
            }
            else if (currentVehicleType == eVehicleTypes.RegularTruck)
            {
                Truck truckToExtractdetails = vehicleToExtractdetails as Truck;
                carInfoMessages["Carrying Hazardous Materials"] = truckToExtractdetails.IsCarryingHazardousMaterials.ToString();
                carInfoMessages["Cargo Volume"] = truckToExtractdetails.CargoVolume.ToString();
            }
        }

        return carInfoMessages;
    }

    private static string tiresInfo(List<Tire> i_Tires)
    {
        int numOfTire = 1;
        string tiresInfo = string.Empty;
        
        foreach (Tire tire in i_Tires)
        {
            tiresInfo += $"\nTire {numOfTire}: Pressure = {tire.TirePressure}";
            numOfTire++;
        }

        return tiresInfo;
    }
}
