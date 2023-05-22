using System;
using Ex03.GarageLogic.Models;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManagerService
    {
        private readonly Dictionary<int, CustomerTicket> m_CustomersTickets;

        private readonly Dictionary<int,Vehicle> m_Vehicles;

        public void UpdateProperties(Dictionary<string, string> i_PropertiesToUpdate)
        {
            Enum.TryParse(i_PropertiesToUpdate["VehicleType"], true, out eVehicleType vehicleType);

            if(vehicleType.Equals(eVehicleType.Car))
            {
                //UpdateCarAttributes(...)
            }
        }



        //This method returns a new instance of a vehicle type from the VehicleFactory
        // and adds the new vehicle to the garage's dictionary
        public bool AssertVehicleInGarage(string i_LicensePlate)
        {
            return m_Vehicles.ContainsKey(i_LicensePlate.GetHashCode());
        }

        //  This method returns a new instance of a vehicle type from the VehicleFactory
        //  and adds the new vehicle to the garage's dictionary
        public IEnumerable<string> AddNewVehicle(string i_VehicleType, string i_LicensePlate, string i_OwnerName, string i_OwnerPhone)
        {
            Vehicle vehicle = VehicleFactory.GetVehicle(i_VehicleType);
            vehicle.LicensePlate = i_LicensePlate;
            m_Vehicles.Add(vehicle.GetHashCode(), vehicle);

            return vehicle.GetPropertiesNames();
        }

        public StringBuilder GetAllVehicles()
        {
            StringBuilder allVehicles = new StringBuilder();
            foreach(KeyValuePair<int, Vehicle> vehicle in m_Vehicles)
            {
                allVehicles.AppendLine(vehicle.Value.ToString());
            }

            return allVehicles;
        }

        public StringBuilder GetAllLicensePlatesByStatus(eVehicleStatuses i_vehicleStatus)
        {
            StringBuilder allLicensePlates = new StringBuilder();
            foreach(KeyValuePair<int, CustomerTicket> customerTicket in m_CustomersTickets)
            {
                if(customerTicket.Value.VehicleStatus == i_vehicleStatus)
                {
                    allLicensePlates.AppendLine(customerTicket.Key.ToString());
                }
            }

            return allLicensePlates;
        }

        public void ChangeVehicleStatus(string i_licensePlate, eVehicleStatuses i_vehicleStatus)
        {
            CustomerTicket ticketToChangeStatus = m_CustomersTickets[Convert.ToInt32(i_licensePlate)];
            ticketToChangeStatus.VehicleStatus = i_vehicleStatus;
        }


        //todo: complete function
        public void InflateWheelsToMax(string i_licensePlate)
        {
            // Vehicle vehicleToInflate = m_Vehicles[Convert.ToInt32(i_licensePlate)];
            // foreach(Wheel wheel in vehicleToInflate.Wheels)
            // {
            //     wheel.InflateWheel(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            // }
        }


        //todo: complete function

        //public void FuelVehicle(string i_licensePlate, eFuelType i_fuelType, float i_amountOfFuelToAdd)
        //{
        //    // Vehicle vehicleToRefuel = m_Vehicles[Convert.ToInt32(i_licensePlate)];
        //    // if(vehicleToRefuel.EnergySource is FuelSource)
        //    // {
        //    //     FuelSource fuelSource = vehicleToRefuel.EnergySource as FuelSource;
        //    //     fuelSource.Refuel(i_fuelType, i_amountOfFuelToAdd);
        //    // }
        //    // else
        //    // {
        //    //     throw new ArgumentException("Vehicle is not fuel based");
        //    // }
        //}


        //todo: complete function

        public void ChargeVehicle(string i_licensePlate, float i_amountOfMinutesToAdd)
        {
            // Vehicle vehicleToCharge = m_Vehicles[Convert.ToInt32(i_licensePlate)];
            // if(vehicleToCharge.EnergySource is ElectricSource)
            // {
            //     ElectricSource electricSource = vehicleToCharge.EnergySource as ElectricSource;
            //     electricSource.Charge(i_amountOfMinutesToAdd);
            // }
            // else
            // {
            //     throw new ArgumentException("Vehicle is not electric based");
            // }
        }


        //todo: complete function

        public StringBuilder GetVehicleDetails(string i_licensePlate)
        {
            StringBuilder vehicleDetails = new StringBuilder();
            vehicleDetails.AppendLine(m_Vehicles[Convert.ToInt32(i_licensePlate)].ToString());
            vehicleDetails.AppendLine(m_CustomersTickets[Convert.ToInt32(i_licensePlate)].ToString());
            return vehicleDetails;
        }
    }
}