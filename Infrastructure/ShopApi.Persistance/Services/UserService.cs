using Microsoft.AspNetCore.Identity;
using ShopApi.Application.Validators;
using Microsoft.IdentityModel.Abstractions;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Responses.User;
using ShopApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShopApi.Application.DTOs.UserDTO;
using FluentValidation.Results;
using AutoMapper;

namespace ShopApi.Persistance.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserDTO model)
        {
            AppUser user = _mapper.Map<AppUser>(model);
            List<IdentityError> errorList = new();

            UserValidator validations = new();
            ValidationResult results = validations.Validate(user);

            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                {
                    errorList.Add(new() { Description = error.ErrorMessage });
                }
            }
            else if (!(await HasUniqueEmail(model.email)))
            {
                errorList.Add(new() { Description = "Email already in use" });
            }
            else
            {
                IdentityResult result = await _userManager.CreateAsync(new AppUser()
                {
                    FirstName = model.firstName,
                    LastName = model.lastName,
                    UserName = model.username,
                    Email = model.email
                }, model.password);

                if (result.Succeeded)
                {
                    return new CreateUserResponse { Succeeded = true };
                }
                foreach (var error in result.Errors)
                {
                    errorList.Add(new() { Description = error.Description });
                }
            }

            return new CreateUserResponse() { Succeeded = false, Errors = errorList };
        }


        private async Task<bool> HasUniqueEmail(string email)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);
            return user is null ? true : false;
        }
    }
}
