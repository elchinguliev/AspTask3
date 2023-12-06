using System.Collections.Generic;
using System.Threading.Tasks;
using Task3.Entities;

namespace Task3.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task Add(Product product);      
        void Update(Product product);   
        void Delete(Product product);   
    }
}
