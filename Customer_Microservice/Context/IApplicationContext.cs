using Customer_Microservice.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer_Microservice.Context
{
    public interface IApplicationContext
    {
        DbSet<Customer> Customers { get; set; }
        Task<int> SaveChanges();
    }
}
