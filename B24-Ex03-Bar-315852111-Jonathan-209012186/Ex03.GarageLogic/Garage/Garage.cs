namespace Ex03.GarageLogic;
using Vehicles;

public class Garage
{
    private SortedDictionary<string, VehicleServiceInfo> m_GarageDatabase = new SortedDictionary<string, VehicleServiceInfo>();   
    
    public bool IsVehicleInGarage(string i_LicenseNumber)
    {
        bool carIsNotKnownForGarge = true;
        if (m_GarageDatabase.ContainsKey(i_LicenseNumber))
        {
            carIsNotKnownForGarge = false;
        }
        return carIsNotKnownForGarge;
    }

    public Vehicle GetVehicleByLicenseNumber(string i_LicenseNumber)
    {
        if (m_GarageDatabase.TryGetValue(i_LicenseNumber, out VehicleServiceInfo wantedVehicleServiceInfo))
        {
            return wantedVehicleServiceInfo.GetVehicle();
        }
        else
        {
            return null;
            // Todo throw new Exception
        }
    }
}



/*
        insert new car to Garage
        show garge vehicle list status with filters
        Garage change status
        Garage -> fill up air wheel to max
        garage -> fill uo fuel/electricity
        garage -> show car
        enum car status of garage(payed/onwork and so) 
*/