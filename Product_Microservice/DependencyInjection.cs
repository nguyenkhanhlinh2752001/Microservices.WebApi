using Microsoft.EntityFrameworkCore;
using Product_Microservice.Context;

namespace Product_Microservice
{
    public static class DependencyInjection
    {
        public static void AddDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
        }
    }
}
