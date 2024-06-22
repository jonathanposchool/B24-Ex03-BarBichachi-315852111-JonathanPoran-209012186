using Ex03.ConsoleUI;

// TODO:
/*
 * unused methods/functions
 * unused variables
 * unused get/sets
 * seald/public/protected/internal/private
 * Exceptions
 * Duplications of code (for example fill tire in vehicle and in tire)
 * usage of necessary things such as string format, etc
 */

class Program
{
    static void Main()
    {
        GarageApplication jbGarageApplication = new GarageApplication();
        jbGarageApplication.RunGarageManagementSystem();
    }

    //static void Main()
    //{
    //    Garage jbGarage = new Garage();
    //    bool isFinished = false;

    //    while (!isFinished)
    //    {
    //        int menuChoice = ConsoleUI.PrintMenuAndGetChoice();

    //        switch (menuChoice)
    //        {
    //            case 1:
    //                {
    //                    string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");

    //                    if (jbGarage.IsVehicleInGarage(vehicleLicenseNumber))
    //                    {
    //                        jbGarage.ChangeVehicleStatus(vehicleLicenseNumber, eGarageVehicleStatus.ServiceInProgress);
    //                        ConsoleUI.VehicleIsAlreadyInGarage();
    //                    }
    //                    else
    //                    {
    //                        string vehicleOwnerName = ConsoleUI.GetUserStringInputWithMessage("name");
    //                        string vehicleOwnerPhone = ConsoleUI.GetUserStringInputWithMessage("phone number");
    //                        bool isVehicleCreated = false;

    //                        do
    //                        {
    //                            eVehicleTypes selectedVehicleType = ConsoleUI.GetVehicleType();
    //                            string vehicleModel = ConsoleUI.GetUserStringInputWithMessage("vehicle model");
    //                            string vehicleTiresManufacturer = ConsoleUI.GetUserStringInputWithMessage("tires manufacturer");
    //                            float vehicleCurrentTiresPressure = ConsoleUI.GetUserNumericInputWithMessage<float>("current tires PSI (air pressure)");
    //                            float vehicleCurrentEnergy = ConsoleUI.GetVehicleEnergy(selectedVehicleType);

    //                            try
    //                            {
    //                                switch (selectedVehicleType)
    //                                {
    //                                    case eVehicleTypes.RegularMotorcycle:
    //                                    case eVehicleTypes.ElectricMotorcycle:
    //                                        eLicenseTypes licenseType = ConsoleUI.GetLicenseType();
    //                                        int engineVolume = ConsoleUI.GetEngineVolume();

    //                                        jbGarage.CreateAndInsertMotorcycleToGarage(vehicleLicenseNumber, vehicleModel, vehicleOwnerName, vehicleOwnerPhone,
    //                                            selectedVehicleType, vehicleCurrentEnergy, vehicleTiresManufacturer, vehicleCurrentTiresPressure, 
    //                                            licenseType, engineVolume);

    //                                        isVehicleCreated = true; // TODO (IsVehicleCreated = CreateAndInsert) BOOL

    //                                        break;
    //                                    case eVehicleTypes.RegularCar:
    //                                    case eVehicleTypes.ElectricCar:
    //                                        eCarColors carColor = ConsoleUI.GetVehicleColor();
    //                                        eCarDoors carNumOfDoors = ConsoleUI.GetVehicleNumOfDoors();

    //                                        jbGarage.CreateAndInsertCarToGarage(vehicleLicenseNumber, vehicleModel, vehicleOwnerName, vehicleOwnerPhone,
    //                                            selectedVehicleType, vehicleCurrentEnergy, vehicleTiresManufacturer, vehicleCurrentTiresPressure,
    //                                            carColor, carNumOfDoors);

    //                                        isVehicleCreated = true; // TODO (IsVehicleCreated = CreateAndInsert) BOOL

    //                                        break;
    //                                    case eVehicleTypes.RegularTruck:
    //                                        bool isCarryingHazardous = ConsoleUI.IsCarryingHazardous();
    //                                        float truckCargoVolume = ConsoleUI.GetCargoVolume();

    //                                        jbGarage.CreateAndInsertTruckToGarage(vehicleLicenseNumber, vehicleModel, vehicleOwnerName, vehicleOwnerPhone,
    //                                            vehicleCurrentEnergy, vehicleTiresManufacturer, vehicleCurrentTiresPressure, isCarryingHazardous, truckCargoVolume);

