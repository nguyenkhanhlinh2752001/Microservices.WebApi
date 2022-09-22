using Microsoft.EntityFrameworkCore;
using Product_Microservice.Models;

namespace Product_Microservice.Context
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }
        Task<int> SaveChanges();
    }
}
