using Ex03.GarageLogic.Utils;

namespace Ex03.ConsoleUI
{
    internal static class ConsoleUI
    {
        internal static void PrintWelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("Hello and welcome to Jonathan & Bar Garage!\n");
            Thread.Sleep(4000);
        }

        internal static int PrintMenuAndGetChoice()
        {
            const int numOfMenuOptions = 8;

            Console.Clear();
            Console.WriteLine("====== Garage Menu ======\n");
            Console.WriteLine("Please choose an option:\n"
                              + "1: Enter a new vehicle into the garage\n"
                              + "2: Show list of vehicles in the garage (with an option to filter)\n"
                              + "3: Change the status of a vehicle in the garage\n"
                              + "4: Fill vehicle tires pressure to maximum\n"
                              + "5: Refuel a vehicle\n"
                              + "6: Charge an electric vehicle\n"
                              + "7: Show vehicle details by license number\n"
                              + "8: Exit the program");

            return GetValidOptionChoice(numOfMenuOptions);
        }

        internal static void PrintChosenAndClearScreen(int menuChoice)
        {
            Console.Clear();

            switch (menuChoice)
            {
                case 1:
                    Console.Write("You chose to enter a new vehicle into the garage");

                    break; ;
                case 2:
                    Console.Write("You chose to show list of vehicles in the garage");

                    break;
                case 3:
                    Console.Write("You chose to change the status of a vehicle in the garage");

                    break;
                case 4:
                    Console.Write("You chose to fill vehicle tires pressure to maximum");

                    break;
                case 5:
                    Console.Write("You chose to refuel a vehicle");

                    break;
                case 6:
                    Console.Write("You chose to charge an electric vehicle");

                    break;
                case 7:
                    Console.Write("You chose to show vehicle details by license number");

                    break;
                case 8:
                    exitProgramMessage();

                    break;
                default:
                    Console.Write("Invalid choice. Please try again.");

                    break;
            }

            Thread.Sleep(2000);
        }

        internal static eVehicleTypes GetVehicleType()
        {
            return GetValidOptionChoiceByEnum<eVehicleTypes>("vehicle type");
        }

        internal static TEnum GetValidOptionChoiceByEnum<TEnum>(string i_InputMessage, int i_OptionsToExclude = 0) where TEnum : Enum
        {
            int enumLength = Enum.GetValues(typeof(TEnum)).Length;
            int maximumChoice = enumLength - i_OptionsToExclude;
            int optionNumber = 1;

            Console.Clear();
            Console.WriteLine($"Please choose your {i_InputMessage} below:");

            foreach (var option in Enum.GetValues(typeof(TEnum)))
            {
                if (optionNumber <= maximumChoice)
                {
                    Console.WriteLine($"{optionNumber++}: {FormatStringToText(option.ToString())}");
                }
            }

            int userChoice = GetValidOptionChoice(maximumChoice) - 1;
            TEnum selectedType = (TEnum)Enum.ToObject(typeof(TEnum), userChoice);

            Console.WriteLine($"\nYour choice is: {FormatStringToText(selectedType.ToString())}");
            Thread.Sleep(1500);

            return selectedType;
        }

        internal static string FormatStringToText(string i_UnformattedString)
        {
            string formattedString = string.Empty;

            formattedString += i_UnformattedString[0];

            for (int i = 1; i < i_UnformattedString.Length; i++)
            {
                if (char.IsLower(i_UnformattedString[i - 1]) && char.IsUpper(i_UnformattedString[i]))
                {
                    formattedString += ' ';
                    formattedString += char.ToLower(i_UnformattedString[i]);
                }
                else
                {
                    formattedString += i_UnformattedString[i];
                }

            }

            return formattedString;
        }

        internal static int GetValidOptionChoice(int i_MaximumChoice)
        {
            bool isValid;
            int numericChoice;

            do
            {
                Console.Write("Please enter your choice: ");

                string userChoice = Console.ReadLine();

                if (!int.TryParse(userChoice, out numericChoice))
                {
                    throw new FormatException("Invalid choice. Please enter a valid integer.");
                }

                isValid = numericChoice >= 1 && numericChoice <= i_MaximumChoice;

                if (!isValid)
                {
                    Console.WriteLine($"Invalid choice. You can only choose between 1 and {i_MaximumChoice}. Please try again.");
                }
            } while (!isValid);

            return numericChoice;
        }

