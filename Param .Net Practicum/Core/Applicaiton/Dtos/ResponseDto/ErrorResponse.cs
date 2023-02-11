using System.Net;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Param_.Net_Practicum.Core.Applicaiton.Dtos.ResponseDto
{
    /// <summary>
    ///  Erorr Response
    /// </summary>
    public class ErrorResponse : BaseResponse
    {
        public List<string> Errors { get; private set; }

        public static ErrorResponse Fail(List<string> errors, int httpStatusCode)
        {
            return new ErrorResponse
            {
                Errors = errors,
                IsSucces = false,
                StatusCode = httpStatusCode
            };
        }

        public static ErrorResponse Fail(string error, int httpStatusCode)
        {
            return new ErrorResponse
            {
                Errors = new List<string> { error },
                IsSucces = false,
                StatusCode = httpStatusCode
            };
        }
    }
}
