﻿using Ex03.GarageLogic.Utils;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic.Garage
{
    internal class VehicleServiceInfo
    {
        internal string OwnersVehicleName { get; }
        internal string OwnersVehiclePhone { get; }
        internal Vehicle OwnersVehicle { get; }
        internal eVehicleTypes VehicleType { get; }
        internal eGarageVehicleStatus VehicleStatus { get; set; }

        internal VehicleServiceInfo(string i_OwnersName, string i_OwnersPhone, Vehicle i_NewVehicle, eVehicleTypes i_VehicleType)
        {
            OwnersVehicleName = i_OwnersName;
            OwnersVehiclePhone = i_OwnersPhone;
            OwnersVehicle = i_NewVehicle;
            VehicleType = i_VehicleType;
            VehicleStatus = eGarageVehicleStatus.ServiceInProgress;
        }
    }
}
