using Microsoft.EntityFrameworkCore;
using Services.Ecommerce.Entities;

namespace Services.Ecommerce.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
