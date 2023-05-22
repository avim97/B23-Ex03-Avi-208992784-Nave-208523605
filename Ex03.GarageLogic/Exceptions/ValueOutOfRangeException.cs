using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Exceptions
{
    internal class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; }
        public float MinValue { get; }

        public ValueOutOfRangeException() { }

        public ValueOutOfRangeException(string i_Message)
            : base(i_Message) { }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : this($"The entered value is not in range of {i_MinValue}-{i_MaxValue}")
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }

        public ValueOutOfRangeException(string i_Message, Exception i_InnerException)
        : base(i_Message, i_InnerException) { }
    }
}
