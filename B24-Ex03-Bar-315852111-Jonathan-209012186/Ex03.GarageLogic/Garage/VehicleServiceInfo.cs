using Ex03.GarageLogic.Utils;
using Ex03.GarageLogic.Vehicles;

internal class VehicleServiceInfo
{
    private string m_OwnersVehicleName;
    private string m_OwnersVehiclePhone;
    private Vehicle? m_OwnersVehicle;
    private eGarageVehicleStatus m_VehicleStatus;

    public string OwnersLicenseNumber
    {
        get { return m_OwnersVehicle.LicenseNumber; }
    }
    internal Vehicle OwnersVehicle
    {
        get { return m_OwnersVehicle; }
    }
    internal eGarageVehicleStatus VehicleStatus
    {
        get { return m_VehicleStatus; }
        set { m_VehicleStatus = value; }
    }
    public VehicleServiceInfo(Vehicle i_OwnersVehicle)
    {
        m_OwnersVehicle = i_OwnersVehicle;
        m_VehicleStatus = eGarageVehicleStatus.ServiceInProgress;
        m_OwnersVehicleName = null;
        m_OwnersVehiclePhone = null;
    }

    public VehicleServiceInfo(Vehicle i_OwnersVehicle, string i_OwnersVehicleName, string i_OwnersVehiclePhone)
    {
        m_OwnersVehicle = i_OwnersVehicle;
        m_VehicleStatus = eGarageVehicleStatus.ServiceInProgress;
        m_OwnersVehicleName = i_OwnersVehicleName;
        m_OwnersVehiclePhone = i_OwnersVehiclePhone;
    }

    
}
