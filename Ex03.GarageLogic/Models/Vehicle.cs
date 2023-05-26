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
        internal IEnumerable<Wheel> Wheels { get; set; }
        internal EnergySource EnergySource { get; set; }
        public float EnergyPercentage => this.EnergySource.EnergyPercentage;

        protected Vehicle(int i_NumWheels, float i_WheelMaxPressure)
        {
            Wheels = new LinkedList<Wheel>();

            for (int i = 0; i < i_NumWheels; i++)
            {
                Wheel wheel = new Wheel
                {
                    MaxPressure = i_WheelMaxPressure
                };

                Wheels.Append(wheel);
            }
        }
        public virtual void UpdateProperties(IDictionary<string, string> i_PropertiesToUpdateDictionary)
        {
            if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(ModelName)))
            {
                ModelName = i_PropertiesToUpdateDictionary[nameof(ModelName)];
            }

            foreach(Wheel wheel in Wheels)
            {
                wheel.UpdateProperties(i_PropertiesToUpdateDictionary);
            }
        }

        public virtual void InflateWheelsToMax()
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.CurrentPressure = wheel.MaxPressure;
            }
        }

        public IEnumerable<string> GetPropertiesNames()
        {
            Type type = GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            List<string> propertiesNames = new List<string>();

            string vehiclePropertyMessage = "vehicle {0}";
            foreach (PropertyInfo property in properties)
            {
                propertiesNames.Add(string.Format(vehiclePropertyMessage,property.Name));
            }

            Wheel wheel = new Wheel();
            // propertiesNames.Concat(wheel.GetPropertiesNames());
            string wheelPropertyMessage = "wheels {0}";
            foreach(string property in wheel.GetPropertiesNames())
            {
                propertiesNames.Add(String.Format(wheelPropertyMessage,property));
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
                Wheels.ElementAt(0));
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
