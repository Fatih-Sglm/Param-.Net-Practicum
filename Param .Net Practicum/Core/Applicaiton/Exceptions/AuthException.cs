using System.Runtime.Serialization;

namespace Param_.Net_Practicum.Core.Applicaiton.Exceptions
{
    /// <summary>
    /// Exception for user login error
    /// </summary>
    public class AuthException : Exception
    {
        public AuthException()
        {
        }

        public AuthException(string? message) : base(message)
        {
        }

        public AuthException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AuthException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
