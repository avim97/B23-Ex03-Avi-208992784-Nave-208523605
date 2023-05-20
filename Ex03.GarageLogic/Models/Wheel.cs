using System.Dynamic;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Models
{
    internal class Wheel
    {
        public string Manufacturer { get; }
        private float m_CurrentPressure;
        private readonly float r_MaxPressure;

        public Wheel(string i_Manufacturer, float i_MaxPressure)
        {
            Manufacturer = i_Manufacturer;
            this.r_MaxPressure = i_MaxPressure;
            m_CurrentPressure = 0;
        }

        public float CurrentPressure
        {
            get => m_CurrentPressure;
            set
            {
                if (value + m_CurrentPressure <= r_MaxPressure)
                {
                    m_CurrentPressure += value;
                }
                else
                {
                    const float k_MinPressure = 0;
                    throw new ValueOutOfRangeException(k_MinPressure, r_MaxPressure);
                }
            }
        }

    }
}
