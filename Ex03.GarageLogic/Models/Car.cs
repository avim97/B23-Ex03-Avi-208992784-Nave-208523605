using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Models
{
    internal class Car : Vehicle
    {
        public eColor Color {get; set; }
        public eTotalVehicleDoors NumberOfDoors {get; set; }

        //todo: add toString
        public override string ToString()
        {
            return string.Format(@"{0}
Color: {1}
Number of doors: {2}
", base.ToString(), Color, NumberOfDoors);
        }
    }
}
