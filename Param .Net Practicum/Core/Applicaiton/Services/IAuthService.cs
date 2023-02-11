using Param_.Net_Practicum.Core.Applicaiton.Dtos.AuthDto;
using Param_.Net_Practicum.Core.Applicaiton.Dtos.ResponseDto;

namespace Param_.Net_Practicum.Core.Applicaiton.Services
{
    /// <summary>
    /// Interface created for auth operations
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// The method that perform for the User Login process
        /// </summary>
        /// <param name="loginUserDto"></param>
        /// <returns></returns>
        Task<DataResponse<string>> LoginAsync(LoginUserDto loginUserDto);
    }
}
