using System.Collections.Generic;

namespace Ex03.GarageLogic.Models
{
    internal class ElectricBattery: EnergySource
    {
        public ElectricBattery() { }

        public ElectricBattery(float i_ChargingHoursCapacity)
            : base(i_ChargingHoursCapacity) { }

        public float CurrentBatteryAmount
        {
            get => m_EnergyAmountLeft;
            set => m_EnergyAmountLeft = value;
        }

        public void ChargeBattery(float i_ChargingHoursToAdd)
        {
            EnergyAmountLeft += i_ChargingHoursToAdd;
        }

        public override void UpdateProperties(IDictionary<string, string> i_PropertiesToUpdateDictionary)
        {
            if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(CurrentBatteryAmount)))
            {
                float.TryParse(
                    i_PropertiesToUpdateDictionary[nameof(CurrentBatteryAmount)],
                    out float energyPercentageToSet);

                EnergyPercentage = energyPercentageToSet;
            }
        }

        public override string ToString()
        {
            return string.Format(
                @"Charging Time Left: {0}",
                CurrentBatteryAmount);
        }
    }
}
