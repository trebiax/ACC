using Catalogs.Client.Contracts;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogs.Client.Client
{
    public interface ICatalogClient
    {
        [Get("/api/catalog/{catalogId}/metadata")]
        Task<ApiResponse<CatalogMetadataDto>> GetCatalogMetadata(int catalogId);

        [Get("/api/catalog/{catalogId}/elements")]
        Task<ApiResponse<List<CatalogElement>>> GetCatalogElements(int catalogId);
    }
}
