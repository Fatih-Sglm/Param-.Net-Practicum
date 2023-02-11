using System.Runtime.Serialization;

namespace Param_.Net_Practicum.Core.Applicaiton.Exceptions
{
    /// <summary>
    /// Exception for client-based errors
    /// </summary>
    public class ClientSideException : Exception
    {
        public ClientSideException()
        {
        }

        public ClientSideException(string? message) : base(message)
        {
        }

        public ClientSideException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ClientSideException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
