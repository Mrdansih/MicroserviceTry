using Application.Product.ServiceInterfaces;
using Domain.Product.ProductModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> PostProductAsync([FromBody] ProductDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Succes = false, Message = "Invalid request" });

            var product = await _productService.CreateProductsAsync(request);

            if (product is null)
                return BadRequest(new { Succes = false, Message = "Product with that name already exists" });

            return Ok(new { Succes = true, Message = "Product added succesfully" });
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<ProductDto>> GetProductAsync(int id)
        {
            if (id == 0)
                return BadRequest(new { Succes = false, Message = "Invalid request" });

            var product = await _productService.GetProductByIdAsync(id);

            if (product is null)
                return BadRequest(new { Succes = false, Message = "No product with requested ID" });

            return Ok(new { Succes = true, Message = "Product found", product });

        }

        //Path: api/product/get/pages?page=1&pageSize=20&category=""
        [HttpGet("get/pages")]
        public async Task<ActionResult<List<ProductDto>>> GetAllProductsAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] string category = "")
        {
            var products = await _productService.GetProductsForPageAsync(page, pageSize, category);
            return Ok(products);
        }
    }
}
