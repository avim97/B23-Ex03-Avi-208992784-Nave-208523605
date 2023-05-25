using System.ComponentModel;

namespace Ex03.ConsoleUI.Resources
{
    public enum eUserMessages
    {
        [Description("Hello, welcome to the garage!")]
        HelloMessage,
        [Description("Invalid choice, please try again")]
        InvalidUserChoiceMessage,
        [Description("Please enter your choice:")]
        EnterYourChoiceMessage,
        [Description("Please enter the license plate number:")]
        EnterLicensePlateNumberMessage,
        [Description("Vehicle is already in the garage, changing status to 'In Work'")]
        VehicleIsAlreadyInGarageMessage,
        [Description("Please enter the owner's name:")]
        EnterOwnerNameMessage,
        [Description("Please enter the owner's phone number:")]
        EnterOwnerPhoneNumberMessage,
        [Description("Please enter the vehicle type:")]
        EnterVehicleTypeMessage,
        [Description("Please enter your name:")]
        EnterCustomerNameMessage,
        [Description("Please enter your phone number:")]
        EnterCustomerPhoneNumberMessage,

    }
}