namespace Ex03.GarageLogic;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Utils;

public class VehicleServiceInfo
{
    private string m_OwnersVehicleName { get; set; }
    private string m_OwnersVehiclePhone { get; set; }
    private Vehicle m_OwnersVehicle;
    private string m_VehicleLicenseNumber;
    private eGarageVehicleStatus m_VehicleStatus { get; set; }

    public VehicleServiceInfo(Vehicle i_OwnersVehicle, string i_OwnersVehicleName, string i_OwnersVehiclePhone)
    {
        this.m_OwnersVehicle = i_OwnersVehicle;
        this.m_VehicleLicenseNumber = i_OwnersVehicle.LicenseNumber;
        this.m_VehicleStatus = eGarageVehicleStatus.ServiceInProgress;
        this.m_OwnersVehicleName = i_OwnersVehicleName;
        this.m_OwnersVehicleName = i_OwnersVehiclePhone;
    }
    public string GetVehicleLicenseNumber()
    {
        return m_VehicleLicenseNumber;
    }
    public Vehicle GetVehicle()
    {
        return m_OwnersVehicle;
    }
    public
}