        internal static string GetUserStringInputWithMessage(string i_Message)
        {
            Console.Clear();
            Console.Write($"Please enter your {i_Message}: ");

            return Console.ReadLine();
        }

        internal static T GetUserNonNegativeNumericInputWithMessage<T>(string i_Message)
        {
            Console.Clear();

            if (typeof(T) != typeof(int) && typeof(T) != typeof(float))
            {
                throw new FormatException("T must be either int or float");
            }

            Console.Write($"Please enter your {i_Message}: ");

            bool isValid = false;
            T? numericChoice = default;

            do
            {
                string userChoice = Console.ReadLine();

                if (typeof(T) == typeof(int))
                {
                    isValid = int.TryParse(userChoice, out int intValue) && intValue >= 0;
                    numericChoice = (T)(object)intValue;
                }
                else if (typeof(T) == typeof(float))
                {
                    isValid = float.TryParse(userChoice, out float floatValue) && floatValue >= 0;
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
            Console.Clear();

            string energyType, unit;
            if(selectedVehicleType.ToString().Contains("Electric"))
            {
                energyType = "electricity";
                unit = "hours";
            }
            else
            {
                energyType = "fuel";
                unit = "liters";
            }
            string energyMessage = $"current {energyType} left in {unit}";

            float vehicleCurrentEnergy = GetUserNonNegativeNumericInputWithMessage<float>(energyMessage);

            return vehicleCurrentEnergy;
        }

        internal static eLicenseTypes GetLicenseType()
        {
            return GetValidOptionChoiceByEnum<eLicenseTypes>("license type");
        }

        internal static int GetEngineVolume()
        {
            return GetUserNonNegativeNumericInputWithMessage<int>("engine volume");
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
            Console.Clear();
            Console.WriteLine("Is the vehicle carrying hazardous materials?:\n" 
                              + "1. Yes\n" 
                              + "2. No\n");

            return (GetValidOptionChoice(2) == 1);
        }

        internal static float GetCargoVolume()
        {
            return GetUserNonNegativeNumericInputWithMessage<float>("cargo volume");
        }

        internal static void VehicleCreationAttempt(bool i_IsVehicleCreated)
        {
            Console.Clear();
            Console.WriteLine($"Vehicle created {(i_IsVehicleCreated ? "" : "un")}successfully.\n");
        }

        internal static void PrintLicenseNumbersArray(List<string> i_LicenseNumbersByFilter)
        {
            Console.Clear();
            Console.WriteLine("License numbers for the selected filter:");

            if (i_LicenseNumbersByFilter.Count == 0)
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

        internal static bool IsReturningToMainMenu()
        {
            Console.WriteLine("\nDo you want to return to the main menu?:\n"
                              + "1. Yes\n"
                              + "2. No\n");

            bool isExiting = (GetValidOptionChoice(2) == 2);

            if (isExiting)
            {
                exitProgramMessage();
                Thread.Sleep(3000);
            }

            return isExiting;
        }

        private static void exitProgramMessage()
        {
            Console.Clear();
            Console.WriteLine("You chose to exit the program, see you next time.");
        }

        internal static void PrintFullVehicleDetails(Dictionary<string, string> i_FullVehicleDetails)
        {
            Console.Clear();
            Console.WriteLine("Here are the details for the requested license number:");

            if (i_FullVehicleDetails.TryGetValue("Current Fuel Available", out string? fuelValue))
            {
                float currentFuel = float.Parse(fuelValue);
                i_FullVehicleDetails["Current Fuel Available"] = String.Format("{0:F2} %", currentFuel);
            }

            if (i_FullVehicleDetails.TryGetValue("Current Energy Available", out string? energyValue))
            {
                float currentEnergy = float.Parse(energyValue);
                i_FullVehicleDetails["Current Energy Available"] = String.Format("{0:F2} %", currentEnergy);
            }

            foreach (KeyValuePair<string, string> detail in i_FullVehicleDetails)
            {
                Console.WriteLine($"{detail.Key}: {FormatStringToText(detail.Value)}");
            }

            Console.WriteLine();
        }

        internal static void VehicleIsAlreadyInGarage()
        {
            Console.WriteLine("The vehicle is in our garage and currently being repaired.");
        }

        internal static void VehicleIsNotInGarage()
        {
            Console.WriteLine("The vehicle is not in the garage.");
        }

        public static void PrintFeedback(string i_FeedbackMessage)
        {
            Console.Clear();
            Console.WriteLine(i_FeedbackMessage);
            Thread.Sleep(3000);
            Console.Clear();
        }
    }
}
