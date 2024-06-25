using Ex03.GarageLogic.Utils;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Vehicles.Components;

namespace Ex03.GarageLogic.Garage
{
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
            VehicleServiceInfo wantedVehicleServiceInfo = GetVehicleServiceInfoByLicenseNumber(i_LicenseNumber);

            return wantedVehicleServiceInfo.OwnersVehicle;
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return r_GarageDatabase.ContainsKey(i_LicenseNumber);
        }

        public void CreateAndInsertMotorcycleToGarage(string i_LicenseNumber, string i_Model, string i_OwnerName, string i_OwnerPhone, eVehicleTypes i_MotorcycleType, 
                                                      float i_EnergyAvailable, string i_TiresManufacturer, float i_TiresAirPressure, eLicenseTypes i_LicenseType, int i_EngineVolume)
        {
            Motorcycle newMotorcycle = VehicleCreator.CreateNewMotorcycle(i_LicenseNumber, i_Model, i_MotorcycleType, i_EnergyAvailable,
                i_TiresManufacturer, i_TiresAirPressure, i_LicenseType, i_EngineVolume);
            VehicleServiceInfo newMotorcycleServiceInfo = new(i_OwnerName, i_OwnerPhone, newMotorcycle, i_MotorcycleType);

            r_GarageDatabase.Add(i_LicenseNumber, newMotorcycleServiceInfo);
        }

        public void CreateAndInsertCarToGarage(string i_LicenseNumber, string i_Model, string i_OwnerName, string i_OwnerPhone, eVehicleTypes i_CarType, 
                                               float i_EnergyAvailable, string i_TiresManufacturer, float i_TiresAirPressure, eCarColors i_Color, eCarDoors i_NumOfDoors)
        {
            Car newCar = VehicleCreator.CreateNewCar( i_LicenseNumber, i_Model, i_CarType, i_EnergyAvailable,
                i_TiresManufacturer, i_TiresAirPressure, i_Color, i_NumOfDoors);
            VehicleServiceInfo newCarServiceInfo = new(i_OwnerName, i_OwnerPhone, newCar, i_CarType);

            r_GarageDatabase.Add(i_LicenseNumber, newCarServiceInfo);
        }

        public void CreateAndInsertTruckToGarage(string i_LicenseNumber, string i_Model, string i_OwnerName, string i_OwnerPhone, eVehicleTypes i_TruckType, 
                                                 float i_EnergyAvailable, string i_TiresManufacturer, float i_TiresAirPressure, bool i_IsCarryingHazardousMaterials, float i_CargoVolume)
        {
            Truck newTruck = VehicleCreator.CreateNewTruck(i_LicenseNumber, i_Model, i_TruckType, i_EnergyAvailable,
                i_TiresManufacturer, i_TiresAirPressure, i_IsCarryingHazardousMaterials, i_CargoVolume);
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

                    if ((currentVehicleServiceInfo.VehicleStatus == i_StatusFilter)
                        || (i_StatusFilter == eGarageVehicleStatus.AllTypes))
                    {
                        listOfLicenseNumberVehicleWithStatusFilter.Add(currentVehicleLicenseNumber);
                    }
                }
            }

            return listOfLicenseNumberVehicleWithStatusFilter;
        }

        public void RefuelVehicle(string i_VehicleLicenseNumber, eEnergyType i_VehicleEnergyType, float i_AmountToRefill)
        {
            Vehicle vehicleToRefuel = getVehicleByLicenseNumber(i_VehicleLicenseNumber);

            if (vehicleToRefuel.Engine == null)
            {
                throw new Exception($"The vehicle with this number license - {i_VehicleLicenseNumber}, have no engine.");
            }

            if (vehicleToRefuel.Engine.EnergyType == eEnergyType.ElectricalPower)
            {
                throw new ArgumentException($"You can't refuel a non-combustion vehicle.");
            }

            if (vehicleToRefuel.Engine.EnergyType != i_VehicleEnergyType)
            {
                throw new ArgumentException($"Invalid energy type. Only {vehicleToRefuel.Engine.EnergyType} is supported for this vehicle.");
            }

            if ((vehicleToRefuel.CurrentEnergyAvailable + i_AmountToRefill) > vehicleToRefuel.MaxEnergyCapacity)
            {
                throw new ValueOutOfRangeException("Too much amount of energy.", 0, vehicleToRefuel.MaxEnergyCapacity - vehicleToRefuel.CurrentEnergyAvailable);
            }

            vehicleToRefuel.CurrentEnergyAvailable += i_AmountToRefill;
        }

        public void ChargeVehicle(string i_VehicleLicenseNumber, float i_MinutesToCharge)
        {
            Vehicle vehicleToCharge = getVehicleByLicenseNumber(i_VehicleLicenseNumber);

            if (vehicleToCharge.Engine.EnergyType != eEnergyType.ElectricalPower)
            {
                throw new ArgumentException($"You can't charge a non-combustion vehicle.");
            }

            if ((vehicleToCharge.CurrentEnergyAvailable + i_MinutesToCharge) > vehicleToCharge.MaxEnergyCapacity)
            {
                throw new ValueOutOfRangeException(
                    "You're trying to charge the battery over it's capacity.", 0, (vehicleToCharge.MaxEnergyCapacity - vehicleToCharge.CurrentEnergyAvailable) * 60);
            }

            vehicleToCharge.CurrentEnergyAvailable += (i_MinutesToCharge / 60);
        }

        public void FillTiresPressureToMax(string i_VehicleLicenseNumber)
        {
            // NOTE: This assumes that all tires of the vehicle have the air pressure.
            Vehicle vehicleToFillAirPressure = getVehicleByLicenseNumber(i_VehicleLicenseNumber);

            if ((vehicleToFillAirPressure.Tires == null) || (vehicleToFillAirPressure.Tires.Count == 0))
            {
                throw new Exception($"The vehicle with this number license - {i_VehicleLicenseNumber}, have no tires.");
            }

            List<Tire> currentVehicleTires = vehicleToFillAirPressure.Tires;
            float amountOfAirToReachMax = currentVehicleTires.First().MaxTirePressure - currentVehicleTires.First().TirePressure;

            fillTiresPressure(currentVehicleTires, amountOfAirToReachMax);
        }

        private static void fillTiresPressure(List<Tire> i_Tires, float i_AmountToFill)
        {
            float maxTirePressure = i_Tires.First().MaxTirePressure;
            float newTirePressure = i_Tires.First().TirePressure + i_AmountToFill;

            if (newTirePressure > maxTirePressure)
            {
                throw new ValueOutOfRangeException($"Filling the tire with {i_AmountToFill} PSI would exceed the maximum tire pressure of {maxTirePressure} PSI.", 0, maxTirePressure);
            }

            foreach (Tire tire in i_Tires)
            {
                tire.TirePressure += i_AmountToFill;
            }
        }

        public Dictionary<string, string> GetFullVehicleDetails(string i_VehicleLicenseNumber)
        {
            Dictionary<string, string> carInfoMessages = new Dictionary<string, string>();
            VehicleServiceInfo wantedDetailsServiceInfo = GetVehicleServiceInfoByLicenseNumber(i_VehicleLicenseNumber);

            if (wantedDetailsServiceInfo != null)
            {
                Vehicle vehicleToExtractDetails = wantedDetailsServiceInfo.OwnersVehicle;
                carInfoMessages["License Number"] = vehicleToExtractDetails.LicenseNumber;
                carInfoMessages["Model"] = vehicleToExtractDetails.Model;
                carInfoMessages["Vehicle Type"] = wantedDetailsServiceInfo.VehicleType.ToString();
                carInfoMessages["Owner's Name"] = wantedDetailsServiceInfo.OwnersVehicleName;
                carInfoMessages["Owner's Phone"] = wantedDetailsServiceInfo.OwnersVehiclePhone; // Wasn't mentioned in the assignment, but good to have as part of the vehicle details
                carInfoMessages["Vehicle Status"] = wantedDetailsServiceInfo.VehicleStatus.ToString();
                carInfoMessages["Tires Manufacturer"] = vehicleToExtractDetails.TiresManufacturer;
                carInfoMessages["Tires Info"] = tiresInfo(vehicleToExtractDetails.Tires);

                if (vehicleToExtractDetails.Engine.EngineType == eEngineType.Combustion)
                {
                    carInfoMessages["Fuel Type"] = vehicleToExtractDetails.Engine.EnergyType.ToString();
                    carInfoMessages["Current Fuel Available"] = vehicleToExtractDetails.CurrentEnergyPercentage.ToString();
                }
                else
                {
                    carInfoMessages["Current Energy Available"] = vehicleToExtractDetails.CurrentEnergyPercentage.ToString();
                }

                eVehicleTypes currentVehicleType = wantedDetailsServiceInfo.VehicleType;

                specificVehicleDetails(currentVehicleType, vehicleToExtractDetails, carInfoMessages);
            }

            return carInfoMessages;
        }

        private static void specificVehicleDetails(
            eVehicleTypes i_CurrentVehicleType,
            Vehicle i_VehicleToExtractDetails,
            Dictionary<string, string> i_CarInfoMessages)
        {
            if (i_CurrentVehicleType == eVehicleTypes.RegularMotorcycle
                || i_CurrentVehicleType == eVehicleTypes.ElectricMotorcycle)
            {
                Motorcycle motorcycleToExtractdetails = i_VehicleToExtractDetails as Motorcycle;
                i_CarInfoMessages["License Type"] = motorcycleToExtractdetails.LicenseType.ToString();
                i_CarInfoMessages["Engine Volume"] = motorcycleToExtractdetails.EngineVolume.ToString();
            }
            else if (i_CurrentVehicleType == eVehicleTypes.RegularCar
                     || i_CurrentVehicleType == eVehicleTypes.ElectricCar)
            {
                Car carToExtractdetails = i_VehicleToExtractDetails as Car;
                i_CarInfoMessages["Color"] = carToExtractdetails.Color.ToString();
                i_CarInfoMessages["Number of Doors"] = carToExtractdetails.NumOfDoors.ToString();
            }
            else if (i_CurrentVehicleType == eVehicleTypes.RegularTruck)
            {
                Truck truckToExtractdetails = i_VehicleToExtractDetails as Truck;
                i_CarInfoMessages["Carrying Hazardous Materials"] = truckToExtractdetails.IsCarryingHazardousMaterials.ToString();
                i_CarInfoMessages["Cargo Volume"] = truckToExtractdetails.CargoVolume.ToString();
            }
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
}