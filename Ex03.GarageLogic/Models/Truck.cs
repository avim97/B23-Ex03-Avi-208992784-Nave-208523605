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
    }
}
