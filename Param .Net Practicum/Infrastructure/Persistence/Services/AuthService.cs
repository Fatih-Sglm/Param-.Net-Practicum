using Microsoft.EntityFrameworkCore;
using Param_.Net_Practicum.Core.Applicaiton.Dtos.AuthDto;
using Param_.Net_Practicum.Core.Applicaiton.Dtos.ResponseDto;
using Param_.Net_Practicum.Core.Applicaiton.Exceptions;
using Param_.Net_Practicum.Core.Applicaiton.Extensions;
using Param_.Net_Practicum.Core.Applicaiton.Services;
using Param_.Net_Practicum.Core.Domain.Entities;
using Param_.Net_Practicum.Infrastructure.Persistence.Context;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Param_.Net_Practicum.Infrastructure.Persistence.Services
{
    public class AuthService : IAuthService
    {
        public Task<DataResponse<string>> LoginAsync(LoginUserDto loginUserDto)
        {
            if (FakeUser.user.UserName != loginUserDto.UserName && FakeUser.user.Password != loginUserDto.Password)
            {
                throw new NotFoundException("User Not Found");
            }

            byte[] key = new byte[32];
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(key);
            TokenDto.Token = Convert.ToBase64String(key);
            return Task.FromResult(DataResponse<string>.Succes(TokenDto.Token));
        }
    }
}
