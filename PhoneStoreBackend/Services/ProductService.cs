using AutoMapper;
using PhoneStoreBackend.Models;
using PhoneStoreBackend.Models.DTOs;
using PhoneStoreBackend.Repositories;

namespace PhoneStoreBackend.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductService(ProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public async Task<string> AddProduct(Product product)
        {
            if (product.ImagePath == null)
            {
                product.ImagePath = "";
            }
            

            await _productRepository.AddProduct(product);

            return "True";
        }

        public async Task<string> DeleteProduct(int id)
        {

            List<Product> products = await _productRepository.GetAllProducts();
            Product pro = products.FirstOrDefault(p => p.PhoneID == id);
            if (pro != null)
            {
                await _productRepository.DeleteProduct(pro);
                return "True";
            }
            else
            {
                return "False";
            }
            
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task<List<Product>> GetSearchProduct(string text)
        {
            List<Product> products = await _productRepository.GetAllProducts();

            return products.Where(pro => pro.Model.Contains(text) || pro.Brand.Contains(text)).ToList();
        }


        public async Task<string> UpdateProduct(Product product)
        {
            Product new_product = await _productRepository.GetProductById(product.PhoneID);

            new_product.Price = product.Price;
            new_product.Description = product.Description;
            new_product.OperatingSystem = product.OperatingSystem;
            new_product.Model = product.Model;
            new_product.Processor = product.Processor;
            new_product.DisplaySize = product.DisplaySize;
            new_product.Brand = product.Brand;
            new_product.RamMemory = product.RamMemory;
            new_product.Memory = product.Memory;
            new_product.CameraPx = product.CameraPx;
            new_product.BatteryCapacity = product.BatteryCapacity;
            new_product.ImagePath = product.ImagePath;

            await _productRepository.UpdateProduct(new_product);
            return "True";
        }

        


    }
}
