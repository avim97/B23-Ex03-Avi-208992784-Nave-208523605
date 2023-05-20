using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Models
{
    internal class Truck : Vehicle
    {
        public bool IsHazardousCargo { get; set; }
        public float CargoVolume { get; set; }


        public override string ToString()
        {
            return string.Format(
                @"{0}
Is Hazardous Cargo: {1}
Cargo Volume: {2}", 
                base.ToString(), 
                IsHazardousCargo, 
                CargoVolume);
        }
    }
}
