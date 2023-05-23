﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Models
{
    internal class Truck : Vehicle
    {
        public bool IsHazardousCargo { get; private set; }
        public float CargoVolume { get; private set; }

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

        public override void UpdateProperties(IDictionary<string, string> i_PropertiesToUpdateDictionary)
        {
            base.UpdateProperties(i_PropertiesToUpdateDictionary);

            if(i_PropertiesToUpdateDictionary.ContainsKey(nameof(IsHazardousCargo)))
            {
                IsHazardousCargo = bool.Parse(i_PropertiesToUpdateDictionary[nameof(IsHazardousCargo)]);
            }
            else if(i_PropertiesToUpdateDictionary.ContainsKey(nameof(CargoVolume)))
            {
                CargoVolume = float.Parse(i_PropertiesToUpdateDictionary[nameof(CargoVolume)]);
            }
        }
    }
}
