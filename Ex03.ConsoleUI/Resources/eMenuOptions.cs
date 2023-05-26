using System.ComponentModel;


namespace Ex03.ConsoleUI.Resources
{
    public enum eMenuOptions
    {
        [Description("")]
        None = 0,
        [Description("1. Insert a new vehicle to the garage")]
        InsertNewVehicle,
        [Description("2. Show all license plates in the garage")]
        ShowAllLicensePlates,
        [Description("3. Filter and show all license plates in the garage")]
        FilterAndShowLicensePlates,
        [Description("4. Change vehicle status")]
        ChangeVehicleStatus,
        [Description("5. Inflate wheels to maximum")]
        InflateWheelsToMax,
        [Description("6. Fuel vehicle")]
        FuelVehicle,
        [Description("7. Charge vehicle")]
        ChargeVehicle,
        [Description("8. Get vehicle's full details")]
        GetVehicleFullDetail,
        [Description("6. Exit")]
        Exit
    }
}