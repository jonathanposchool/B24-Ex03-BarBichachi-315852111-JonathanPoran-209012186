using System.Reflection;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Utils;

namespace Ex03.ConsoleUI
{
    internal class ConsoleUI
    {
        internal static int PrintMenuAndGetChoice()
        { 
            Console.Clear();
            Console.WriteLine("Hello and welcome to Jonathan & Bar Garage!");
            Console.WriteLine("Please choose an option:\n"
                              + "1. Enter a new vehicle into the garage\n"
                              + "2. Show list of vehicles in the garage (with an option to filter)\n"
                              + "3. Change the status of a vehicle in the garage\n"
                              + "4. Fill vehicle tire pressure to maximum\n"
                              + "5. Refuel a vehicle\n"
                              + "6. Charge an electric vehicle\n"
                              + "7. Show vehicle details by license number\n");

            return GetValidOptionChoice(7);
        }

        internal static eVehicleTypes GetVehicleType()
        {
            return GetValidOptionChoiceByEnum<eVehicleTypes>("vehicle type");
        }

        internal static TEnum GetValidOptionChoiceByEnum<TEnum>(string i_InputMessage) where TEnum : Enum
        {
            int maximumChoice = Enum.GetValues(typeof(TEnum)).Length;

            Console.WriteLine($"Please choose your {i_InputMessage} below:");

            foreach (var option in Enum.GetValues(typeof(TEnum)))
            {
                Console.WriteLine($"{(int)option}: {option}");
            }

            int userChoice = GetValidOptionChoice(maximumChoice);
            TEnum selectedType = (TEnum)Enum.ToObject(typeof(TEnum), userChoice);

            Console.WriteLine($"Your choice is: {selectedType}");

            return selectedType;
        }

        internal static int GetValidOptionChoice(int i_MaximumChoice)
        {
            bool isValid = false;
            int numericChoice;

            do
            {
                Console.Write("Please enter your choice: ");

                string userChoice = Console.ReadLine();
                
                if (int.TryParse(userChoice, out numericChoice))
                {
                    isValid = numericChoice >= 1 && numericChoice <= i_MaximumChoice;
                }
                else
                {
                    Console.WriteLine($"Invalid choice. You can only choose between 1 and {i_MaximumChoice}. Please try again.");
                }
            } while (!isValid);

            return numericChoice;
        }

        internal static string GetUserStringInputWithMessage(string i_Message)
        {
            Console.Write($"Please enter your {i_Message}: ");

            return Console.ReadLine();
        }

        internal static T GetUserNumericInputWithMessage<T>(string i_Message)
        {
            if (typeof(T) != typeof(int) && typeof(T) != typeof(float))
            {
                throw new Exception("T must be either int or float");
            }

            bool isValid = false;
            T? numericChoice = default;

            Console.Write($"Please enter your {i_Message}: ");

            do
            {
                string userChoice = Console.ReadLine();

                if (typeof(T) == typeof(int))
                {
                    isValid = int.TryParse(userChoice, out int intValue);
                    numericChoice = (T)(object)intValue;
                }
                else if (typeof(T) == typeof(float))
                {
                    isValid = float.TryParse(userChoice, out float floatValue);
                    numericChoice = (T)(object)floatValue;
                }

                if (!isValid)
                {
                    Console.WriteLine($"Invalid input. Please enter a valid number.");
                }
            } while (!isValid);

            return numericChoice;
        }

        internal static float GetVehicleEnergy(eVehicleTypes selectedVehicleType)
        {
            string energyType = selectedVehicleType.ToString().Contains("Electric") ? "electricity" : "fuel";
            string energyMessage = $"current {energyType} left";

            float vehicleCurrentEnergy = GetUserNumericInputWithMessage<float>(energyMessage);

            return vehicleCurrentEnergy;
        }

        internal static eLicenseTypes GetLicenseType()
        {
            return GetValidOptionChoiceByEnum<eLicenseTypes>("license type");
        }

        internal static int GetEngineVolume()
        {
            return GetUserNumericInputWithMessage<int>("engine volume");
        }

        internal static eCarColors GetVehicleColor()
        {
            return GetValidOptionChoiceByEnum<eCarColors>("car color");
        }

        internal static eCarDoors GetVehicleNumOfDoors()
        {
            return GetValidOptionChoiceByEnum<eCarDoors>("number of car doors");
        }

        internal static bool IsCarryingHazardous()
        {
            Console.WriteLine("Is the vehicle carrying hazardous materials?:\n" 
                              + "1. Yes\n" 
                              + "2. No\n");

            return (GetValidOptionChoice(2) == 1);
        }

        internal static float GetCargoVolume()
        {
            return GetUserNumericInputWithMessage<float>("cargo volume");
        }

        internal static void VehicleCreationAttempt(bool i_IsVehicleCreated)
        {
            Console.WriteLine($"Vehicle created {(i_IsVehicleCreated ? "" : "un")}successfully.");
        }

        internal static void PrintLicenseNumbersArray(string[] i_LicenseNumbersByFilter)
        {
            Console.WriteLine("License numbers for the selected filter:");
            if (i_LicenseNumbersByFilter.Length == 0)
            {
                Console.WriteLine("No vehicles found for the selected filter.");
            }
            else
            {
                foreach (string licenseNumber in i_LicenseNumbersByFilter)
                {
                    Console.WriteLine(licenseNumber);
                }
            }

        }

        public static bool ReturnToMainMenu()
        {
            Console.WriteLine("Do you want to return to the main menu?:\n"
                              + "1. Yes\n"
                              + "2. No\n");

            return (GetValidOptionChoice(2) == 1);
        }

        public static void PrintFullVehicleDetails(string i_FullVehicleDetails)
        {
            Console.WriteLine("Here are the details for the requested license number:");
            Console.WriteLine(i_FullVehicleDetails);
        }
    }
}
