using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneStoreBackend.Services;

namespace PhoneStoreBackend.Controllers
{
    [ApiController]
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

        [HttpGet]
        public ActionResult<string> Test()
        {
            return "Test";
        }
    }
}
