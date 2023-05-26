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
        internal LinkedList<Wheel> Wheels { get; set; }
        internal EnergySource EnergySource { get; set; }

        internal float EnergyPercentage
        {
            get => this.EnergySource.EnergyPercentage;
            set => this.EnergySource.EnergyPercentage = value;
        }

        protected Vehicle(int i_NumWheels, float i_WheelMaxPressure)
        {
            Wheels = new LinkedList<Wheel>();

            for (int i = 0; i < i_NumWheels; i++)
            {
                Wheel wheel = new Wheel
                {
                    WheelMaxPressure = i_WheelMaxPressure
                };

                Wheels.AddLast(wheel);
            }
        }
        public virtual void UpdateProperties(IDictionary<string, string> i_PropertiesToUpdateDictionary)
        {
            if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(ModelName)))
            {
                ModelName = i_PropertiesToUpdateDictionary[nameof(ModelName)];
            }

            EnergySource.UpdateProperties(i_PropertiesToUpdateDictionary);

            foreach (Wheel wheel in Wheels)
            {
                wheel.UpdateProperties(i_PropertiesToUpdateDictionary);
            }
        }

        public virtual void InflateWheelsToMax()
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.WheelCurrentPressure = wheel.WheelMaxPressure;
            }
        }

        internal IEnumerable<string> GetPropertiesNames()
        {
            Type type = GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            List<string> propertiesNames = new List<string>();
            foreach (PropertyInfo property in properties)
            {
                propertiesNames.Add(property.Name);
            }

            IEnumerable<string> wheelPropertiesNames = Wheel.GetPropertiesNames();
            foreach (string property in wheelPropertiesNames)
            {
                propertiesNames.Add(property);
            }

            IEnumerable<string> energySourcePropertiesNames = this.EnergySource.GetPropertiesNames();
            foreach (string property in energySourcePropertiesNames)
            {
                propertiesNames.Add(property);
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
