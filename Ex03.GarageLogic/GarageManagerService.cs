using System;
using Ex03.GarageLogic.Models;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManagerService
    {
        private readonly Dictionary<int, CustomerTicket> m_CustomersTickets;

        private readonly Dictionary<int,Vehicle> m_Vehicles;

        //todo: complete function

        //This method returns a new instance of a vehicle type from the VehicleFactory
        // and adds the new vehicle to the garage's dictionary
        private void createVehicle(string i_VehicleType)
        {
            Vehicle vehicle = VehicleFactory.GetVehicle(i_VehicleType);
            m_Vehicles.Add(vehicle.GetHashCode(), vehicle);
        }

        public void SetVehicleEnergySource(string i_LicensePlate, string i_EnergySourceType)
        {
            Vehicle vehicle = m_Vehicles[i_LicensePlate.GetHashCode()];
            //create an enum for energysource type ?
        }

        public void SetVehicleEnergySource(string i_V)
        //This method asserts that the a vehicle is in the garage by its license plate, return true if it is, false otherwise.
        public bool AssertVehicleInGarage(string i_LicensePlate)
        {
            return m_Vehicles.ContainsKey(i_LicensePlate.GetHashCode());
        }

        public void AddNewVehicle(string i_VehicleType, string i_LicensePlate, string i_OwnerName, string i_OwnerPhone)
        {
            //if (m_Vehicles.ContainsKey(i_licensePlate))
            //{
            //set the eVehicleStatus to InWork in the CustomerTicket
            //    throw new ArgumentException("Vehicle already exists in the garage");
            //}

            // CustomerTicket customerTicket = new CustomerTicket(i_ownerName, i_ownerPhone, i_vehicle);
            // m_CustomersTickets.Add(i_licensePlate, customerTicket);
            // m_Vehicles.Add(i_licensePlate, i_vehicle);
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

        public void RefuelVehicle(string i_licensePlate, eFuelTypes i_fuelType, float i_amountOfFuelToAdd)
        {
            // Vehicle vehicleToRefuel = m_Vehicles[Convert.ToInt32(i_licensePlate)];
            // if(vehicleToRefuel.EnergySource is FuelSource)
            // {
            //     FuelSource fuelSource = vehicleToRefuel.EnergySource as FuelSource;
            //     fuelSource.Refuel(i_fuelType, i_amountOfFuelToAdd);
            // }
            // else
            // {
            //     throw new ArgumentException("Vehicle is not fuel based");
            // }
        }


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