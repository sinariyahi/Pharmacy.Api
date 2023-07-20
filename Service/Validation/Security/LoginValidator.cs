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
            RuleFor(x => x.UserName).NotEmpty().WithMessage("نام کابری را وارد نمایید");
            // RuleFor(x => x.UserName).MinimumLength(8).WithMessage("حداقل تعداد 8");
            RuleFor(x => x.Password).NotEmpty().WithMessage("کلمه عبور را وارد نمایید");
        }
    }
}

