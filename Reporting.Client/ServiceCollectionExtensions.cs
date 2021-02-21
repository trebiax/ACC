using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Reporting.Client.Client;

namespace Reporting.Client
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterReportingClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(s =>
            {
                var apiOptions = configuration.GetSection(nameof(ReportingApiOptions)).Get<ReportingApiOptions>();

                return RestService.For<IReportingClient>(apiOptions.BaseUrl);
            });

            return services;
        }
    }
}
