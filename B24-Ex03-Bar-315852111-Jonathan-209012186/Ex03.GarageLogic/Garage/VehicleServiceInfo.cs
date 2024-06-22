using Ex03.GarageLogic.Utils;
using Ex03.GarageLogic.Vehicles;

internal class VehicleServiceInfo
{
    private string m_OwnersVehicleName;
    private string m_OwnersVehiclePhone;
    private Vehicle m_OwnersVehicle;
    internal eVehicleTypes m_VehicleType { get;}
    internal eGarageVehicleStatus m_VehicleStatus;

    internal VehicleServiceInfo(string i_OwnersName, string i_OwnersPhone, Vehicle i_NewVehicle, eVehicleTypes i_VehicleType)
    {
        m_OwnersVehicle = i_NewVehicle;
        m_VehicleType = i_VehicleType;
        m_VehicleStatus = eGarageVehicleStatus.ServiceInProgress;
        m_OwnersVehicleName = i_OwnersName;
        m_OwnersVehiclePhone = i_OwnersPhone;
    }

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
