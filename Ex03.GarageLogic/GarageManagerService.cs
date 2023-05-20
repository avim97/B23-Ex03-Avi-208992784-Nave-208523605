using System;
using Ex03.GarageLogic.Models;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManagerService
    {
        private Dictionary<int, CustomerTicket> m_CustomersTickets;

        private Dictionary<int, Vehicle> m_Vehicles;

        //todo: complete function
        public void InsertNewVehicle(string i_licensePlate, string i_ownerName, string i_ownerPhone, Vehicle i_vehicle)
        {
            //if (m_Vehicles.ContainsKey(i_licensePlate))
            //{
            //set the eVihecleStatus to InWork in the CustomerTicket
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