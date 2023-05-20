using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Exceptions
{
    internal class ValueOutOfRangeException: Exception
    {
        public float MaxValue { get; }
        public float MinValue { get; }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base($"The entered value is not in range of {i_MinValue}-{i_MaxValue}")
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }
    }
}
