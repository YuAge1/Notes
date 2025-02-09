using CRM.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this  IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<CRMDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<ICRMDbContext>(provider =>
                provider.GetService<CRMDbContext>());
            return services;
        }
    }
}
