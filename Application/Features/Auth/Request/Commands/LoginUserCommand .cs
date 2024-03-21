using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Auths;
using Application.Response;
using MediatR;

namespace Application.Features.Auth.Request.Commands
{
    public class LoginUserCommand : IRequest<BaseCommandResponse<LoginResponseDto>>
    {
        public LoginUserDto LoginUserDto { get; set; } = null!;
    }
   
}