    //                                        isVehicleCreated = true; // TODO (IsVehicleCreated = CreateAndInsert) BOOL

    //                                        break;
    //                                }
    //                            }
    //                            catch (Exception ex)
    //                            {
    //                                Console.WriteLine($"An error occurred: {ex.Message}");
    //                            }

    //                            ConsoleUI.VehicleCreationAttempt(isVehicleCreated);
    //                        }
    //                        while (!isVehicleCreated);
    //                    }

    //                    isFinished = ConsoleUI.IsReturningToMainMenu();
    //                }

    //                break;
    //            case 2:
    //                {
    //                    eGarageVehicleStatus vehicleStatusFilter = ConsoleUI.GetValidOptionChoiceByEnum<eGarageVehicleStatus>("vehicle filter type", true);
    //                    List<string> licenseNumbersByFilter = jbGarage.GetLicenseNumbersByFilter(vehicleStatusFilter);
    //                    ConsoleUI.PrintLicenseNumbersArray(licenseNumbersByFilter);
    //                    isFinished = ConsoleUI.IsReturningToMainMenu();
    //                }

    //                break;
    //            case 3:
    //                {
    //                    string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");

    //                    if (jbGarage.IsVehicleInGarage(vehicleLicenseNumber))
    //                    {
    //                        eGarageVehicleStatus newVehicleStatus = ConsoleUI.GetValidOptionChoiceByEnum<eGarageVehicleStatus>("vehicle new status");
    //                        jbGarage.ChangeVehicleStatus(vehicleLicenseNumber, newVehicleStatus);
    //                    }
    //                    else
    //                    {
    //                        ConsoleUI.VehicleIsNotInGarage();
    //                    }

    //                    isFinished = ConsoleUI.IsReturningToMainMenu();
    //                }

    //                break;
    //            case 4:
    //                {
    //                    string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");

    //                    if (jbGarage.IsVehicleInGarage(vehicleLicenseNumber))
    //                    {
    //                        jbGarage.FillTirePressureToMax(vehicleLicenseNumber);
    //                    }
    //                    else
    //                    {
    //                        ConsoleUI.VehicleIsNotInGarage();
    //                    }

    //                    isFinished = ConsoleUI.IsReturningToMainMenu();
    //                }

    //                break;
    //            case 5:
    //                {
    //                    string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");

    //                    if (jbGarage.IsVehicleInGarage(vehicleLicenseNumber))
    //                    {
    //                        eEnergyType vehicleEnergyType = ConsoleUI.GetValidOptionChoiceByEnum<eEnergyType>("vehicle energy type");
    //                        float amountToRefill = ConsoleUI.GetUserNumericInputWithMessage<float>("desired amount to refill");
    //                        jbGarage.RefuelAVehicle(vehicleLicenseNumber, vehicleEnergyType, amountToRefill);
    //                    }
    //                    else
    //                    {
    //                        ConsoleUI.VehicleIsNotInGarage();
    //                    }

    //                    isFinished = ConsoleUI.IsReturningToMainMenu();
    //                }

    //                break;
    //            case 6:
    //                {
    //                    string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");

    //                    if (jbGarage.IsVehicleInGarage(vehicleLicenseNumber))
    //                    {
    //                        float amountToRefill = ConsoleUI.GetUserNumericInputWithMessage<float>("desired amount to refill");
    //                        jbGarage.RefuelAVehicle(vehicleLicenseNumber, eEnergyType.Electric, amountToRefill);
    //                    }
    //                    else
    //                    {
    //                        ConsoleUI.VehicleIsNotInGarage();
    //                    }

    //                    isFinished = ConsoleUI.IsReturningToMainMenu();
    //                }

    //                break;
    //            case 7:
    //                {
    //                    string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");

    //                    if (jbGarage.IsVehicleInGarage(vehicleLicenseNumber))
    //                    {
    //                        Dictionary<string, string> fullVehicleDetails = jbGarage.GetFullVehicleDetails(vehicleLicenseNumber);
    //                        ConsoleUI.PrintFullVehicleDetails(fullVehicleDetails);
    //                    }
    //                    else
    //                    {
    //                        ConsoleUI.VehicleIsNotInGarage();
    //                    }

    //                    isFinished = ConsoleUI.IsReturningToMainMenu();
    //                }

    //                break;
    //        }
    //    }
    //}
}