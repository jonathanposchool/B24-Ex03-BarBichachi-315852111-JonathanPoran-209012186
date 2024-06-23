using Ex03.GarageLogic;
using Ex03.GarageLogic.Utils;

namespace Ex03.ConsoleUI
{
    internal class GarageApplication
    {
        private readonly Garage r_JBGarage;
        private bool m_ShouldExitMainLoop;

        public GarageApplication()
        {
            r_JBGarage = new Garage();
        }

        public void RunGarageManagementSystem()
        {
            m_ShouldExitMainLoop = false;

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
                    ConsoleUI.PrintException($"Invalid format: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    ConsoleUI.PrintException($"Argument error: {ex.Message}");
                }
                catch (ValueOutOfRangeException ex)
                {
                    ConsoleUI.PrintException($"Value out of range: {ex.Message}. Valid range is {ex.m_MinValue} to {ex.m_MaxValue}.");
                }
                catch (Exception ex)
                {
                    ConsoleUI.PrintException($"An unexpected error occurred: {ex.Message}");
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
                float vehicleCurrentTiresPressure = ConsoleUI.GetUserNumericInputWithMessage<float>("current tires PSI (air pressure)");
                float vehicleCurrentEnergy = ConsoleUI.GetVehicleEnergy(selectedVehicleType);

                try
                {
                    switch (selectedVehicleType)
                    {
                        case eVehicleTypes.RegularMotorcycle:
                        case eVehicleTypes.ElectricMotorcycle:
                            createAndInsertMotorcycle(vehicleLicenseNumber, vehicleOwnerName, vehicleOwnerPhone, vehicleModel, vehicleTiresManufacturer, vehicleCurrentTiresPressure, vehicleCurrentEnergy, selectedVehicleType);
                            break;
                        case eVehicleTypes.RegularCar:
                        case eVehicleTypes.ElectricCar:
                            createAndInsertCar(vehicleLicenseNumber, vehicleOwnerName, vehicleOwnerPhone, vehicleModel, vehicleTiresManufacturer, vehicleCurrentTiresPressure, vehicleCurrentEnergy, selectedVehicleType);
                            break;
                        case eVehicleTypes.RegularTruck:
                            createAndInsertTruck(vehicleLicenseNumber, vehicleOwnerName, vehicleOwnerPhone, vehicleModel, vehicleTiresManufacturer, vehicleCurrentTiresPressure, vehicleCurrentEnergy);
                            break;
                    }

                    isVehicleCreated = true;
                }
                catch (FormatException ex)
                {
                    ConsoleUI.PrintException($"Invalid format: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    ConsoleUI.PrintException($"Argument error: {ex.Message}");
                }
                catch (ValueOutOfRangeException ex)
                {
                    ConsoleUI.PrintException($"Value out of range: {ex.Message}. Valid range is {ex.m_MinValue} to {ex.m_MaxValue}.");
                }
                catch (Exception ex)
                {
                    ConsoleUI.PrintException($"Error creating vehicle: {ex.Message}");
                }

                ConsoleUI.VehicleCreationAttempt(isVehicleCreated);
            } while (!isVehicleCreated);
        }

        private void createAndInsertMotorcycle(string vehicleLicenseNumber, string vehicleOwnerName, string vehicleOwnerPhone, string vehicleModel, string vehicleTiresManufacturer, float vehicleCurrentTiresPressure, float vehicleCurrentEnergy, eVehicleTypes selectedVehicleType)
        {
            eLicenseTypes licenseType = ConsoleUI.GetLicenseType();
            int engineVolume = ConsoleUI.GetEngineVolume();

            r_JBGarage.CreateAndInsertMotorcycleToGarage(vehicleLicenseNumber, vehicleModel, vehicleOwnerName, vehicleOwnerPhone,
                selectedVehicleType, vehicleCurrentEnergy, vehicleTiresManufacturer, vehicleCurrentTiresPressure,
                licenseType, engineVolume);
        }

        private void createAndInsertCar(string vehicleLicenseNumber, string vehicleOwnerName, string vehicleOwnerPhone, string vehicleModel, string vehicleTiresManufacturer, float vehicleCurrentTiresPressure, float vehicleCurrentEnergy, eVehicleTypes selectedVehicleType)
        {
            eCarColors carColor = ConsoleUI.GetVehicleColor();
            eCarDoors carNumOfDoors = ConsoleUI.GetVehicleNumOfDoors();

            r_JBGarage.CreateAndInsertCarToGarage(vehicleLicenseNumber, vehicleModel, vehicleOwnerName, vehicleOwnerPhone,
                selectedVehicleType, vehicleCurrentEnergy, vehicleTiresManufacturer, vehicleCurrentTiresPressure,
                carColor, carNumOfDoors);
        }

        private void createAndInsertTruck(string vehicleLicenseNumber, string vehicleOwnerName, string vehicleOwnerPhone, string vehicleModel, string vehicleTiresManufacturer, float vehicleCurrentTiresPressure, float vehicleCurrentEnergy)
        {
            bool isCarryingHazardous = ConsoleUI.IsCarryingHazardous();
            float truckCargoVolume = ConsoleUI.GetCargoVolume();

            r_JBGarage.CreateAndInsertTruckToGarage(vehicleLicenseNumber, vehicleModel, vehicleOwnerName, vehicleOwnerPhone,
                vehicleCurrentEnergy, vehicleTiresManufacturer, vehicleCurrentTiresPressure, isCarryingHazardous, truckCargoVolume);
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
                r_JBGarage.FillTirePressureToMax(vehicleLicenseNumber);
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
                float amountToRefill = ConsoleUI.GetUserNumericInputWithMessage<float>("desired amount to refill");

                r_JBGarage.RefuelAVehicle(vehicleLicenseNumber, vehicleEnergyType, amountToRefill);
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
                float amountToRefill = ConsoleUI.GetUserNumericInputWithMessage<float>("desired amount to refill");

                r_JBGarage.RefuelAVehicle(vehicleLicenseNumber, eEnergyType.Electric, amountToRefill);
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
