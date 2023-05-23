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
