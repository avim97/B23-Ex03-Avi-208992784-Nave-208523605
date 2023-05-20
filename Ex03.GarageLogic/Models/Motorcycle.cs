using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Models
{
    internal class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;

        public eLicenseType LicenseType
        {
            get => m_LicenseType;
            set
            {
                if(Enum.IsDefined(typeof(eLicenseType), value))
                {
                    m_LicenseType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid license type");
                }
            }
        }

        public override string ToString()
        {
            return string.Format(
                @"{0}
License Type: {1}", 
                base.ToString(), 
                LicenseType);
        }

    }
}
