using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using ShopApi.Application.Features.Commands.Role.CreateRole;
using ShopApi.Application.Features.Commands.Role.EditRole;
using System.IdentityModel.Tokens.Jwt;

namespace ShopApi.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRole([FromForm]string name)
        {
            CreateRoleCommandResponse res = await _mediator.Send(new CreateRoleCommandRequest { Name = name });
            if (res.Succeeded)
                return Ok();
            return BadRequest(res.Errors);
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> Edit([FromForm]string id, string name)
        {
            var res = await _mediator.Send(new EditRoleCommandRequest() { Id = id, Name = name });
            if (res.Succeeded)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }
    }
}
