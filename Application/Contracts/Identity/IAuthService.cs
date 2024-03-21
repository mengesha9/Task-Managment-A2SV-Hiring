using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Auths;
using Application.Response;

namespace Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<BaseCommandResponse<LoginResponseDto>> Login(LoginUserDto authRequest, CancellationToken cancellationToken);

        Task<BaseCommandResponse<LoginResponseDto>> Register(RegisterUserDto registrationRequest,
            CancellationToken cancellationToken);

    }
}