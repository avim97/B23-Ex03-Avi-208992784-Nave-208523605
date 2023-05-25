using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Models
{
    internal class Wheel
    {
        internal float MaxPressure { get; set; }
        public string Manufacturer { get; internal set; }
        public float CurrentPressure { get; internal set; }

        internal void UpdateProperties(IDictionary<string, string> i_PropertiesToUpdateDictionary)
        {
            if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(Manufacturer)))
            {
                Manufacturer = i_PropertiesToUpdateDictionary[nameof(Manufacturer)];
            }
            else if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(CurrentPressure)))
            {
                float airVolumeToAdd = float.Parse(i_PropertiesToUpdateDictionary[nameof(CurrentPressure)]);

                Inflate(airVolumeToAdd);
            }
        }

        internal void Inflate(float i_AirVolumeToAdd)
        {
            if (i_AirVolumeToAdd + CurrentPressure <= MaxPressure)
            {
                CurrentPressure += i_AirVolumeToAdd;
            }
            else
            {
                const float k_MinPressure = 0;
                throw new ValueOutOfRangeException(k_MinPressure, MaxPressure);
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

            return propertiesNames;
        }
    }
}
