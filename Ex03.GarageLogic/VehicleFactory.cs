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

            EnergySource vehicleEnergySource = getEnergySource(vehicleType);

            if (vehicleType.Equals(eVehicleType.ElectricCar) | vehicleType.Equals(eVehicleType.FuelCar))
            {
                const int k_NumWheels = 5;
                const float k_MaxWheelsPressure = 33f;

                vehicle = new Car(k_NumWheels, k_MaxWheelsPressure)
                {
                    EnergySource = vehicleEnergySource
                };
            }
            else if (vehicleType.Equals(eVehicleType.ElectricMotorcycle) | vehicleType.Equals(eVehicleType.FuelMotorcycle))
            {
                const int k_NumWheels = 2;
                const float k_MaxWheelsPressure = 31f;

                vehicle = new Motorcycle(k_NumWheels, k_MaxWheelsPressure)
                {
                    EnergySource = vehicleEnergySource
                };
            }
            else if (vehicleType.Equals(eVehicleType.Truck))
            {
                const int k_NumWheels = 14;
                const float k_MaxWheelsPressure = 26f;

                vehicle = new Truck(k_NumWheels, k_MaxWheelsPressure)
                {
                    EnergySource = vehicleEnergySource
                };
            }

            return vehicle;
        }

        private static EnergySource getEnergySource(eVehicleType i_VehicleType)
        {
            EnergySource energySourceToSet = null;

            if (i_VehicleType.Equals(eVehicleType.ElectricCar))
            {
                const float k_BatteryCapacityTime = 2.6f;
                energySourceToSet = new ElectricBattery(k_BatteryCapacityTime);
            }
            else if (i_VehicleType.Equals(eVehicleType.FuelCar))
            {
                const eFuelType k_FuelType = eFuelType.Octan95;
                const float k_TankCapacity = 46f;
                energySourceToSet = new FuelTank(k_FuelType, k_TankCapacity);
            }
            else if (i_VehicleType.Equals(eVehicleType.ElectricMotorcycle))
            {
                const float k_BatteryCapacityTime = 5.2f;
                energySourceToSet = new ElectricBattery(k_BatteryCapacityTime);
            }
            else if (i_VehicleType.Equals(eVehicleType.FuelMotorcycle))
            {
                const eFuelType k_FuelType = eFuelType.Octan98;
                const float k_TankCapacity = 6.4f;
                energySourceToSet = new FuelTank(k_FuelType, k_TankCapacity);
            }
            else if (i_VehicleType.Equals(eVehicleType.Truck))
            {
                const eFuelType k_FuelType = eFuelType.Soler;
                const float k_TankCapacity = 135f;
                energySourceToSet = new FuelTank(k_FuelType, k_TankCapacity);
            }

            return energySourceToSet;
        }
    }
}
