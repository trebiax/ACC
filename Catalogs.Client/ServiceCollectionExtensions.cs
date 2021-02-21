using Catalogs.Client.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Catalogs.Client
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterCatalogClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(s =>
            {
                var apiOptions = configuration.GetSection(nameof(CatalogApiOptions)).Get<CatalogApiOptions>();

                return RestService.For<ICatalogClient>(apiOptions.BaseUrl);
            });

            return services;
        }
    }
}
