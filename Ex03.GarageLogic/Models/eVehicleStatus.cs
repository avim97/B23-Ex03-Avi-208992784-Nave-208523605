using System;

namespace Ex03.GarageLogic.Models
{
    [Flags]
    public enum eVehicleStatuses
    {
        InWork,
        Fixed,
        Payed
    }
}