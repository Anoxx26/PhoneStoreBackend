using PhoneStoreBackend.Repositories;

namespace PhoneStoreBackend.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
