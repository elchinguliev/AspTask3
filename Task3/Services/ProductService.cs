using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3.Entities;
using Task3.Repositories;
using Task3.Services;

namespace Task3.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            await _productRepository.Add(product);
        }

        public void Delete(Product product)
        {
            _productRepository.Delete(product);
        }

        public async Task<List<Product>> GetAllByKey(string key = "")
        {
            var data = await _productRepository.GetAllAsync();
            return key != "" ? data.Where(s => s.Name.ToLower().Contains(key.ToLower())).ToList() : data;
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}
