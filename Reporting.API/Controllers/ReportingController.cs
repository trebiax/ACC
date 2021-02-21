using Common.Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using Reporting.API.Application;
using Reporting.API.Application.Dtos;
using System.Threading.Tasks;

namespace Reporting.API.Controllers
{
    [ApiController]
    [Route("api/reporting")]
    public class ReportingController : ControllerBase
    {

        public ReportingController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get(string firstCatalogMetadataJson, string secondCatalogMetadataJson)
        {
            var firstCatalogMetadata = DtoResolver<CatalogMetadata>.DeserializeFrom(firstCatalogMetadataJson);
            var secondCatalogMetadata = DtoResolver<CatalogMetadata>.DeserializeFrom(secondCatalogMetadataJson);

            firstCatalogMetadata.CheckValidity();
            secondCatalogMetadata.CheckValidity();

            return secondCatalogMetadata.ToHttpResponse();
        }
    }
}
