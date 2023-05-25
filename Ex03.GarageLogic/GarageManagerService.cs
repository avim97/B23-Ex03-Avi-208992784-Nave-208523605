using System;
using Ex03.GarageLogic.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManagerService
    {
        private readonly Dictionary<int, CustomerTicket> m_CustomersTickets;

        private readonly Dictionary<int, Vehicle> m_Vehicles;

        public GarageManagerService()
        {
            m_CustomersTickets = new Dictionary<int, CustomerTicket>();
            m_Vehicles = new Dictionary<int, Vehicle>();
        }

        public void UpdateProperties(string i_LicensePlate, Dictionary<string, string> i_PropertiesToUpdate)
        {
            //Enum.TryParse(i_PropertiesToUpdate["VehicleType"], true, out eVehicleType vehicleType);

            //if(vehicleType.Equals(eVehicleType.Car))
            //{
            //    //UpdateCarAttributes(...)                check if needed
            //}

            if (IsVehicleInGarage(i_LicensePlate))
            {
                this.m_Vehicles[i_LicensePlate.GetHashCode()].UpdateProperties(i_PropertiesToUpdate);
            }
            else
            {
                throw new ArgumentException("A Vehicle with the entered license plate is not found");
            }
        }

        //This method returns a new instance of a vehicle type from the VehicleFactory
        // and adds the new vehicle to the garage's dictionary
        public bool IsVehicleInGarage(string i_LicensePlate)
        {
            return m_Vehicles.ContainsKey(i_LicensePlate.GetHashCode());
        }

        //  This method returns a new instance of a vehicle type from the VehicleFactory
        //  and adds the new vehicle to the garage's dictionary
        public IEnumerable<string> AddNewVehicle(string i_VehicleType, string i_LicensePlate, string i_CustomerName, string i_CustomerPhoneNumber)
        {
            Vehicle vehicle = VehicleFactory.GetVehicle(i_VehicleType);
            CustomerTicket customerTicket = new CustomerTicket
            {
                CustomerName = i_CustomerName,
                CustomerPhone = i_CustomerPhoneNumber,
                VehicleStatus = eVehicleStatuses.InWork
            };

            vehicle.LicensePlate = i_LicensePlate;
            m_Vehicles.Add(vehicle.GetHashCode(), vehicle);
            m_CustomersTickets.Add(vehicle.GetHashCode(), customerTicket);

            return vehicle.GetPropertiesNames();
        }

        public string GetAllVehicles()
        {
            StringBuilder allVehicles = new StringBuilder();

            foreach (KeyValuePair<int, Vehicle> vehicle in m_Vehicles)
            {
                allVehicles.AppendLine(vehicle.Value.ToString());
            }

            return allVehicles.ToString();
        }

        public string GetAllLicensePlatesByStatus(eVehicleStatuses i_VehicleStatusToFilter)
        {
            StringBuilder allLicensePlates = new StringBuilder();

            foreach (KeyValuePair<int, CustomerTicket> customerTicket in m_CustomersTickets)
            {
                if (customerTicket.Value.VehicleStatus == i_VehicleStatusToFilter)
                {
                    allLicensePlates.AppendLine(customerTicket.Key.ToString());
                }
            }

            return allLicensePlates.ToString();
        }

        public void ChangeVehicleStatus(string i_LicensePlate, eVehicleStatuses i_VehicleStatus) //TODO
        {
            CustomerTicket ticketToChangeStatus = m_CustomersTickets[Convert.ToInt32(i_LicensePlate)];
            ticketToChangeStatus.VehicleStatus = i_VehicleStatus;
        }

        public void InflateVehicleWheelsToMax(string i_LicensePlate) //TODO
        {
            Vehicle vehicleToInflate = m_Vehicles[i_LicensePlate.GetHashCode()];

            vehicleToInflate.InflateWheelsToMax();
        }

        public void FuelVehicle(string i_LicensePlate, string i_FuelType, string i_FuelAmountToAdd)
        {
            Vehicle vehicleToFuel = m_Vehicles[i_LicensePlate.GetHashCode()];

            bool isExistingFuelType = Enum.TryParse(i_FuelType, ignoreCase: true, out eFuelType fuelType);

            if (isExistingFuelType)
            {
                if (vehicleToFuel.EnergySource is FuelTank fuelTank)
                {
                    float.TryParse(i_FuelAmountToAdd, out float fuelAmountToAdd);

                    if (fuelAmountToAdd > 0)
                    {
                        fuelTank.FillTank(fuelAmountToAdd, fuelType);
                    }

                }
                else
                {
                    throw new ArgumentException("Vehicle selected energy source is not fuel based");
                }
            }
            else
            {
                throw new FormatException("Fuel type does not exist");
            }
        }

        public void ChargeVehicle(string i_LicensePlate, string i_ChargingTimeToAdd)
        {
            Vehicle vehicleToCharge = m_Vehicles[i_LicensePlate.GetHashCode()];

            if (vehicleToCharge.EnergySource is ElectricBattery electricBattery)
            {
                float.TryParse(i_ChargingTimeToAdd, out float chargingTimeToAdd);

                if (chargingTimeToAdd > 0)
                {
                    electricBattery.ChargeBattery(chargingTimeToAdd);
                }
            }
            else
            {
                throw new ArgumentException("Vehicle selected energy source is not  based");
            }
        }

        public StringBuilder GetVehicleDetails(string i_licensePlate) //TODO
        {
            StringBuilder vehicleDetails = new StringBuilder();
            vehicleDetails.AppendLine(m_Vehicles[Convert.ToInt32(i_licensePlate)].ToString());
            vehicleDetails.AppendLine(m_CustomersTickets[Convert.ToInt32(i_licensePlate)].ToString());
            return vehicleDetails;
        }
    }
}