using System;
using System.Data.Common;
using Ex03.ConsoleUI;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Utils;

// TODO
/*
 * unused methods/functions
 * unused variables
 * unused get/sets
 * public/protected/internal/private
 * Exceptions
 */

class Program
{
    static void Main()
    {
        Garage jbGarage = new Garage();
        bool isFinished = true;

        while (!isFinished)
        {
            int menuChoice = ConsoleUI.PrintMenuAndGetChoice();

            switch (menuChoice)
            {
                case 1:
                    {
                        string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");

                        if (jbGarage.IsVehicleInGarage(vehicleLicenseNumber))
                        {
                            jbGarage.ChangeVehicleStatus(vehicleLicenseNumber, eGarageVehicleStatus.ServiceInProgress);
                            Console.WriteLine("Your vehicle is in our garage and currently being repaired.");
                        }
                        else
                        {
                            string vehicleOwnerName = ConsoleUI.GetUserStringInputWithMessage("name");
                            string vehicleOwnerPhone = ConsoleUI.GetUserStringInputWithMessage("phone number");
                            bool isVehicleCreated = false;

                            do
                            {
                                eVehicleTypes selectedVehicleType = ConsoleUI.GetVehicleType();
                                string vehicleModel = ConsoleUI.GetUserStringInputWithMessage("vehicle model");
                                string vehicleTiresManufacturer = ConsoleUI.GetUserStringInputWithMessage("tires manufacturer");
                                float vehicleCurrentTiresPressure = ConsoleUI.GetUserNumericInputWithMessage<float>("current tires PSI (air pressure)");
                                float vehicleCurrentEnergy = ConsoleUI.GetVehicleEnergy(selectedVehicleType);

                                try
                                {
                                    switch (selectedVehicleType)
                                    {
                                        case eVehicleTypes.RegularMotorcycle:
                                        case eVehicleTypes.ElectricMotorcycle:
                                            eLicenseTypes licenseType = ConsoleUI.GetLicenseType();
                                            int engineVolume = ConsoleUI.GetEngineVolume();

                                            jbGarage.CreateAndInsertMotorcycleToGarage(
                                                vehicleLicenseNumber,
                                                selectedVehicleType,
                                                vehicleCurrentEnergy,
                                                vehicleCurrentTiresPressure,
                                                licenseType,
                                                engineVolume);
                                            isVehicleCreated = true;
                                            break;

                                        case eVehicleTypes.RegularCar:
                                        case eVehicleTypes.ElectricCar:
                                            eCarColors carColor = ConsoleUI.GetVehicleColor();
                                            eCarDoors carNumOfDoors = ConsoleUI.GetVehicleNumOfDoors();

                                            jbGarage.CreateAndInsertCarToGarage(
                                                vehicleLicenseNumber,
                                                selectedVehicleType,
                                                vehicleCurrentEnergy,
                                                vehicleCurrentTiresPressure,
                                                carColor,
                                                carNumOfDoors);
                                            isVehicleCreated = true;
                                            break;

                                        case eVehicleTypes.RegularTruck:
                                            bool isCarryingHazardous = ConsoleUI.IsCarryingHazardous();
                                            float truckCargoVolume = ConsoleUI.GetCargoVolume();

                                            jbGarage.CreateAndInsertTruckToGarage(
                                                vehicleLicenseNumber,
                                                vehicleCurrentEnergy,
                                                vehicleCurrentTiresPressure,
                                                isCarryingHazardous,
                                                truckCargoVolume);
                                            isVehicleCreated = true;
                                            break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"An error occurred: {ex.Message}");
                                }

                                ConsoleUI.VehicleCreationAttempt(isVehicleCreated);
                            }
                            while (!isVehicleCreated);
                        }

                        isFinished = ConsoleUI.ReturnToMainMenu();
                    }

                    break;
                case 2:
                    {
                        eGarageVehicleStatus vehicleStatusFilter = ConsoleUI.GetValidOptionChoiceByEnum<eGarageVehicleStatus>("vehicle filter type");
                        List<string> licenseNumbersByFilter = jbGarage.GetLicenseNumbersByFilter(vehicleStatusFilter);
                        ConsoleUI.PrintLicenseNumbersArray(licenseNumbersByFilter);
                        isFinished = ConsoleUI.ReturnToMainMenu();
                    }

                    break;
                case 3:
                    {
                        string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");
                        eGarageVehicleStatus newVehicleStatus = ConsoleUI.GetValidOptionChoiceByEnum<eGarageVehicleStatus>("vehicle new status");
                        jbGarage.ChangeVehicleStatus(vehicleLicenseNumber, newVehicleStatus);
                        isFinished = ConsoleUI.ReturnToMainMenu();
                    }

                    break;
                case 4:
                    {
                        string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");
                        jbGarage.FillTirePressureToMax(vehicleLicenseNumber);
                        isFinished = ConsoleUI.ReturnToMainMenu();
                    }

                    break;
                case 5:
                    {
                        string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");
                        eEnergyType vehicleEnergyType = ConsoleUI.GetValidOptionChoiceByEnum<eEnergyType>("vehicle energy type");
                        float amountToRefill = ConsoleUI.GetUserNumericInputWithMessage<float>("desired amount to refill (in liters)");
                        jbGarage.RefuelAVehicle(vehicleLicenseNumber, vehicleEnergyType, amountToRefill);
                        isFinished = ConsoleUI.ReturnToMainMenu();
                    }

                    break;
                case 6:
                    {
                        string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");
                        float amountToRefill = ConsoleUI.GetUserNumericInputWithMessage<float>("desired amount to refill (in hours)");
                        jbGarage.RefuelAVehicle(vehicleLicenseNumber, eEnergyType.Electric, amountToRefill);
                        isFinished = ConsoleUI.ReturnToMainMenu();
                    }

                    break;
                case 7:
                    {
                        string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");
                        List<string> fullVehicleDetails = jbGarage.GetFullVehicleDetails(vehicleLicenseNumber);
                        ConsoleUI.PrintFullVehicleDetails(fullVehicleDetails);
                        isFinished = ConsoleUI.ReturnToMainMenu();
                    }

                    break;
            }
        }
    }
}