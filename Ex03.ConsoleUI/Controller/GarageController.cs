using Ex03.GarageLogic;
using System.ComponentModel;
using System.Reflection;
using System;
using System.Text;
using Ex03.ConsoleUI.Resources;

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

                do
                {
                    getUserOptionsInput(out string userInput);
                    isUserInputValid(userInput, out serviceOptionToInvoke);
                }
                while (serviceOptionToInvoke.Equals(eMenuOptions.None));

                clearConsole();


            }

            //switch case

            //exit message
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

            if (Enum.IsDefined(typeof(eMenuOptions), i_UserInputToValidate))
            {
                Enum.TryParse(i_UserInputToValidate, out inputResult);
            }
            else
            {
                displayMessage(eUserMessages.InvalidUserChoiceMessage);
            }
        }
    }
}