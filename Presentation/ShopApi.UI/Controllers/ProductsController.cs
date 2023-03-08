using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApi.Application.Abstractions.Services;
using ShopApi.Application.Abstractions.Storage;
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
        private readonly IStorageService _storageService;
        private readonly IProductImageWriteRepository _productImageWrite;
        private readonly IConfiguration _configuration;
        public ProductsController(IProductReadRepository productRead, IProductWriteRepository productWrite, IStorageService storageService, IProductImageWriteRepository productImageWrite, IConfiguration configuration)
        {
            _productRead = productRead;
            _productWrite = productWrite;
            _storageService = storageService;
            _productImageWrite = productImageWrite;
            _configuration = configuration;
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

        [HttpPost("[action]")]//id burda bildirilmedise queryStringden gelecek demekdir
        public async Task<IActionResult> Upload(string id)
        {
            //await _fileService.UploadAsync("uploads/productImages", Request.Form.Files);
            var fileData = await _storageService.UploadAsync("productimages", Request.Form.Files);

           Product prod =  await _productRead.GetByIdAsync(Guid.Parse(id));

            await _productImageWrite.AddRangeAsync(fileData.Select(x => new ProductImageFile()
            {
                FileName = x.fileName,
                FilePath = x.pathOrContainerName,
                Storage = _storageService.StorageName,
                Products = new List<Product>() { prod }
            }).ToList());

            await _productImageWrite.SaveAsync();
            return Ok();
        }

        [HttpGet("[action]/{id}")] //id bildirildise rootdan gelecek demekdir
        public async Task<IActionResult> GetImages(string id)
        {
            Product? product = await _productRead.Table.Include(x => x.ProductImageFiles)
                                    .FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));

            return Ok(product?.ProductImageFiles.Select(x => new
            {
                Id = x.Id,
                Path = $"{_configuration["BaseStorageUrl"]}/{x.FilePath}",
                Name = x.FileName
            }));
        }

        [HttpDelete("[action]/{id}")] 
        public async Task<IActionResult> DeleteImage(string id,string imageId)
        {
            Product? product = await _productRead.Table.Include(x => x.ProductImageFiles)
                                    .FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));

            ProductImageFile? file = product?.ProductImageFiles.FirstOrDefault(x => x.Id == Guid.Parse(imageId));

            product.ProductImageFiles.Remove(file);
            await _productWrite.SaveAsync();

            return Ok();
        }
    }
}
