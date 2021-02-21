using Data.Client.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Data.Client
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDataClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(s =>
            {
                var apiOptions = configuration.GetSection(nameof(DataApiOptions)).Get<DataApiOptions>();

                return RestService.For<IDataClient>(apiOptions.BaseUrl);
            });

            return services;
        }
    }
}
