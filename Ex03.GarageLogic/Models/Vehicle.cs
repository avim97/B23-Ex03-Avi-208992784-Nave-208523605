using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Models
{
    internal abstract class Vehicle
    {
        public string ModelName { get; set; }
        public string LicensePlate { get; set; }
        public float EnergyPercentage { get; set; }
        protected EnergySource EnergySource { get; }
        protected IList<Wheel> Wheels { get; }
    }
}
