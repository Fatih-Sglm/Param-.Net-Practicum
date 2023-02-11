using System.Runtime.Serialization;

namespace Param_.Net_Practicum.Core.Applicaiton.Exceptions
{
    /// <summary>
    /// exception for not found objects
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }

        public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
