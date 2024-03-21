using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Identity;
using Application.DTOs.Auths;
using Application.Response;
using Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AuthService : IAuthService
    {
        private readonly IJwtFactory _jwtFactory;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AuthService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, IJwtFactory jwtFactory)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _signInManager = signInManager;
        }

        public async Task<BaseCommandResponse<LoginResponseDto>> Login(LoginUserDto authRequest,
            CancellationToken cancellationToken)
        {
            var userByEmail = await _userManager.FindByEmailAsync(authRequest.Email);

            if (userByEmail == null )
                return new BaseCommandResponse<LoginResponseDto>
                {
                    Success = false,
                    Message = "Invalid email or password."
                };

            var user = userByEmail;
            var hasher = new PasswordHasher<AppUser>();
            authRequest.Password = hasher.HashPassword(user, authRequest.Password);



            var result =
                await _signInManager.PasswordSignInAsync(user.Email, authRequest.Password, false,
                    false);

            if (!result.Succeeded)
                return new BaseCommandResponse<LoginResponseDto>
                {
                    Success = false,
                    Message = "Invalid email or password."
                };

            var jwtSecurityToken = await _jwtFactory.GenerateToken(user);

            return new BaseCommandResponse<LoginResponseDto>
            {
                Value = new LoginResponseDto
                {
                    User = UserDto.FromUser(user),
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
                }
            };
        }

        public async Task<BaseCommandResponse<LoginResponseDto>> Register(RegisterUserDto registrationRequest,
            CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(registrationRequest.Email);

            if (existingUser != null)
                return new BaseCommandResponse<LoginResponseDto>
                {
                    Success = false,
                    Message = "User with the same email or username already exists."
                };

            var user = new AppUser
            {
                Email = registrationRequest.Email,
                EmailConfirmed = true
            };
            var hasher = new PasswordHasher<AppUser>();
            registrationRequest.Password = hasher.HashPassword(user, registrationRequest.Password);


            var result = await _userManager.CreateAsync(user, registrationRequest.Password);
            if (!result.Succeeded)
                return new BaseCommandResponse<LoginResponseDto>
                {
                    Success = false,
                    Errors = result.Errors.Select(x => x.Description).ToList()
                };

            await _userManager.AddToRoleAsync(user, "User");
            await _userManager.UpdateAsync(user);

            var jwtSecurityToken = await _jwtFactory.GenerateToken(user);

            return new BaseCommandResponse<LoginResponseDto>
            {
                Value = new LoginResponseDto()
                {
                    User = UserDto.FromUser(user),
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
                }
            };
        }
    }
}