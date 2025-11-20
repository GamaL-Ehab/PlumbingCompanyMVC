using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Contexts;

namespace RepositoryLayer.Extentions
{
    public static class RepositoryLayerExtensions
    {
        public static IServiceCollection LoadRepositoryLayerExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PlumbingDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

            return services;
        }
    }
}
