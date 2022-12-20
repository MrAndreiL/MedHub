using MedHub.Core.Repositories.Base;
using MedHub.Infrastructure.Data;
using MedHub.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedHub.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<MedHubContext>(m => m.UseSqlite(configuration.GetConnectionString("MedHubDB")));
            return services;
        }
    }
}
