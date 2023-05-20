using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Models
{
    internal class Motorcycle : Vehicle
    {
        public eLicenseType LicenseType { get; set; }

        //todo: add toString
        public override string ToString()
        {
            return string.Format(@"{0}
                            License Type: {1}
                            ", base.ToString(), LicenseType);
        }

    }
}
