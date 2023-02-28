using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Application.Features.Commands.Category.Create;
using ShopApi.Application.Features.Commands.Category.Delete;
using ShopApi.Application.Features.Commands.Category.Edit;
using ShopApi.Application.Features.Queries.Category.GetAll;

namespace ShopApi.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Post([FromForm]string name)
        {
            var res = await _mediator.Send(new CreateCategoryCommandRequest() { Name = name });
            if (res.Succeeded)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Edit([FromRoute]Guid id,[FromBody]string name)
        {
            var res = await _mediator.Send(new EditCategoryCommandRequest() { Id = id, Name = name });
            if(res.Succeeded)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }


        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var res = await _mediator.Send(new DeleteCategoryCommandRequest() { Id = id });
            if (res.Succeeded)
                return Ok(res.Message);
            return BadRequest(res.Message);
        } 

        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            var res = await _mediator.Send(new GetAllCategoryQueryRequest());
            if (res.Succeeded)
                return Ok(res.Categories);
            return NotFound(res.Message);
        }
    }
}
