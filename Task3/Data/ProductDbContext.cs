using Microsoft.EntityFrameworkCore;
using Task3.Entities;

namespace Task3.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext>contextOptions)
            : base(contextOptions)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
