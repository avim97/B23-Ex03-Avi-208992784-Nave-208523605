using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Models
{
    internal class Wheel
    {
        internal float WheelMaxPressure { get; set; }
        public string WheelManufacturer { get; internal set; }
        public float WheelCurrentPressure { get; internal set; }

        internal void UpdateProperties(IDictionary<string, string> i_PropertiesToUpdateDictionary)
        {
            if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(WheelManufacturer)))
            {
                WheelManufacturer = i_PropertiesToUpdateDictionary[nameof(WheelManufacturer)];
            }
            else if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(WheelCurrentPressure)))
            {
                float airVolumeToAdd = float.Parse(i_PropertiesToUpdateDictionary[nameof(WheelCurrentPressure)]);

                Inflate(airVolumeToAdd);
            }
        }

        internal void Inflate(float i_AirVolumeToAdd)
        {
            if (i_AirVolumeToAdd + WheelCurrentPressure <= WheelMaxPressure)
            {
                WheelCurrentPressure += i_AirVolumeToAdd;
            }
            else
            {
                const float k_MinPressure = 0;
                throw new ValueOutOfRangeException(k_MinPressure, WheelMaxPressure);
            }
        }

        internal static IEnumerable<string> GetPropertiesNames()
        {
            PropertyInfo[] properties = typeof(Wheel).GetProperties(BindingFlags.Instance | BindingFlags.Public);

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
                @"WheelManufacturer: {0}
Current pressure {1}",
                WheelManufacturer,
                WheelCurrentPressure);
        }
    }
}
