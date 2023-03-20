using System.Runtime.Serialization;

namespace CrossCutting.Exceptions
{
    [Serializable]
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string action) : base($"Invalid input on {action}")
        {

        }


        protected InvalidInputException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
