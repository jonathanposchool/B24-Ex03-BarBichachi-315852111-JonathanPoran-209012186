namespace Ex03.GarageLogic.Manufacturing
{
    using VehicleComponents;
    using Vehicles;
    using Utils;
    using System.Linq.Expressions;

    public class ManufacturingPlant
    {
        readonly float r_MaxRegularCarEnergyCapacity = 45;
        readonly float r_MaxElectricityCarEnergyCapacity = 3.5f;

        public Car CreateNewRegularCar(string i_LicenseNumber, float i_EnergyAvailable, List<Tire> m_VehicleTires, eCarColors i_Color, eCarDoors i_NumOfDoors)
        {
            Engine newCarEngine = new Engine(eEnergyType.Octan95, eEngineType.Gasoline);
            return new Car(i_LicenseNumber, r_MaxRegularCarEnergyCapacity, newCarEngine, i_EnergyAvailable, i_Color, i_NumOfDoors);
        }
        public Car CreateNewElectricityCar(string i_LicenseNumber, float i_EnergyAvailable, List<Tire> m_VehicleTires, eCarColors i_Color, eCarDoors i_NumOfDoors)
        {
            Engine newCarEngine = new Engine(eEnergyType.Electric, eEngineType.Electricity);
            return new Car(i_LicenseNumber,r_MaxElectricityCarEnergyCapacity, newCarEngine, i_EnergyAvailable, i_Color, i_NumOfDoors);
        }
    

    }
}
/*
המשתמש בוחר את סוג הרכב שהוא מעוניין להכניס למוסך
:ואז מזין את מצבו 
    כמות הדלק או מצב המצבר
    כמות האוויר בגלגלים
    +
    מאפייני הכלי רכב
    */