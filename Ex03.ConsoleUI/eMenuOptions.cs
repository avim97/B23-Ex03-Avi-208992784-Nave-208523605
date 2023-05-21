using System.ComponentModel;


namespace Ex03.ConsoleUI
{
    public enum eMenuOptions
    {
        [Description("1. Insert a new vehicle to the garage")]
        ChooseToInsertNewVehicle,

        [Description("2. Show all license plates in the garage")]
        ChooseToShowAllLicensePlates,

        [Description("3. Change vehicle status")]
        ChooseToChangeVehicleStatus,

        [Description("4. Inflate wheels to maximum")]
        ChooseToInflateWheelsToMax,

    }
}