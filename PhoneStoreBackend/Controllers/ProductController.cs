using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PhoneStoreBackend.Models;
using PhoneStoreBackend.Models.DTOs;
using PhoneStoreBackend.Services;

namespace PhoneStoreBackend.Controllers
{
    [ApiController]
    [EnableCors("AllowAll")]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        private readonly IMapper _mapper;

        private readonly ProductService _productService;

        public ProductController(ILogger<ProductController> logger, IMapper mapper, ProductService productService)
        {
            _logger = logger;
            _mapper = mapper;
            _productService = productService;
        }

        
        [HttpGet("GetProducts")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await _productService.GetAllProducts();
        }

        [Authorize]
        [HttpPost("AddProduct")]
        public async Task<ActionResult<string>> AddProduct(ProductDTO productDTO)
        {
            return await _productService.AddProduct(_mapper.Map<Product>(productDTO));
        
        }

        [HttpGet("GetProductById")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return await _productService.GetProductById(id);
        }

        [Authorize]
        [HttpPost("UpdateProduct")]
        public async Task<ActionResult<string>> UpdateProduct(Product product)
        {
            return await _productService.UpdateProduct(product);

        }

        [Authorize]
        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult<string>> DeleteProduct(int phoneID)
        {
            return await _productService.DeleteProduct(phoneID);
        }

        [HttpGet("SearchProduct")]
        public async Task<ActionResult<List<Product>>> GetSearchProduct(string searchText)
        {
            return await _productService.GetSearchProduct(searchText);
        }
    }
}
