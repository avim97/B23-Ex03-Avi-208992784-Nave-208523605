﻿using Ex03.GarageLogic;
using System.ComponentModel;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Ex03.ConsoleUI.Resources;
using Ex03.GarageLogic.Models;

namespace Ex03.ConsoleUI.Controller
{
    public class GarageController
    {
        private readonly GarageManagerService r_GarageManagerService;

        public GarageController()
        {
            r_GarageManagerService = new GarageManagerService();

        }

        public void Start()
        {
            bool isRunning = true;

            while (isRunning)
            {
                eMenuOptions serviceOptionToInvoke;

                printEnumMessage(eUserMessage.HelloMessage);
                displayMenuOptions();
                serviceOptionToInvoke = getMenuOptionFromUser();

                if (serviceOptionToInvoke == eMenuOptions.InsertNewVehicle)
                {
                    addNewVehicleToGarage();
                }

                else if (serviceOptionToInvoke == eMenuOptions.ShowAllLicensePlates)
                {
                    showAllLicensePlates();
                }
                else if (serviceOptionToInvoke == eMenuOptions.FilterAndShowLicensePlates)
                {
                    showAllLicensePlatesByStatus();
                }
                else if (serviceOptionToInvoke == eMenuOptions.ChangeVehicleStatus)
                {
                    changeVehicleStatus();
                }
                else if (serviceOptionToInvoke == eMenuOptions.InflateWheelsToMax)
                {
                    inflateAllWheelsToMax();
                }
                else if (serviceOptionToInvoke == eMenuOptions.FuelVehicle)
                {
                    fuelVehicle();
                }
                else if (serviceOptionToInvoke == eMenuOptions.ChargeVehicle)
                {
                    chargeVehicle();
                }
                else if (serviceOptionToInvoke == eMenuOptions.GetVehicleFullDetail)
                {
                    getVehicleFullDetail();
                }
                else if (serviceOptionToInvoke == eMenuOptions.Exit)
                {
                    printEnumMessage(eUserMessage.GoodbyeMessage);
                    isRunning = false;
                }

                if (isRunning)
                {
                    printEnumMessage(eUserMessage.PressAnyKeyToReturnToMainMenuMessage);
                    Console.ReadKey();
                    clearConsole();
                }
            }
        }

        private void showAllLicensePlatesByStatus()
        {
            displayVehicleStatusOptions();
            readUserInput(out string chosenStatusToFilterBy);
            printMessage(r_GarageManagerService.GetAllLicensePlatesByStatus(chosenStatusToFilterBy));
        }

        private void showAllLicensePlates()
        {
            printMessage(r_GarageManagerService.GetAllLicensePlates());
        }

        private void changeVehicleStatus()
        {
            bool changedVehicleStatus = false;
            string licensePlate = getValidLicensePlate();

            do
            {
                displayVehicleStatusOptions();
                string userInput = Console.ReadLine();

                try
                {
                    r_GarageManagerService.SetVehicleStatus(licensePlate, userInput);
                    changedVehicleStatus = true;
                }
                catch (Exception e)
                {
                    printMessage(e.Message);
                }
            }
            while (!changedVehicleStatus);
        }

        private eMenuOptions getMenuOptionFromUser()
        {
            eMenuOptions serviceOptionToInvoke;

            do
            {
                readUserInput(out string userInput);
                isUserMenuInputValid(userInput, out serviceOptionToInvoke);
            }
            while (serviceOptionToInvoke.Equals(eMenuOptions.None));

            return serviceOptionToInvoke;
        }

        private void clearConsole()
        {
            Console.Clear();
        }

        private void printEnumMessage(Enum i_Message)
        {
            Console.WriteLine(getDescriptionFromEnum(i_Message));
        }

        private string getDescriptionFromEnum(Enum i_Message)
        {
            FieldInfo messageFieldInfo = i_Message.GetType().GetField(i_Message.ToString());
            DescriptionAttribute[] descriptionAttribute = messageFieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            return descriptionAttribute?[0].Description;
        }

