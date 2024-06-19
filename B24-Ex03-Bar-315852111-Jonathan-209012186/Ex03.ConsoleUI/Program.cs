using System;
using System.Data.Common;
using Ex03.ConsoleUI;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Utils;

class Program
{
    static void Main()
    {
        Garage JBGarage = new Garage();
        int menuChoice = ConsoleUI.PrintMenuAndGetChoice();

        switch (menuChoice)
        {
            case 1:
                {
                    string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");

                    if (JBGarage.IsVehicleInGarage(vehicleLicenseNumber))
                    {
                        // TODO
                        // Fix ChangeVehicleStatus method
                        JBGarage.ChangeVehicleStatus(vehicleLicenseNumber, eGarageVehicleStatus.ServiceInProgress);

                        // TODO
                        // 3-7 with license number
                        //ConsoleUI.VehicleInGarageMenu();
                        //Console.WriteLine("Your vehicle is in our garage and currently being repaired.");
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
                            isVehicleCreated = false;

                            try
                            {
                                switch (selectedVehicleType)
                                {
                                    case eVehicleTypes.RegularMotorcycle:
                                    case eVehicleTypes.ElectricMotorcycle:
                                        eLicenseTypes licenseType = ConsoleUI.GetLicenseType();
                                        int engineVolume = ConsoleUI.GetEngineVolume();

                                        // CreateNewMotorcycle();
                                        isVehicleCreated = true;
                                        break;

                                    case eVehicleTypes.RegularCar:
                                    case eVehicleTypes.ElectricCar:
                                        eCarColors carColor = ConsoleUI.GetVehicleColor();
                                        eCarDoors carNumOfDoors = ConsoleUI.GetVehicleNumOfDoors();

                                        // CreateNewCar();
                                        isVehicleCreated = true;
                                        break;

                                    case eVehicleTypes.RegularTruck:
                                        bool isCarryingHazardousMaterials = ConsoleUI.IsCarryingHazardousMaterials();
                                        float truckCargoVolume = ConsoleUI.GetCargoVolume();

                                        // CreateNewTruck();
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

                    break;
                }

            case 2:
                {
                    eGarageVehicleStatus userChoice = ConsoleUI.GetValidOptionChoiceByEnum<eGarageVehicleStatus>("vehicle filter type");
                    string[] licenseNumbersByFilter = Garage.GetLicenseNumbersByFilter(userChoice);
                    ConsoleUI.PrintLicenseNumbersArray(licenseNumbersByFilter);
                }

                break;
            case 3:
                {
                    // IF JUMPED FROM ONE NO NEED LICENSE NUMBER
                    string vehicleLicenseNumber = ConsoleUI.GetUserStringInputWithMessage("license number");
                    eGarageVehicleStatus userChoice = ConsoleUI.GetValidOptionChoiceByEnum<eGarageVehicleStatus>("vehicle new status");
                    JBGarage.ChangeVehicleStatus(vehicleLicenseNumber, userChoice);
                }

                break;
            case 4:
                {

                }

                break;
            case 5:
                {

                }

                break;
            case 6:
                {

                }

                break;
            case 7:
                {

                }

                break;


        }
    }
}