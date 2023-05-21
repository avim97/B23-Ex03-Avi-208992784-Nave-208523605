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

        public override string ToString()
        {
            return string.Format(
                @"Model Name: {0}
License Plate: {1}
Energy Percentage: {2}
Energy Source: {3}
number of wheels: {4}", 
                ModelName, 
                LicensePlate, 
                EnergyPercentage, 
                EnergySource, 
                Wheels);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
