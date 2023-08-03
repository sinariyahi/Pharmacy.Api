using Contracts.Dto.SystemNav.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validation.Security
{
    public  class LoginValidator : AbstractValidator<UserLoginModel>
    {

        public LoginValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Enter the username");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Enter the password");
        }
    }
}

