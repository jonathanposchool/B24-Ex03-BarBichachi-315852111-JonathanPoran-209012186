using Ex03.GarageLogic.Utils;
using Ex03.GarageLogic.Vehicles;

internal class VehicleServiceInfo
{
    private string m_OwnersVehicleName;
    private string m_OwnersVehiclePhone;
    private Vehicle m_OwnersVehicle; // TODO - What's that?
    internal eVehicleTypes m_VehicleType { get;}
    internal eGarageVehicleStatus m_VehicleStatus;
    internal string OwnersVehicleLicenseNumber
    {
        get { return m_OwnersVehicle.m_LicenseNumber; }
    }

    internal VehicleServiceInfo(string i_OwnersName, string i_OwnersPhone, Vehicle i_NewVehicle, eVehicleTypes i_VehicleType)
    {
        m_OwnersVehicle = i_NewVehicle; // TODO - What's that?
        m_VehicleType = i_VehicleType;
        m_VehicleStatus = eGarageVehicleStatus.ServiceInProgress;
        m_OwnersVehicleName = string.Empty;
        m_OwnersVehiclePhone = string.Empty;
    }
    // internal VehicleServiceInfo(Vehicle i_OwnersVehicle, string i_OwnersVehicleName, string i_OwnersVehiclePhone)
    // {
    //     m_OwnersVehicle = i_OwnersVehicle;
    //     m_VehicleStatus = eGarageVehicleStatus.ServiceInProgress;
    //     m_OwnersVehicleName = i_OwnersVehicleName;
    //     m_OwnersVehiclePhone = i_OwnersVehiclePhone;
    // }

    internal string OwnersName
    {
        set { m_OwnersVehicleName = value; }
        get { return m_OwnersVehicleName; }
    }
    internal string OwnersPhone
    {
        set { m_OwnersVehiclePhone = value; }
        get { return m_OwnersVehiclePhone; }
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
}
