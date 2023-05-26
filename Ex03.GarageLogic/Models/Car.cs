using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Models
{
    internal class Car : Vehicle
    {
        private string m_Color;
        private int m_NumDoors;

        public Car(int i_NumWheels, float i_WheelMaxPressure)
            : base(i_NumWheels, i_WheelMaxPressure) { }

        public string Color
        {
            get => m_Color;
            set
            {
                Enum.TryParse(value, ignoreCase: true, out eColor color);

                if (color != eColor.None)
                {
                    m_Color = color.ToString();
                }
                else
                {
                    throw new ArgumentException("Invalid color");
                }
            }

        }
        public int NumberOfDoors
        {
            get => m_NumDoors;
            set
            {
                if (Enum.IsDefined(typeof(eTotalVehicleDoors), value))
                {
                    m_NumDoors = value;
                }
                else
                {
                    throw new ArgumentException("Invalid number of doors");
                }
            }
        }

        public override void UpdateProperties(IDictionary<string, string> i_PropertiesToUpdateDictionary)
        {
            base.UpdateProperties(i_PropertiesToUpdateDictionary);

            if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(Color)))
            {
                this.Color = i_PropertiesToUpdateDictionary[nameof(Color)];
            }
            else if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(NumberOfDoors)))
            {
                int.TryParse(i_PropertiesToUpdateDictionary[nameof(NumberOfDoors)], out int numDoors);

                this.NumberOfDoors = numDoors;
            }
        }

        public override string ToString()
        {
            return string.Format(
                @"{0}
Color: {1}
Number of doors: {2}",
                base.ToString(),
                Color,
                NumberOfDoors);
        }
    }
}
