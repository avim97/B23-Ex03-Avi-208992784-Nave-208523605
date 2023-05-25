using Ex03.GarageLogic;
using System.ComponentModel;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Text;
using Ex03.ConsoleUI.Resources;
using Ex03.GarageLogic.Models;

namespace Ex03.ConsoleUI.Controller
{
    public class GarageController
    {
        private readonly GarageManagerService r_GarageManagerService;
        private bool isRunning = true;

        public GarageController()
        {
            r_GarageManagerService = new GarageManagerService();

        }

        public void Start()
        {
            while (isRunning)
            {
                eMenuOptions serviceOptionToInvoke;

                displayMessage(eUserMessages.HelloMessage);
                displayMenuOptions();
                serviceOptionToInvoke = getMenuOptionFromUser();

                if (serviceOptionToInvoke == eMenuOptions.ChooseToInsertNewVehicle)
                {
                    handleVehicleInsertion();

                }

                Console.ReadKey();


                // clearConsole();


            }

            //switch case

            //exit message
        }

        private eMenuOptions getMenuOptionFromUser()
        {
            eMenuOptions serviceOptionToInvoke;

            do
            {

                getUserOptionsInput(out string userInput);
                isUserInputValid(userInput, out serviceOptionToInvoke);
            }
            while (serviceOptionToInvoke.Equals(eMenuOptions.None));
            return serviceOptionToInvoke;
        }

        private void clearConsole()
        {
            Console.Clear();
        }

        private void displayMessage(Enum i_Message)
        {
            FieldInfo messageFieldInfo = i_Message.GetType().GetField(i_Message.ToString());
            DescriptionAttribute[] descriptionAttribute = messageFieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            Console.WriteLine(descriptionAttribute?[0].Description);
        }

        private void displayMessage(string i_Message)
        {
            Console.WriteLine(i_Message);
        }

        private void displayMenuOptions()
        {
            foreach (Enum menuOption in Enum.GetValues(typeof(eMenuOptions)))
            {
                displayMessage(menuOption);
                Console.WriteLine();
            }
        }

        private void getUserOptionsInput(out string o_UserInput)
        {
            o_UserInput = Console.ReadLine();
        }

        private void isUserInputValid(string i_UserInputToValidate, out eMenuOptions inputResult)
        {
            inputResult = eMenuOptions.None;

            bool isUserInputNumeric = Int32.TryParse(i_UserInputToValidate, out int userInputAsInt);

            if (isUserInputNumeric && Enum.IsDefined(typeof(eMenuOptions), userInputAsInt))
            {
                Enum.TryParse(i_UserInputToValidate, out inputResult);
            }
            else
            {
                displayMessage(eUserMessages.InvalidUserChoiceMessage);
            }
        }

        private void handleVehicleInsertion()
        {
            bool propertySuccess = false, ticketSuccess = false;
            IEnumerable<string> propertiesNames = null;
            displayMessage(eUserMessages.EnterLicensePlateNumberMessage);
            getUserOptionsInput(out string licensePlateNumber);
            if (r_GarageManagerService.IsVehicleInGarage(licensePlateNumber))
            {
                displayMessage(eUserMessages.VehicleIsAlreadyInGarageMessage);
                try
                {
                    string k_InWork = eVehicleStatus.InWork.ToString();
                    r_GarageManagerService.SetVehicleStatus(licensePlateNumber, k_InWork);
                }
                catch (Exception ex)
                {
                    displayMessage(ex.Message);
                }
            }
            else
            {
                while (!ticketSuccess)
                {
                    displayMessage(eUserMessages.EnterVehicleTypeMessage);
                    getUserOptionsInput(out string vehicleType);
                    displayMessage(eUserMessages.EnterCustomerNameMessage);
                    getUserOptionsInput(out string customerName);
                    displayMessage(eUserMessages.EnterCustomerPhoneNumberMessage);
                    getUserOptionsInput(out string customerPhoneNumber);
                    try
                    {
                        propertiesNames =
                            r_GarageManagerService.AddNewVehicle(
                            vehicleType,
                            licensePlateNumber,
                            customerName,
                            customerPhoneNumber);

                        ticketSuccess = true;
                    }
                    catch (Exception ex)
                    {
                        displayMessage(ex.Message);
                    }
                }

                while (!propertySuccess)
                {
                    foreach (string propertyName in propertiesNames)
                    {
                        Dictionary<string, string> userInputProperties = new Dictionary<string, string>();
                        string message = $@"Please enter {propertyName}:";
                        displayMessage(message);
                        userInputProperties.Add(propertyName, Console.ReadLine());
                        try
                        {
                            r_GarageManagerService.UpdateProperties(licensePlateNumber, userInputProperties);
                            propertySuccess = true;
                        }
                        catch (Exception ex)
                        {
                            displayMessage(ex.Message);
                            break;
                        }
                    }
                }
            }
        }
    }
}