using System;
using Ex03.ConsoleUI;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Utils;

class Program
{
    static void Main()
    {
        Garage JBGarage = new Garage();
        char menuChoice = ConsoleUI.PrintMenuAndGetChoice();

        switch (menuChoice)
        {
            case '1':
                string vehicleLicenseNumber = ConsoleUI.GetVehicleLicenseNumber();

                if (JBGarage.IsVehicleInGarage(vehicleLicenseNumber))
                {
                    JBGarage.ChangeVehicleStatus(vehicleLicenseNumber, eGarageVehicleStatus.ServiceInProgress);
                    Console.WriteLine("Your vehicle is in our garage and currently being repaired.");
                    // TODO
                    // 3-7 with license number
                }
                else
                {
                    eVehicleTypes selectedVehicleType = ConsoleUI.GetVehicleType();
                    

                    
                    //switch
                    //Truck
                    // case: 'Truck'
                          // Console.WriteLine("Is dangerous [Y/N]");
                          // bool isDangerous = true;
                          // 
                          // Console.Writeline("Cargo volume: ");
                          //

                          //
                          try
                          {

                            //Garage.CreateNewTruck(selectedType, vehicleLicenseNumber, ....);
                          }
                          catch (Exception e)
                          {
                              Console.WriteLine(e); // AIR PRESSURE IS NOT VALID
                              throw;
                          }





                    //
                    LOGIC FOR NEW VEHICLE
                    //


                    void InsertNewCarToGarage()
                    {
                        VEHICLE = new vehicle
                    }
                }
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