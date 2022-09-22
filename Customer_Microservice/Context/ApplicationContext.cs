using Customer_Microservice.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer_Microservice.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Customer> Customers { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
