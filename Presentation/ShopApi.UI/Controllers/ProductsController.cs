using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Application.Repositories;
using ShopApi.Application.RequestParameters;
using ShopApi.Application.ViewModels;
using ShopApi.Domain.Entities.Concrete;
using System.Net;

namespace ShopApi.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWrite;
        private readonly IProductReadRepository _productRead;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductsController(IProductReadRepository productRead, IProductWriteRepository productWrite, IWebHostEnvironment webHostEnvironment)
        {
            _productRead = productRead;
            _productWrite = productWrite;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] Pagination pagination) //QueryString olaraq geleceyi üçün [FromQuery]
        {
            var totalCount = _productRead.GetAll(x => x.IsDeleted == false, false).Count();
            var data = _productRead.GetAll(x => x.IsDeleted == false, false).Select(x => new
            {
                x.Id,
                x.Title,
                x.Price,
                x.Stock,
                x.Date
            }).Skip(pagination.Page * pagination.Size).Take(pagination.Size);

            return Ok(new { products = data, totalCount = totalCount });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _productRead.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductCreateVM model)
        {
            if (ModelState.IsValid)
            {
                await _productWrite.AddAsync(new()
                {
                    Title = model.Title,
                    Price = model.Price,
                    Stock = model.Stock,
                    Description = model.Description
                });
                await _productWrite.SaveAsync();
                return StatusCode((int)HttpStatusCode.Created);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductUpdateVM model)
        {
            Product product = await _productRead.GetByIdAsync(model.Id);
            product.Title = model.Title;
            product.Description = model.Description;
            product.Stock = model.Stock;
            product.Price = model.Price;
            await _productWrite.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productWrite.RemoveAsync(id);
            await _productWrite.SaveAsync();
            return NoContent();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/productImages");

            foreach (IFormFile file in Request.Form.Files)
            {
                string fullPath = Path.Combine(uploadPath, $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}");

                using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None,
                        1024 * 1024, false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();//streami bosalt
            }

            return Ok();
        }

    }
}
