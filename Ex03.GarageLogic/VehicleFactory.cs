using System;
using Ex03.GarageLogic.Models;


namespace Ex03.GarageLogic
{
    internal static class VehicleFactory
    {
        public static Vehicle GetVehicle(string i_VehicleType)
        {
            Vehicle vehicle = null;
            Enum.TryParse(i_VehicleType, ignoreCase: true, out eVehicleType vehicleType);

            if (vehicleType.Equals(eVehicleType.Car))
            {
                vehicle = new Car();
            }
            else if (vehicleType.Equals(eVehicleType.Motorcycle))
            {
                vehicle = new Motorcycle();
            }
            else if (vehicleType.Equals(eVehicleType.Truck))
            {
                vehicle = new Truck();
            }

            return vehicle;
        }
    }
}
