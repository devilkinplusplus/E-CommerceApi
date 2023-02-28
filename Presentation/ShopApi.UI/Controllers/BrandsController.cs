using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ShopApi.Application.Features.Commands.Brand.Create;
using ShopApi.Application.Features.Commands.Brand.Delete;
using ShopApi.Application.Features.Commands.Brand.Update;
using ShopApi.Domain.Entities.Concrete;

namespace ShopApi.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BrandsController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBrand([FromForm] string name, IFormFile logo)
        {
            var res = await _mediator.Send(new CreateBrandCommandRequest()
            {
                BrandName = name,
                WebRootPath = _webHostEnvironment.WebRootPath,
                Logo = logo
            });
            if (res.Succeeded)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateBrand([FromRoute] Guid id,[FromBody] string? newName, IFormFile? newLogo)
        {
            var res = await _mediator.Send(new UpdateBrandCommandRequest()
            {
                Id = id,
                NewName = newName,
                NewLogo = newLogo,
                WebRootPath = _webHostEnvironment.WebRootPath
            });
            if (res.Succeeded)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteBrand([FromRoute] Guid id)
        {
            var res = await _mediator.Send(new DeleteBrandCommandRequest() { Id = id });
            if (res.Succeeded)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }
    }
}
