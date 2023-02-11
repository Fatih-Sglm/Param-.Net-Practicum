using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Param_.Net_Practicum.Core.Applicaiton.Dtos.AuthDto;
using Param_.Net_Practicum.Core.Applicaiton.Services;

namespace Param_.Net_Practicum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        /// <summary>
        /// User Login EndPoint
        /// </summary>
        /// <param name="loginUserDto">User Login Information</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            var token = await _authService.LoginAsync(loginUserDto);
            return Ok(token);
        }
    }
}
