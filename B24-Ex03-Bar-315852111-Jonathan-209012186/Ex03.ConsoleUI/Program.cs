﻿using Ex03.GarageLogic;
using Ex03.GarageLogic.Utils;

class Program
{
    static void Main()
    {
        Garage JBGarage = new Garage();
        // TODO
        // Maybe should be UI.PrintMenu...? 
        char menuChoice = PrintMenuAndGetChoice();

        // TODO
        // Each case will be in different method, currently implementing it here.
        switch (menuChoice)
        {
            case '1':
                Console.Write("Please enter your vehicle license number: ");
                string vehicleLicenseNumber = Console.ReadLine();

                if (JBGarage.IsVehicleInGarage(vehicleLicenseNumber))
                {
                    eGarageVehicleStatus vehicleStatus = JBGarge.ChangeVehicleStatus(vehicleLicenseNumber);
                    Console.WriteLine("Your vehicle is in our garage.");
                    Console.WriteLine($"Your vehicle status is {vehicleStatus.ToString()}");
                    // TODO
                    // We've been told to use the vehicle that's currently in the garage - what does it mean?
                }
                else
                {
                    List<eVehicleTypes> vehicleTypes = Garage.GetVehicleTypes();
                    int maximumChoice = vehicleTypes.Count;
                    int vehicleTypesNum = 0;

                    Console.WriteLine("Please choose one of the vehicle types:");

                    foreach (eVehicleTypes type in vehicleTypes)
                    {
                        Console.WriteLine($"{++vehicleTypesNum}. {type}");
                    }

                    Console.Write("Please enter your choice: ");
                    string userChoice = Console.ReadLine();

                    while (!IsValidChoice(userChoice, maximumChoice))
                    {
                        Console.WriteLine($"Invalid choice. You can only choose between 1 and {maximumChoice}. Please try again.");
                        Console.Write("Please enter your choice: ");
                        userChoice = Console.ReadLine();
                    }

                    eVehicleTypes selectedType = vehicleTypes[int.Parse(userChoice) - 1];
                    Console.WriteLine($"The chosen vehicle is: {selectedType}");
                }
        }

    }

    protected static char PrintMenuAndGetChoice()
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

        while (!IsValidChoice(userChoice, 7))
        {
            Console.WriteLine("Invalid choice. You can only choose between 1 and 7. Please try again.");
            Console.Write("Please enter your choice: ");
            userChoice = Console.ReadLine();
        }

        return userChoice[0];
    }

    protected static bool IsValidChoice(string choice, int maximumChoice)
    {
        bool isValid = false;

        if (int.TryParse(choice, out int numericChoice))
        {
            isValid = numericChoice >= 1 && numericChoice <= maximumChoice;
        }

        return isValid;
    }

    /*
        create client calss
        Create a Garage database of client(name, phone and car) sorted by car id
        insert new car to Garage
        show garge vehicle list status with filters
        Garage change status
        Garage -> fill up air wheel to max
        garage -> fill uo fuel/electricity
        garage -> show car
        enum car status of garage(payed/onwork and so) 

        factory -> list bool of qustsion to ui + enum 
        factory: vehicle type => ctor vehicle type 
        factory list wheel ctor
        fill up air wheel by vale

        vehicle -> motorcycle
        vehicle -> car
        vehicle -> truck
    */
}
