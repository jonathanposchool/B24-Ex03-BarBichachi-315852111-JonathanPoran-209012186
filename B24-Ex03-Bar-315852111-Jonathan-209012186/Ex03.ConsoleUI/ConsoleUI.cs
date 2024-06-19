using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ex03.GarageLogic;
using Ex03.GarageLogic.Utils;

namespace Ex03.ConsoleUI
{
    internal class ConsoleUI
    {
        public static char PrintMenuAndGetChoice()
        {
            Console.WriteLine("Hello and welcome to Jonathan & Bar Garage!");
            Console.WriteLine("Please choose an option:\n"
                              + "1. Enter a new vehicle into the garage\n"
                              + "2. Show list of vehicles in the garage (with an option to filter)\n"
                              + "3. Change the status of a vehicle in the garage\n"
                              + "4. Fill vehicle tire pressure to maximum\n"
                              + "5. Refuel a vehicle\n"
                              + "6. Charge an electric vehicle\n"
                              + "7. Show vehicle details by license number\n");
            Console.Write("Please enter your choice: ");
            string userChoice = Console.ReadLine();

            while (!IsValidOptionChoice(userChoice, 7))
            {
                Console.WriteLine("Invalid choice. You can only choose between 1 and 7. Please try again.");
                Console.Write("Please enter your choice: ");
                userChoice = Console.ReadLine();
            }

            return userChoice[0];
        }

        public static string GetVehicleLicenseNumber()
        {
            Console.Write("Please enter your vehicle license number: ");
            return Console.ReadLine();
        }

        public static eVehicleTypes GetVehicleType()
        {
            List<eVehicleTypes> allVehicleTypes = Garage.GetAllVehicleTypes();
            int maximumChoice = allVehicleTypes.Count;
            int vehicleTypesNum = 0;

            Console.WriteLine("Please choose one of the vehicle types:");

            foreach (eVehicleTypes type in allVehicleTypes)
            {
                Console.WriteLine($"{++vehicleTypesNum}. {type}");
            }

            eVehicleTypes selectedType = allVehicleTypes[int.Parse(userChoice) - 1];
            Console.WriteLine($"The chosen vehicle is: {selectedType}");
        }

        protected static bool IsValidOptionChoice(string choice, int maximumChoice)
        {
            bool isValid = false;

            do
            {
                Console.Write("Please enter your choice: ");

                string userChoice = Console.ReadLine();

                if (int.TryParse(userChoice, out int numericChoice))
                {
                    isValid = numericChoice >= 1 && numericChoice <= maximumChoice;
                }

                if (!isValid)
                {
                    Console.WriteLine(
                        $"Invalid choice. You can only choose between 1 and {maximumChoice}. Please try again.");
                }
            } while (!isValid);

            return isValid;
        }
    }
}
