using System.Collections.Generic;
using System.Threading.Tasks;
using Task3.Entities;

namespace Task3.Services
{
    public interface IProductService
    {
       public Task<List<Product>> GetAllByKey(string key = "");
        public Task Add(Product product);   
        public void Update(Product product);
        public void Delete(Product product);
    }
}
