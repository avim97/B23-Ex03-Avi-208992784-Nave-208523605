using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Models
{
    internal abstract class Vehicle
    {
        internal string LicensePlate { get; set; }
        public string ModelName { get; set; }
        public IList<Wheel> Wheels { get; set; }
        public EnergySource EnergySource { get; set; }
        public float EnergyPercentage => this.EnergySource.EnergyPercentage;

        public virtual void UpdateProperties(IDictionary<string, string> i_PropertiesToUpdateDictionary)
        {
            if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(ModelName)))
            {
                ModelName = i_PropertiesToUpdateDictionary[nameof(ModelName)];
            }
            else if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(EnergySource)))
            {
                //update energy source accordingly 
            }
            else if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(Wheels)))
            {

            }
        }

        public virtual void InflateWheelsToMax()
        {
            foreach(Wheel wheel in Wheels)
            {
                wheel.CurrentPressure = wheel.MaxPressure;
            }
        }

        public IEnumerable<string> GetPropertiesNames()
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
            return LicensePlate.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Vehicle vehicle = obj as Vehicle;

            return LicensePlate.Equals(vehicle?.LicensePlate);
        }
    }
}
