using System.ComponentModel;

namespace Ex03.ConsoleUI.Resources
{
    public enum eUserMessages
    {
        [Description("Hello, welcome to the garage!")]
        HelloMessage,
        [Description("Invalid choice, please try again")]
        InvalidUserChoiceMessage
    }
}