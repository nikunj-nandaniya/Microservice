using Microsoft.EntityFrameworkCore;
using Services.ProductAPI.Models;

namespace Services.ProductAPI.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
