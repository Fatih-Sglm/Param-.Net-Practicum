namespace Param_.Net_Practicum.Core.Applicaiton.Dtos.ResponseDto
{
    /// <summary>
    ///  Response WithoutData
    /// </summary>
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public bool IsSucces { get; set; }
        public string? Message { get; set; }

        public static BaseResponse Succes(string Message)
        {
            return new BaseResponse
            {
                Message = Message,
                IsSucces = false,
                StatusCode = 200
            };
        }
    }
}
