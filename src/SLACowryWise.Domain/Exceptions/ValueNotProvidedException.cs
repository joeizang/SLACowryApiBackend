using System;

namespace SLACowryWise.Domain.Exceptions
{
    public class ValueNotProvidedException : Exception
    {
        public ValueNotProvidedException(string message = "A value was not provided to this property") : base(message)
        {
            
        }
    }
}