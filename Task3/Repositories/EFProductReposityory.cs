using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task3.Data;
using Task3.Entities;

namespace Task3.Repositories
{
    public class EFProductReposityory : IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public EFProductReposityory(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(Product product)
        {
           _dbContext.Products.Remove(product); 
            _dbContext.SaveChanges();   
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public void Update(Product product)
        {
            _dbContext.Update(product);
            _dbContext.SaveChangesAsync();

        }
    }
}