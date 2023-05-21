using System.ComponentModel;

namespace Ex03.ConsoleUI.Resources
{
    public enum eMessages
    {
        //HELLO_MESSAG
        [Description("Hello, welcome to the garage!")]
        HelloMessage,

        [Description("Please choose one of the following options:")] 
        ChooseMenu

        [Description("1. Insert a new vehicle to the garage")]
        InsertNewVehicle,

    }
}