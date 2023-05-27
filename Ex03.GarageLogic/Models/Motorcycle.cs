using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic.Models
{
    internal class Motorcycle : Vehicle
    {
        private string m_LicenseType;

        public int EngineVolume { get; set; }

        public Motorcycle(int i_NumWheels, float i_WheelMaxPressure)
            : base(i_NumWheels, i_WheelMaxPressure) { }

        public string LicenseType
        {
            get => m_LicenseType;
            set
            {
                if (Enum.TryParse(value, ignoreCase: true, out eLicenseType licenseType))
                {
                    m_LicenseType = licenseType.ToString();
                }
                else
                {
                    throw new ArgumentException("Invalid license type");
                }
            }
        }

        public override void UpdateProperties(IDictionary<string, string> i_PropertiesToUpdateDictionary)
        {
            base.UpdateProperties(i_PropertiesToUpdateDictionary);

            if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(LicenseType)))
            {
                LicenseType = i_PropertiesToUpdateDictionary[nameof(LicenseType)];
            }
            else if (i_PropertiesToUpdateDictionary.ContainsKey(nameof(EngineVolume)))
            {
                int.TryParse(i_PropertiesToUpdateDictionary[nameof(EngineVolume)], out int engineVolume);
                EngineVolume = engineVolume;
            }
        }

        public override string ToString()
        {
            return string.Format(
                @"{0}
License Type: {1}
Engine Volume {2}",
                base.ToString(),
                LicenseType,
                EngineVolume);
        }

    }
}
