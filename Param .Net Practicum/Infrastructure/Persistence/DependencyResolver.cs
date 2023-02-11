using Param_.Net_Practicum.Core.Applicaiton.Services;
using Param_.Net_Practicum.Infrastructure.Persistence.Services;

namespace Param_.Net_Practicum.Infrastructure.Persistence
{
    /// <summary>
    /// Extension method that adds services to IoC containers
    /// </summary>
    public static class DependencyResolver
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAuthService, AuthService>();


            return services;
        }
    }
}
