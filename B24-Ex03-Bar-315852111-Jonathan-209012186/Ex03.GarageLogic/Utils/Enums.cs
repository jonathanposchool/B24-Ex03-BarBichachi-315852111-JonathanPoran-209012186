namespace Ex03.GarageLogic.Utils
{
    public enum eGarageVehicleStatus
    {
        ServiceInProgress,
        ServiceCompleted,
        PaidAndReleased
    }

    public enum eQustionsForManufacturing
    {
        Electric,
        CarColor = 0,
        CarNumberOfDoors,
        MotorcycleLicenseType,
        MotorcycleEngineCapacity,
        TrackCarryingDangerousMaterial,
        TrakCargoVolume,
    }

    public enum eEnergyType
    {
        Electric,
        Soler,
        Octan95,
        Octan96,
        Octan98,
    }

    public enum eEngineType
    {
        Combustion,
        Electricity
    }

    public enum eLicenseType
    {
        A,
        A1,
        AA,
        B1
    }

    public enum eCarColors
    {
        Yellow,
        White,
        Red,
        Black
    }

    public enum eCarDoors
    {
        TwoDoors = 2,
        ThreeDoors,
        FourDoors,
        FiveDoors
    }
}
