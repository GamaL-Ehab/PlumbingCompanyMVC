using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ServiceLayer.Extentions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
