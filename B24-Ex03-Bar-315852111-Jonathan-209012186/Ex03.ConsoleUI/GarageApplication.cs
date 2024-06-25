using Ex03.GarageLogic;
using Ex03.GarageLogic.Utils;

namespace Ex03.ConsoleUI
{
    internal class GarageApplication
    {
        private readonly Garage r_JBGarage;
        private bool m_ShouldExitMainLoop;

        internal GarageApplication()
        {
            r_JBGarage = new Garage();
        }

        internal void RunGarageManagementSystem()
        {
            m_ShouldExitMainLoop = false;
            ConsoleUI.PrintWelcomeMessage();
            while (!m_ShouldExitMainLoop)
            {
                try
                {
                    int menuChoice = ConsoleUI.PrintMenuAndGetChoice();
                    ConsoleUI.PrintChosenAndClearScreen(menuChoice);

                    switch (menuChoice)
                    {
                        case 1:
                            handleVehicleEntry();
                            break;
                        case 2:
                            handleVehicleFiltering();
                            break;
                        case 3:
                            changeVehicleStatus();
                            break;
                        case 4:
                            fillTiresToMax();
                            break;
                        case 5:
                            refuelVehicle();
                            break;
                        case 6:
                            chargeElectricVehicle();
                            break;
                        case 7:
                            displayVehicleDetails();
                            break;
                        case 8:
                            m_ShouldExitMainLoop = true;
                            break;
                        default:
                            throw new ValueOutOfRangeException("Invalid menu choice", 1, 7);
                    }
                }
                catch (FormatException ex)
                {
                    ConsoleUI.PrintFeedback($"Invalid format: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    ConsoleUI.PrintFeedback($"Argument error: {ex.Message}");
                }
                catch (ValueOutOfRangeException ex)
                {
                    ConsoleUI.PrintFeedback($"Value out of range: {ex.Message}. Valid range is {ex.m_MinValue} to {ex.m_MaxValue}.");
                }
                catch (Exception ex)
                {
                    ConsoleUI.PrintFeedback($"An unexpected error occurred: {ex.Message}");
                }
            }
        }

        private void handleVehicleEntry()
        {
            string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");

            if (r_JBGarage.IsVehicleInGarage(vehicleLicenseNumber))
            {
                handleExistingVehicle(vehicleLicenseNumber);
            }
            else
            {
                handleNewVehicleEntry(vehicleLicenseNumber);
            }

            m_ShouldExitMainLoop = ConsoleUI.IsReturningToMainMenu();
        }

        private void handleExistingVehicle(string vehicleLicenseNumber)
        {
            r_JBGarage.ChangeVehicleStatus(vehicleLicenseNumber, eGarageVehicleStatus.ServiceInProgress);
            ConsoleUI.VehicleIsAlreadyInGarage();
        }

        private void handleNewVehicleEntry(string vehicleLicenseNumber)
        {
            string vehicleOwnerName = ConsoleUI.GetUserStringInputWithMessage("name");
            string vehicleOwnerPhone = ConsoleUI.GetUserStringInputWithMessage("phone number");
            bool isVehicleCreated = false;

            do
            {
                eVehicleTypes selectedVehicleType = ConsoleUI.GetVehicleType();
                string vehicleModel = ConsoleUI.GetUserStringInputWithMessage("vehicle model");
                string vehicleTiresManufacturer = ConsoleUI.GetUserStringInputWithMessage("tires manufacturer");
                float vehicleCurrentTiresPressure = ConsoleUI.GetUserNonNegativeNumericInputWithMessage<float>("current tires PSI (air pressure)");
                float vehicleCurrentEnergy = ConsoleUI.GetVehicleEnergy(selectedVehicleType);

                try
                {
                    switch (selectedVehicleType)
                    {
                        case eVehicleTypes.RegularMotorcycle:
                        case eVehicleTypes.ElectricMotorcycle:
                            insertMotorcycleToGarage(vehicleLicenseNumber, vehicleOwnerName, vehicleOwnerPhone, vehicleModel, vehicleTiresManufacturer, vehicleCurrentTiresPressure, vehicleCurrentEnergy, selectedVehicleType);
                            break;
                        case eVehicleTypes.RegularCar:
                        case eVehicleTypes.ElectricCar:
                            insertCarToGarage(vehicleLicenseNumber, vehicleOwnerName, vehicleOwnerPhone, vehicleModel, vehicleTiresManufacturer, vehicleCurrentTiresPressure, vehicleCurrentEnergy, selectedVehicleType);
                            break;
                        case eVehicleTypes.RegularTruck:
                            insertTruckToGarage(vehicleLicenseNumber, vehicleOwnerName, vehicleOwnerPhone, vehicleModel, vehicleTiresManufacturer, vehicleCurrentTiresPressure, vehicleCurrentEnergy, selectedVehicleType);
                            break;
                    }

                    isVehicleCreated = true;
                }
                catch (FormatException ex)
                {
                    ConsoleUI.PrintFeedback($"Invalid format: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    ConsoleUI.PrintFeedback($"Argument error: {ex.Message}");
                }
                catch (ValueOutOfRangeException ex)
                {
                    ConsoleUI.PrintFeedback($"Value out of range: {ex.Message}. Valid range is {ex.m_MinValue} to {ex.m_MaxValue}.");
                }
                catch (Exception ex)
                {
                    ConsoleUI.PrintFeedback($"Error creating vehicle: {ex.Message}");
                }

                ConsoleUI.VehicleCreationAttempt(isVehicleCreated);
            } while (!isVehicleCreated);
        }

        private void insertMotorcycleToGarage(string vehicleLicenseNumber, string vehicleOwnerName, string vehicleOwnerPhone, string vehicleModel, string vehicleTiresManufacturer, float vehicleCurrentTiresPressure, float vehicleCurrentEnergy, eVehicleTypes selectedVehicleType)
        {
            eLicenseTypes licenseType = ConsoleUI.GetLicenseType();
            int engineVolume = ConsoleUI.GetEngineVolume();

            r_JBGarage.CreateAndInsertMotorcycleToGarage(vehicleLicenseNumber, vehicleModel, vehicleOwnerName, vehicleOwnerPhone,
                selectedVehicleType, vehicleCurrentEnergy, vehicleTiresManufacturer, vehicleCurrentTiresPressure,
                licenseType, engineVolume);
        }

        private void insertCarToGarage(string vehicleLicenseNumber, string vehicleOwnerName, string vehicleOwnerPhone, string vehicleModel, string vehicleTiresManufacturer, float vehicleCurrentTiresPressure, float vehicleCurrentEnergy, eVehicleTypes selectedVehicleType)
        {
            eCarColors carColor = ConsoleUI.GetVehicleColor();
            eCarDoors carNumOfDoors = ConsoleUI.GetVehicleNumOfDoors();

            r_JBGarage.CreateAndInsertCarToGarage(vehicleLicenseNumber, vehicleModel, vehicleOwnerName, vehicleOwnerPhone,
                selectedVehicleType, vehicleCurrentEnergy, vehicleTiresManufacturer, vehicleCurrentTiresPressure,
                carColor, carNumOfDoors);
        }

        private void insertTruckToGarage(string vehicleLicenseNumber, string vehicleOwnerName, string vehicleOwnerPhone, string vehicleModel, string vehicleTiresManufacturer, float vehicleCurrentTiresPressure, float vehicleCurrentEnergy, eVehicleTypes selectedVehicleType)
        {
            bool isCarryingHazardous = ConsoleUI.IsCarryingHazardous();
            float truckCargoVolume = ConsoleUI.GetCargoVolume();

            r_JBGarage.CreateAndInsertTruckToGarage(vehicleLicenseNumber, vehicleModel, vehicleOwnerName, vehicleOwnerPhone,
                selectedVehicleType, vehicleCurrentEnergy, vehicleTiresManufacturer, vehicleCurrentTiresPressure, isCarryingHazardous, truckCargoVolume);
        }

        private void handleVehicleFiltering()
        {
            eGarageVehicleStatus vehicleStatusFilter = ConsoleUI.GetValidOptionChoiceByEnum<eGarageVehicleStatus>("vehicle filter type", true);
            List<string> licenseNumbersByFilter = r_JBGarage.GetLicenseNumbersByFilter(vehicleStatusFilter);

            ConsoleUI.PrintLicenseNumbersArray(licenseNumbersByFilter);

            m_ShouldExitMainLoop = ConsoleUI.IsReturningToMainMenu();
        }

        private void changeVehicleStatus()
        {
            string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");

            if (r_JBGarage.IsVehicleInGarage(vehicleLicenseNumber))
            {
                eGarageVehicleStatus newVehicleStatus = ConsoleUI.GetValidOptionChoiceByEnum<eGarageVehicleStatus>("vehicle new status");

                r_JBGarage.ChangeVehicleStatus(vehicleLicenseNumber, newVehicleStatus);
                ConsoleUI.PrintFeedback("Updated vehicle status: " + newVehicleStatus);
            }
            else
            {
                ConsoleUI.VehicleIsNotInGarage();
            }

            m_ShouldExitMainLoop = ConsoleUI.IsReturningToMainMenu();
        }

        private void fillTiresToMax()
        {
            string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");

            if (r_JBGarage.IsVehicleInGarage(vehicleLicenseNumber))
            {
                r_JBGarage.FillTiresPressureToMax(vehicleLicenseNumber);
                ConsoleUI.PrintFeedback("Tires pressure has been optimized to maximum levels.");
            }
            else
            {
                ConsoleUI.VehicleIsNotInGarage();
            }

            m_ShouldExitMainLoop = ConsoleUI.IsReturningToMainMenu();
        }

        private void refuelVehicle()
        {
            string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");

            if (r_JBGarage.IsVehicleInGarage(vehicleLicenseNumber))
            {
                eEnergyType vehicleEnergyType = ConsoleUI.GetValidOptionChoiceByEnum<eEnergyType>("vehicle energy type");
                float amountToRefill = ConsoleUI.GetUserNonNegativeNumericInputWithMessage<float>("desired amount to refill");
                string unit = vehicleEnergyType == eEnergyType.ElectricalPower ? "hours" : "liters";

                r_JBGarage.RefuelAVehicle(vehicleLicenseNumber, vehicleEnergyType, amountToRefill);
                ConsoleUI.PrintFeedback("Vehicle refueled with: " + amountToRefill + unit);
            }
            else
            {
                ConsoleUI.VehicleIsNotInGarage();
            }

            m_ShouldExitMainLoop = ConsoleUI.IsReturningToMainMenu();
        }

        private void chargeElectricVehicle()
        {
            string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");

            if (r_JBGarage.IsVehicleInGarage(vehicleLicenseNumber))
            {
                float amountToRefill = ConsoleUI.GetUserNonNegativeNumericInputWithMessage<float>("desired amount to refill");

                r_JBGarage.RefuelAVehicle(vehicleLicenseNumber, eEnergyType.ElectricalPower, amountToRefill);
                ConsoleUI.PrintFeedback("Vehicle charged with: " + amountToRefill + "hours");
            }
            else
            {
                ConsoleUI.VehicleIsNotInGarage();
            }

            m_ShouldExitMainLoop = ConsoleUI.IsReturningToMainMenu();
        }

        private void displayVehicleDetails()
        {
            string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");

            if (r_JBGarage.IsVehicleInGarage(vehicleLicenseNumber))
            {
                Dictionary<string, string> fullVehicleDetails = r_JBGarage.GetFullVehicleDetails(vehicleLicenseNumber);

                ConsoleUI.PrintFullVehicleDetails(fullVehicleDetails);
            }
            else
            {
                ConsoleUI.VehicleIsNotInGarage();
            }

            m_ShouldExitMainLoop = ConsoleUI.IsReturningToMainMenu();
        }
    }
}