        private void printMessage(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        private void displayMenuOptions()
        {
            foreach (Enum menuOption in Enum.GetValues(typeof(eMenuOptions)))
            {
                printEnumMessage(menuOption);
                Console.WriteLine();
            }
        }

        private void displayVehicleStatusOptions()
        {
            StringBuilder message = new StringBuilder("Please enter the vehicle status: \n");

            foreach (eVehicleStatus vehicleStatus in Enum.GetValues(typeof(eVehicleStatus)))
            {
                if (vehicleStatus == eVehicleStatus.None)
                {
                    continue;
                }

                message.Append($"{vehicleStatus} , ");
            }

            message.Remove(message.Length - 2, 2);
            Console.WriteLine(message);
        }

        private void readUserInput(out string o_UserInput)
        {
            o_UserInput = Console.ReadLine();
        }

        private void isUserMenuInputValid(string i_UserInputToValidate, out eMenuOptions inputResult)
        {
            inputResult = eMenuOptions.None;

            bool isUserInputNumeric = Int32.TryParse(i_UserInputToValidate, out int userInputAsInt);

            if (isUserInputNumeric && Enum.IsDefined(typeof(eMenuOptions), userInputAsInt))
            {
                Enum.TryParse(i_UserInputToValidate, out inputResult);
            }
            else
            {
                printEnumMessage(eUserMessage.InvalidUserChoiceMessage);
            }
        }

        private void addNewVehicleToGarage()
        {
            bool isVehicleInGarage = false;
            IEnumerable<string> propertiesNames = null;

            string licensePlateNumber = getInputFromUser(eUserMessage.EnterLicensePlateNumberMessage);

            if (r_GarageManagerService.IsVehicleInGarage(licensePlateNumber))
            {
                printEnumMessage(eUserMessage.VehicleIsAlreadyInGarageMessage);

                try
                {
                    string inWork = eVehicleStatus.InWork.ToString();

                    r_GarageManagerService.SetVehicleStatus(licensePlateNumber, inWork);
                }
                catch (Exception ex)
                {
                    printMessage(ex.Message);
                }
            }
            else
            {
                while (!isVehicleInGarage)
                {
                    Console.WriteLine();

                    printEnumMessage(eUserMessage.EnterCustomerNameMessage);
                    string customerName = Console.ReadLine();

                    printEnumMessage(eUserMessage.EnterCustomerPhoneNumberMessage);
                    string customerPhoneNumber = Console.ReadLine();

                    printEnumMessage(eUserMessage.EnterVehicleTypeMessage);
                    printMessage(r_GarageManagerService.GetSupportedVehiclesNames());
                    string vehicleType = Console.ReadLine();

                    try
                    {
                        propertiesNames =
                            r_GarageManagerService.AddNewVehicle(
                            vehicleType,
                            licensePlateNumber,
                            customerName,
                            customerPhoneNumber);

                        isVehicleInGarage = true;
                    }
                    catch (Exception ex)
                    {
                        printMessage(ex.Message);
                    }
                }

                foreach (string propertyName in propertiesNames)
                {
                    string message = string.Format(getDescriptionFromEnum(eUserMessage.EnterPropertyMessage), propertyName);
                    bool isPropertyInputValid;

                    do
                    {
                        Dictionary<string, string> userInputProperties = new Dictionary<string, string>();
                        isPropertyInputValid = true;
                        string userInput = getInputFromUser(message);
                        userInputProperties.Add(propertyName, userInput); 

                        try
                        {
                            r_GarageManagerService.UpdateProperties(licensePlateNumber, userInputProperties);
                        }
                        catch (Exception ex)
                        {
                            printMessage(ex.Message);
                            isPropertyInputValid = false;
                        }
                    }
                    while(!isPropertyInputValid);
                }

            }
        }

        private string getValidLicensePlate()
        {
            string licensePlate = getInputFromUser(eUserMessage.EnterLicensePlateNumberMessage);

            while (!r_GarageManagerService.IsVehicleInGarage(licensePlate))
            {
                printEnumMessage(eUserMessage.InvalidInputMessage);
                licensePlate = getInputFromUser(eUserMessage.EnterLicensePlateNumberMessage);
            }

            return licensePlate;
        }

        private string getInputFromUser(eUserMessage i_InputMessage)
        {
            printEnumMessage(i_InputMessage);
            readUserInput(out string licensePlateNumber);

            return licensePlateNumber;
        }

        private string getInputFromUser(string i_InputMessage)
        {
            printMessage(i_InputMessage);
            readUserInput(out string userInput);

            return userInput;
        }

        private void fuelVehicle()
        {
            string licensePlate = getValidLicensePlate();
            string fuelType = getInputFromUser(eUserMessage.EnterFuelTypeMessage);
            string fuelAmountToAdd = getInputFromUser(eUserMessage.EnterFuelAmount);

            try
            {
                r_GarageManagerService.FuelVehicle(licensePlate, fuelType, fuelAmountToAdd);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void chargeVehicle()
        {
            string licensePlate = getValidLicensePlate();
            string chargineTime = getInputFromUser(eUserMessage.EnterChargingAmountTime);

            float.TryParse(chargineTime, out float chargingTimeInMinutesValue);
            float chargingTimeInHoursValue = chargingTimeInMinutesValue / 60;

            chargineTime = chargingTimeInHoursValue.ToString(CultureInfo.CurrentCulture);

            try
            {
                r_GarageManagerService.ChargeVehicle(licensePlate, chargineTime);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void getVehicleFullDetail()
        {
            string licensePlate = getValidLicensePlate();

            printMessage(r_GarageManagerService.GetVehicleDetails(licensePlate));
        }

        private void inflateAllWheelsToMax()
        {
            string licensePlateNumber = getValidLicensePlate();

            try
            {
                r_GarageManagerService.InflateVehicleWheelsToMax(licensePlateNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}