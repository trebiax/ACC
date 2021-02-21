using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reporting.Client.Client
{
    public interface IReportingClient
    {
        [Get("/api/reporting")]
        Task<ApiResponse<List<List<string>>>> GetGeneratedReport(string firstCatalogMetadataJson, string secondCatalogMetadataJson);
    }
}
