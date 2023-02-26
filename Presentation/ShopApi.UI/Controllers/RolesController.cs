using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using ShopApi.Application.Features.Commands.Role.AssignRole;
using ShopApi.Application.Features.Commands.Role.CreateRole;
using ShopApi.Application.Features.Commands.Role.EditRole;
using System.IdentityModel.Tokens.Jwt;

namespace ShopApi.UI.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> CreateRole(string name)
        {
            CreateRoleCommandResponse res = await _mediator.Send(new CreateRoleCommandRequest { Name = name });
            if (res.Succeeded)
                return Ok();
            return BadRequest(res.Errors);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AssignRole(string roleName)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var id = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "nameid")?.Value;

            var res = await _mediator.Send(new AssignRoleCommandRequest() { UserId = id, RoleName = roleName });
            if (res.Succeeded)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Edit(string id, string name)
        {
            var res = await _mediator.Send(new EditRoleCommandRequest() { Id = id, Name = name });
            if (res.Succeeded)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }
    }
}
