using Microsoft.EntityFrameworkCore;
using Product_Microservice.Models;

namespace Product_Microservice.Context
{
    public class ApplicationContext: DbContext, IApplicationContext
    {
        public DbSet<Product> Products { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
