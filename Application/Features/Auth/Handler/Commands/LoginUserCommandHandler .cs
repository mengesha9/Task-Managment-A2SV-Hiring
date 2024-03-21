using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Identity;
using Application.DTOs.Auths;
using Application.Features.Auth.Request.Commands;
using Application.Response;
using MediatR;

namespace Application.Features.Auth.Handler.Commands
{
    public class LoginUserCommandHandler :IRequestHandler<LoginUserCommand, BaseCommandResponse<LoginResponseDto>>
{
    private readonly IAuthService _authService;

    public LoginUserCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public Task<BaseCommandResponse<LoginResponseDto>> Handle(LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        return _authService.Login(request.LoginUserDto, cancellationToken);
    }
}
    
}