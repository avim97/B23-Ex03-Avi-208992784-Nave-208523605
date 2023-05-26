using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Models
{
    internal class FuelTank : EnergySource
    {
        private readonly eFuelType m_FuelType;


        public FuelTank() { }

        public FuelTank(eFuelType i_FuelType, float i_TankCapacity)
        : base(i_TankCapacity)
        {
            m_FuelType = i_FuelType;
        }

        public float CurrentFuelAmount
        {
            get => m_EnergyAmountLeft;
            set => m_EnergyAmountLeft = value;
        }

        private bool validateFuelType(eFuelType i_FuelTypeToValidate)
        {
            bool isSameType = this.m_FuelType.Equals(i_FuelTypeToValidate);

            return isSameType;
        }

        public void FillTank(float i_LitersToAdd, eFuelType i_FuelType)
        {
            bool isSameFuelType = validateFuelType(i_FuelType);

            if (isSameFuelType)
            {
                EnergyAmountLeft += i_LitersToAdd;
            }
            else
            {
                throw new ArgumentException("Vehicle fuel type does not match");
            }
        }

        public override void UpdateProperties(IDictionary<string, string> i_PropertiesToUpdateDictionary)
        {
            if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(CurrentFuelAmount)))
            {
                float.TryParse(
                    i_PropertiesToUpdateDictionary[nameof(CurrentFuelAmount)],
                    out float energyPercentageToSet);

                EnergyPercentage = energyPercentageToSet;
            }
        }
    }
}
