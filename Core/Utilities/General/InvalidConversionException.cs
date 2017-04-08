using System;
using System.Runtime.Serialization;

namespace Core.Utilities.UnitConversions
{
    public class InvalidConversionException : Exception
    {
        public InvalidConversionException()
        {
        }

        public InvalidConversionException(string message) : base(message)
        {
        }

        public InvalidConversionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidConversionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
