using Core.DTOs.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Common.Pagination;
using Service.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
       

        public ProductController(IProductService productService)
        { 
            _productService = productService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id) => await  _productService.GetById(id);



        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(ProductCreateDto model) => await _productService.Create(model);


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, ProductUpdateDto model)
        {
            
            await _productService.Update(model,id);
            return Ok();
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {

            await _productService.Delete(id);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<ProductDto>>> GetAllPaginatedAsync(int page, int take)
            => await _productService.GetAllPaginated(page, take);

        
    }
}
