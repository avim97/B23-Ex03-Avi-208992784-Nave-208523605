using Ex03.GarageLogic;
using System.ComponentModel;
using System.Reflection;
using System;
using Ex03.ConsoleUI.Resources;

namespace Ex03.ConsoleUI.Controller
{
    public class GarageController
    {
        private readonly GarageManagerService r_Garage;
        private bool isRunning = true;

        //todo: complete function
        public void Start()
        {
            while(isRunning)
            {
                displayMessage(eMessages.HelloMessage);
                displayMessage(eMessages.ShowMenu);
            }
            //hello message
            //show menu

            //get user input

            //switch case

            //exit message
        }

        private void displayMessage(Enum i_Message)
        {
            FieldInfo messageFieldInfo = i_Message.GetType().GetField(i_Message.ToString());
            DescriptionAttribute[] descriptionAttribute = messageFieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            Console.WriteLine(descriptionAttribute?[0].Description);
        }
    }
}