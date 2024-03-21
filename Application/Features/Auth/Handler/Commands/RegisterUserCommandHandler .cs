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
    public class RegisterUserCommandHandler :IRequestHandler<RegisterUserCommand, BaseCommandResponse<LoginResponseDto>>
{
    private readonly IAuthService _authService;

    public RegisterUserCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public Task<BaseCommandResponse<LoginResponseDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        return _authService.Register(request.RegisterUserDto, cancellationToken);
    }
}
}