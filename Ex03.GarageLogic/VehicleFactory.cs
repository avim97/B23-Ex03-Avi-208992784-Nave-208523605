using System;
using System.Collections.Generic;
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
                const int k_NumWheels = 5;
                const float k_MaxWheelsPressure = 33f;

                vehicle = new Car(k_NumWheels, k_MaxWheelsPressure);
            }
            else if (vehicleType.Equals(eVehicleType.Motorcycle))
            {
                const int k_NumWheels = 2;
                const float k_MaxWheelsPressure = 31f;

                vehicle = new Motorcycle(k_NumWheels, k_MaxWheelsPressure);
            }
            else if (vehicleType.Equals(eVehicleType.Truck))
            {
                const int k_NumWheels = 14;
                const float k_MaxWheelsPressure = 26f;

                vehicle = new Truck(k_NumWheels, k_MaxWheelsPressure);
            }

            return vehicle;
        }

        private static EnergySource getEnergySource(string i_EnergySourceType)
        {

            EnergySource energySourceToSet = null;

            Enum.TryParse(i_EnergySourceType, ignoreCase: true, out eEnergySourceType energySourceType);

            if (energySourceType.Equals(eEnergySourceType.Electric))
            {
                energySourceToSet = new ElectricBattery();
            }
            else if (energySourceType.Equals(eEnergySourceType.Fuel))
            {
                energySourceToSet = new FuelTank();
            }

            return energySourceToSet;
        }
    }
}
