using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Models
{
    internal class Wheel
    {
        public string Manufacturer { get; private set; }
        public float MaxPressure { get; private set; }
        public float CurrentPressure { get; internal set; }

        internal void UpdateProperties(IDictionary<string, string> i_PropertiesToUpdateDictionary)
        {
            if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(Manufacturer)))
            {
                Manufacturer = i_PropertiesToUpdateDictionary[nameof(Manufacturer)];
            }
            else if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(MaxPressure)))
            {
                MaxPressure = float.Parse(i_PropertiesToUpdateDictionary[nameof(MaxPressure)]);
            }
            else if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(CurrentPressure)))
            {
                CurrentPressure = float.Parse(i_PropertiesToUpdateDictionary[nameof(CurrentPressure)]);
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
    }
}
