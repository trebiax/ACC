using Data.Client.Contracts;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Client.Client
{
    public interface IDataClient
    {
        [Post("/api/catalog-element-cross")]
        Task<ApiResponse<List<CatalogElementCross>>> GetCatalogElementCrosses(List<CatalogElementCrossDto> dtos);
    }
}
