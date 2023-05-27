using System;
using System.Collections.Generic;
using System.Text;

using Ex03.GarageLogic.Models;

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
            if (IsVehicleInGarage(i_LicensePlate))
            {
                this.m_Vehicles[i_LicensePlate.GetHashCode()].UpdateProperties(i_PropertiesToUpdate);
            }
            else
            {
                throw new ArgumentException("A Vehicle with the entered license plate is not found");
            }
        }

        public bool IsVehicleInGarage(string i_LicensePlate)
        {
            return m_Vehicles.ContainsKey(i_LicensePlate.GetHashCode());
        }

        public IEnumerable<string> AddNewVehicle(string i_VehicleType, string i_LicensePlate, string i_CustomerName, string i_CustomerPhoneNumber)
        {
            Vehicle vehicle = VehicleFactory.GetVehicle(i_VehicleType);

            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }

            CustomerTicket customerTicket = new CustomerTicket
            {
                LicensePlate = i_LicensePlate,
                CustomerName = i_CustomerName,
                CustomerPhone = i_CustomerPhoneNumber,
                VehicleStatus = eVehicleStatus.InWork
            };

            vehicle.LicensePlate = i_LicensePlate;
            m_Vehicles.Add(vehicle.GetHashCode(), vehicle);
            m_CustomersTickets.Add(vehicle.GetHashCode(), customerTicket);

            return vehicle.GetPropertiesNames();
        }

        public string GetAllLicensePlatesByStatus(string i_VehicleStatusToFilter)
        {
            eVehicleStatus vehicleStatusToFilter = parseVehicleStatus(i_VehicleStatusToFilter);
            StringBuilder allLicensePlates = new StringBuilder();

            foreach (KeyValuePair<int, CustomerTicket> customerTicket in m_CustomersTickets)
            {
                if (customerTicket.Value.VehicleStatus == vehicleStatusToFilter)
                {
                    allLicensePlates.AppendLine(customerTicket.Value.LicensePlate);
                }
            }

            return allLicensePlates.ToString();
        }

        public string GetAllLicensePlates()
        {
            StringBuilder allLicensePlates = new StringBuilder();

            foreach (KeyValuePair<int, CustomerTicket> customerTicket in m_CustomersTickets)
            {
                allLicensePlates.AppendLine(customerTicket.Value.LicensePlate);
            }

            return allLicensePlates.ToString();
        }

        public void InflateVehicleWheelsToMax(string i_LicensePlate)
        {
            if (IsVehicleInGarage(i_LicensePlate))
            {
                this.m_Vehicles[i_LicensePlate.GetHashCode()].InflateWheelsToMax();
            }
            else
            {
                throw new ArgumentException("A Vehicle with the entered license plate is not found");
            }
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

        public string GetVehicleDetails(string i_LicensePlate)
        {
            StringBuilder vehicleDetails = new StringBuilder();

            Vehicle vehicle = m_Vehicles[i_LicensePlate.GetHashCode()];
            CustomerTicket customerTicket = m_CustomersTickets[i_LicensePlate.GetHashCode()];

            vehicleDetails.AppendLine(vehicle.ToString());
            vehicleDetails.AppendLine(customerTicket.ToString());

            return vehicleDetails.ToString();
        }

        public void SetVehicleStatus(string i_LicensePlate, string i_VehicleStatus)
        {

            eVehicleStatus vehicleStatus = parseVehicleStatus(i_VehicleStatus);

            CustomerTicket customersTicket = m_CustomersTickets[i_LicensePlate.GetHashCode()];

            if (IsVehicleInGarage(i_LicensePlate))
            {
                customersTicket.VehicleStatus = vehicleStatus;
            }
            else
            {
                throw new ArgumentException("A Vehicle with the entered license plate is not found");
            }
        }

        private eVehicleStatus parseVehicleStatus(string i_VehicleStatus)
        {
            Enum.TryParse(i_VehicleStatus, ignoreCase: true, out eVehicleStatus vehicleStatus);

            if (vehicleStatus.Equals(eVehicleStatus.None))
            {
                throw new FormatException("invalid status");
            }
            else
            {
                return vehicleStatus;
            }
        }

        public string GetSupportedVehiclesNames()
        {
            StringBuilder supportedVehicles = new StringBuilder();
            short index = 1;

            foreach (Enum vehicleType in Enum.GetValues(typeof(eVehicleType)))
            {

                if (vehicleType.ToString() == "None")
                {
                    continue;
                }

                supportedVehicles.Append($"{index}. {vehicleType} \n");
                ++index;
            }

            return supportedVehicles.ToString();
        }
    }
}