using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.DTOs.Auths.Vallidators
{
    public class LoginUserDtoValidator: AbstractValidator<LoginUserDto>
    {
        public LoginUserDtoValidator()
        {
            RuleFor(dto => dto.Email).NotEmpty().WithMessage("UserNameOrEmail is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
                .MaximumLength(20).WithMessage("Password must not exceed 20 characters")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{6,20}$")
                .WithMessage(
                    "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character");
        }

    }
}