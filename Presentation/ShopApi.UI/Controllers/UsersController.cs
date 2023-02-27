using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Application.Features.Commands.User.CreateUser;
using static ShopApi.Application.DTOs.UserDTO;

namespace ShopApi.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserDTO model)
        {
           CreateUserCommandResponse res = await _mediator.Send(new CreateUserCommandRequest() { CreateUserModel = model });
            if (res.Succeeded)
                return Ok(res.Message);
            return BadRequest(res.Errors);
        }
    }
}
