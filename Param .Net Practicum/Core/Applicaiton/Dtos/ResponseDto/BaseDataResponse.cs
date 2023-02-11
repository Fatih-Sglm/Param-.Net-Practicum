namespace Param_.Net_Practicum.Core.Applicaiton.Dtos.ResponseDto
{
    /// <summary>
    ///  Response With Data
    /// </summary>
    /// <typeparam name="T"> Response data type</typeparam>
    public class DataResponse<T> : BaseResponse
    {
        public T Data { get; set; }


        public static DataResponse<T> Succes(T data)
        {
            return new DataResponse<T>
            {
                Data = data,
                IsSucces = false,
                StatusCode = 200
            };
        }

    }
}
