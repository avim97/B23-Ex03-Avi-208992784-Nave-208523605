using System.ComponentModel;

namespace Ex03.ConsoleUI.Resources
{
    public enum eUserMessages
    {
        [Description("Hello, welcome to the garage!")]
        HelloMessage,
        [Description("Invalid choice, please try again")]
        InvalidUserChoiceMessage,
        [Description("Please enter the license plate number:")]
        EnterLicensePlateNumberMessage,
        [Description("Vehicle is already in the garage, changing status to 'In Work'")]
        VehicleIsAlreadyInGarageMessage,
        [Description("Please enter the vehicle type:")]
        EnterVehicleTypeMessage,
        [Description("Please enter fuel type")]
        EnterFuelTypeMessage,
        [Description("Please enter fuel amount (in liters) to fuel:")]
        EnterFuelAmount,
        [Description("Please enter chraging amount (in minuts) time:")]
        EnterChargingAmountTime,
        [Description("Please enter your name:")]
        EnterCustomerNameMessage,
        [Description("Please enter your phone number:")]
        EnterCustomerPhoneNumberMessage,
        [Description("Invalid input!")]
        InvalidInputMessage,
        [Description("Press any key to return to the main menu")]
        PressAnyKeyToReturnToMainMenuMessage
    }
}