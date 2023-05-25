using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Models
{
    internal class Car : Vehicle
    {
        private eColor m_Color;
        private eTotalVehicleDoors m_NumDoors;

        public Car(int i_NumWheels, float i_WheelMaxPressure)
            : base(i_NumWheels, i_WheelMaxPressure) { }

        public eColor Color
        {
            get => m_Color;
            set
            {
                if (Enum.IsDefined(typeof(eColor), value))
                {
                    m_Color = value;
                }
                else
                {
                    throw new ArgumentException("Invalid color");
                }
            }

        }
        public eTotalVehicleDoors NumberOfDoors
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
                Enum.TryParse(i_PropertiesToUpdateDictionary[nameof(Color)], out eColor colorToSet);

                this.Color = colorToSet;
            }
            else if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(NumberOfDoors)))
            {
                Enum.TryParse(
                    i_PropertiesToUpdateDictionary[nameof(NumberOfDoors)], 
                    out eTotalVehicleDoors totalVehicleDoors);

                this.NumberOfDoors = totalVehicleDoors;
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
