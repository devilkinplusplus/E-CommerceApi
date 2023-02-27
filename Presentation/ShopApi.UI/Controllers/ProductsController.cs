using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Application.Features.Commands.Product.Create;
using ShopApi.Application.Features.Commands.Product.Delete;
using ShopApi.Application.Features.Commands.Product.Update;
using ShopApi.Domain.Entities.Concrete;
using static ShopApi.Application.DTOs.ProductDTO;

namespace ShopApi.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromForm] CreateProductDTO product)
        {
            var res = await _mediator.Send(new CreateProductCommandRequest()
            {
                Title = product.title,
                Link = product.link,
                BrandId = product.brandId,
                CategoryId = product.categoryId,
            });
            if (res.Succeeded)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }


        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var res = await _mediator.Send(new DeleteProductCommandRequest() { Id = id });
            if (res.Succeeded)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] CreateProductDTO model)
        {
            var res = await _mediator.Send(new UpdateProductCommandRequest() { Id = id, NewProduct = model });
            if (res.Succeeded)
                return Ok(res.Message);
            return BadRequest(res.Message);
        }

    }
}
