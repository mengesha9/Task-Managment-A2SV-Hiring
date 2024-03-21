using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Auths;
using Application.Features.Auth.Request.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController  : BaseApiController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserDto loginDto)
        {
            var command = new LoginUserCommand { LoginUserDto = loginDto };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserDto registerDto)
        {
            var command = new RegisterUserCommand { RegisterUserDto = registerDto };
            return HandleResult(await _mediator.Send(command));
        }

    }
}