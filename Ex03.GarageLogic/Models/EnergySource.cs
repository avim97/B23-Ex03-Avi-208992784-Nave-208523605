
using System.Globalization;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Models
{
    internal abstract class EnergySource
    {
        protected float m_EnergyAmountLeft;
        protected readonly float r_Capacity;

        protected EnergySource() { }
        protected EnergySource(float i_Capacity)
        {
            m_EnergyAmountLeft = 0;
            r_Capacity = i_Capacity;
        }

        public float EnergyPercentage
        {
            get
            {
                float energyPercentageLeft;

                if(m_EnergyAmountLeft.Equals(0))
                {
                    energyPercentageLeft = 0;
                }
                else
                {
                    energyPercentageLeft = r_Capacity / m_EnergyAmountLeft;
                }

                return energyPercentageLeft;
            }
        }

        protected float EnergyAmountLeft
        {
            get => m_EnergyAmountLeft;
            set
            {
                if(m_EnergyAmountLeft + value <= r_Capacity)
                {
                    m_EnergyAmountLeft += value;
                }
                else
                {
                    const float k_MinEnergyAmount = 0;
                    float remainingAmountToFullCapacity = r_Capacity - m_EnergyAmountLeft;

                    throw new ValueOutOfRangeException(k_MinEnergyAmount, remainingAmountToFullCapacity);
                }
            }
        }

        public override string ToString()
        {
            return this.EnergyPercentage.ToString(CultureInfo.InvariantCulture);
        }
    }
}
