using Common.Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using Reporting.API.Application;
using Reporting.API.Application.CommandExecutors;
using Reporting.API.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reporting.API.Controllers
{
    [ApiController]
    [Route("api/reporting")]
    public class ReportingController : ControllerBase
    {
        private readonly ReportingCommandExecutor _commandExecutor;

        public ReportingController(ReportingCommandExecutor commandExecutor )
        {
            _commandExecutor = commandExecutor;
        }

        [HttpGet]
        [Produces(typeof(List<List<string>>))]
        public async Task<IActionResult> GetGeneratedReport(string firstCatalogMetadataJson, string secondCatalogMetadataJson)
        {
            var firstCatalogMetadata = DtoResolver<CatalogMetadataPresentation>.DeserializeFrom(firstCatalogMetadataJson);
            var secondCatalogMetadata = DtoResolver<CatalogMetadataPresentation>.DeserializeFrom(secondCatalogMetadataJson);

            return (await _commandExecutor.GenerateReport(firstCatalogMetadata, secondCatalogMetadata))
                    .ToHttpResponse();
        }
    }
}
