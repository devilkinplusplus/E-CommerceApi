using FluentValidation;
using ShopApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Validators
{
    public class UserValidator:AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("Can't be empty");
            RuleFor(x => x.FirstName).MaximumLength(16).WithMessage("Maximum character limit is 16");
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("Can't be empty");
            RuleFor(x => x.LastName).MaximumLength(26).WithMessage("Maximum character limit is 26");
            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("Can't be empty");
            RuleFor(x => x.UserName).MaximumLength(16).WithMessage("Maximum character limit is 16");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Can't be empty");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email address");

        }
    }
}
