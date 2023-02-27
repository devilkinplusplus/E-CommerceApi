using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Application.Features.Commands.Authentication.Login;
using static ShopApi.Application.DTOs.AuthDTO;

namespace ShopApi.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var res = await _mediator.Send(new LoginCommandRequest() { LoginDTO = model });
            if(res.Succeeded)
                return Ok(new { token = res.Message });
            return BadRequest(res.Message);
        }
    }
}
