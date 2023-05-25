using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Models
{
    internal class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;

        public int EngineVolume { get; set; }

        public Motorcycle(int i_NumWheels, float i_WheelMaxPressure)
            : base(i_NumWheels, i_WheelMaxPressure) { }

        public eLicenseType LicenseType
        {
            get => m_LicenseType;
            set
            {
                if (Enum.IsDefined(typeof(eLicenseType), value))
                {
                    m_LicenseType = value;
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
                Enum.TryParse(i_PropertiesToUpdateDictionary[nameof(LicenseType)], out eLicenseType licenseType);
                LicenseType = licenseType;
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
