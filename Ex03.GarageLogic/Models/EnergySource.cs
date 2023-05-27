using System;
using System.Collections.Generic;
using System.Reflection;

using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Models
{
    internal abstract class EnergySource
    {
        protected float m_EnergyAmountLeft;
        protected float m_EnergyPercentage;
        protected readonly float r_Capacity;

        protected EnergySource() { }

        protected EnergySource(float i_Capacity)
        {
            m_EnergyAmountLeft = 0;
            m_EnergyPercentage = 0;
            r_Capacity = i_Capacity;
        }

        internal float EnergyPercentage
        {
            get
            {
                float energyPercentageLeft;

                if (m_EnergyAmountLeft.Equals(0))
                {
                    energyPercentageLeft = 0;
                }
                else
                {
                    energyPercentageLeft = r_Capacity / m_EnergyAmountLeft;
                }

                return energyPercentageLeft;
            }
            set
            {
                const float k_MaxAmount = 100f;

                if (m_EnergyPercentage + value <= k_MaxAmount)
                {
                    m_EnergyAmountLeft += value;
                }
                else
                {
                    const float k_MinEnergyAmount = 0;

                    throw new ValueOutOfRangeException(k_MinEnergyAmount, k_MaxAmount);
                }
            }
        }

        protected float EnergyAmountLeft
        {
            get => m_EnergyAmountLeft;
            set
            {
                if (m_EnergyAmountLeft + value <= r_Capacity)
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
            return string.Empty;
        }

        public abstract void UpdateProperties(IDictionary<string, string> i_PropertiesToUpdateDictionary);

        internal IEnumerable<string> GetPropertiesNames()
        {
            Type type = GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            List<string> propertiesNames = new List<string>();

            foreach (PropertyInfo property in properties)
            {
                propertiesNames.Add(property.Name);
            }

            return propertiesNames;
        }
    }
}
