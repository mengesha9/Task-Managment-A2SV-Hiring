using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Auths;
using Application.Response;
using MediatR;

namespace Application.Features.Auth.Request.Commands
{
    public class RegisterUserCommand : IRequest<BaseCommandResponse<LoginResponseDto>>
    {
        public RegisterUserDto RegisterUserDto { get; set; } = null!;
    }

}