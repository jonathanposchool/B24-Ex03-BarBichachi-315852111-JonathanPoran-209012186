using Ex03.GarageLogic.Utils;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Vehicles.Components;

namespace Ex03.GarageLogic.Garage
{
    internal static class VehicleCreator
    {
        private static void setVehicleBasePropertiesByType(Vehicle i_CurrVehicle, string i_LicenseNumber, string i_Model, eVehicleTypes i_VehicleType, 
                                                           float i_EnergyAvailable, string i_TiresManufacturer, float i_TiresAirPressure)
        {
            i_CurrVehicle.LicenseNumber = i_LicenseNumber;
            i_CurrVehicle.Model = i_Model;

            int numOfTiresToCreate;
            float maxTiresPressure;

            switch (i_VehicleType)
            {
                case eVehicleTypes.RegularMotorcycle:
                    i_CurrVehicle.MaxEnergyCapacity = 5.5f;
                    numOfTiresToCreate = 2;
                    maxTiresPressure = 33f;

                    break;
                case eVehicleTypes.ElectricMotorcycle:
                    i_CurrVehicle.MaxEnergyCapacity = 2.5f;
                    numOfTiresToCreate = 2;
                    maxTiresPressure = 33f;

                    break;
                case eVehicleTypes.RegularCar:
                    i_CurrVehicle.MaxEnergyCapacity = 45f;
                    numOfTiresToCreate = 5;
                    maxTiresPressure = 31f;

                    break;
                case eVehicleTypes.ElectricCar:
                    i_CurrVehicle.MaxEnergyCapacity = 3.5f;
                    numOfTiresToCreate = 5;
                    maxTiresPressure = 31f;

                    break;
                case eVehicleTypes.RegularTruck:
                    i_CurrVehicle.MaxEnergyCapacity = 120f;
                    numOfTiresToCreate = 12;
                    maxTiresPressure = 28f;

                    break;
                default:
                    throw new Exception($"Hey programmer, you didn't set properties for this vehicle!");
            }

            validateEnergyAmount(i_EnergyAvailable, i_CurrVehicle.MaxEnergyCapacity);
            validateTirePressure(i_TiresAirPressure, maxTiresPressure);

            i_CurrVehicle.CurrentEnergyAvailable = i_EnergyAvailable;
            i_CurrVehicle.Tires = createTiresSet(numOfTiresToCreate, i_TiresManufacturer, i_TiresAirPressure, maxTiresPressure);
            i_CurrVehicle.Engine = createEngineByVehicleType(i_VehicleType);
        }

        private static void validateTirePressure(float i_TireAirPressure, float maxTirePressure)
        {
            if (i_TireAirPressure > maxTirePressure)
            {
                throw new ValueOutOfRangeException("Tire air pressure exceeds maximum allowed.", 0, maxTirePressure);
            }
        }

        private static void validateEnergyAmount(float i_EnergyAvailable, float maxEnergyCapacity)
        {
            if (i_EnergyAvailable > maxEnergyCapacity)
            {
                throw new ValueOutOfRangeException("Energy available exceeds maximum capacity.", 0, maxEnergyCapacity);
            }
        }

        private static List<Tire> createTiresSet(int i_NumOfTires, string i_TireManufacturer, float i_TiresAirPressure, float i_MaxTirePressure)
        {
            List<Tire> tires = new List<Tire>();

            for (int i = 0; i < i_NumOfTires; i++)
            {
                Tire tire = new(i_TireManufacturer, i_MaxTirePressure) { TirePressure = i_TiresAirPressure };

                tires.Add(tire);
            }

            return tires;
        }

        private static Engine createEngineByVehicleType(eVehicleTypes i_VehicleType)
        {
            Engine newEngine;

            switch (i_VehicleType)
            {
                case eVehicleTypes.RegularMotorcycle:
                    newEngine = new Engine(eEngineType.Combustion, eEnergyType.Octan98);

                    break;
                case eVehicleTypes.ElectricMotorcycle:
                    newEngine = new Engine(eEngineType.Electric, eEnergyType.ElectricalPower);

                    break;
                case eVehicleTypes.RegularCar:
                    newEngine = new Engine(eEngineType.Combustion, eEnergyType.Octan95);

                    break;
                case eVehicleTypes.ElectricCar:
                    newEngine = new Engine(eEngineType.Electric, eEnergyType.ElectricalPower);

                    break;
                case eVehicleTypes.RegularTruck:
                    newEngine = new Engine(eEngineType.Combustion, eEnergyType.Soler);

                    break;
                default:
                    throw new Exception("Hey programmer, you didn't set an engine for this vehicle!");
            }

            return newEngine;
        }

        internal static Motorcycle CreateNewMotorcycle(string i_LicenseNumber, string i_Model, eVehicleTypes i_MotorcycleType, float i_EnergyAvailable, 
                                                       string i_TireManufacturer, float i_TireAirPressure, eLicenseTypes i_LicenseType, int i_EngineVolume)
        {
            Motorcycle newMotorcycle = new Motorcycle();
            setVehicleBasePropertiesByType(newMotorcycle, i_LicenseNumber, i_Model, i_MotorcycleType, i_EnergyAvailable, i_TireManufacturer, i_TireAirPressure);

            newMotorcycle.LicenseType = i_LicenseType;
            newMotorcycle.EngineVolume = i_EngineVolume;

            return newMotorcycle;
        }

        internal static Car CreateNewCar(string i_LicenseNumber, string i_Model, eVehicleTypes i_CarType, float i_EnergyAvailable, 
                                         string i_TireManufacturer, float i_TireAirPressure, eCarColors i_Color, eCarDoors i_NumOfDoors)
        {
            Car newCar = new Car();
            setVehicleBasePropertiesByType(newCar, i_LicenseNumber, i_Model, i_CarType, i_EnergyAvailable, i_TireManufacturer, i_TireAirPressure);

            newCar.Color = i_Color;
            newCar.NumOfDoors = i_NumOfDoors;

            return newCar;
        }

        internal static Truck CreateNewTruck(string i_LicenseNumber, string i_Model, eVehicleTypes i_TruckType, float i_EnergyAvailable, 
                                             string i_TireManufacturer, float i_TireAirPressure, bool i_IsCarryingHazardousMaterials, float i_CargoVolume)
        {
            Truck newTruck = new Truck();
            setVehicleBasePropertiesByType(newTruck, i_LicenseNumber, i_Model, i_TruckType, i_EnergyAvailable, i_TireManufacturer, i_TireAirPressure);

            newTruck.IsCarryingHazardousMaterials = i_IsCarryingHazardousMaterials;
            newTruck.CargoVolume = i_CargoVolume;

            return newTruck;
        }
    }
}