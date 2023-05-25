using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
