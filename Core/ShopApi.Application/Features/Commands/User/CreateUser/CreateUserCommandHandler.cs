using MediatR;
using Microsoft.AspNetCore.Identity;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse response = await _userService.CreateUserAsync(request.CreateUserModel);
            if (response.Succeeded)
            {
                return new() { Succeeded = true };
            }
            return new() { Succeeded = false, Errors = response.Errors };
        }
    }
}
