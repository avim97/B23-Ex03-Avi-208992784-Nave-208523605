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

        internal eColor Color
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

        //todo: add toString
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
