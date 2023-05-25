namespace Ex03.GarageLogic.Models
{
    internal class ElectricBattery: EnergySource
    {
        public ElectricBattery() { }

        public ElectricBattery(float i_ChargingHoursCapacity)
            : base(i_ChargingHoursCapacity) { }

        public void ChargeBattery(float i_ChargingHoursToAdd)
        {
            EnergyAmountLeft += i_ChargingHoursToAdd;
        }
    }
}
