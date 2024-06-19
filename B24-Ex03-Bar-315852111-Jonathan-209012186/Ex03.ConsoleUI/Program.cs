using System;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Manufacturing;


class Program
{
    static void Main()
    {
        Garage JBGarage = new Garage();

        Console.WriteLine("Hello and welcome to Jonathan & Bar Garage!");
        Console.Write("Please enter your vehicle license number: ");
        string vehicleLicenseNumber = Console.ReadLine();

        if (JBGarage.IsVehicleInGarage(vehicleLicenseNumber))
        {
            JBGarge.ChangeVehicleStatus
            Console.WriteLine("Your vehicle is in our garage.");
            Console.WriteLine($"Your status is ")
        }
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
