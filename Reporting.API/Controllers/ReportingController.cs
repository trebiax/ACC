using Common.Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using Reporting.API.Application;
using Reporting.API.Application.CommandExecutors;
using Reporting.API.Application.Dtos;
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

        private string str1 = "{\"catalogId\": \"1\",\"attributes\": [{\"id\": \"3\"},{\"id\": \"2\"}]}";
        private string str2 = "{\"catalogId\": \"2\",\"attributes\": [{\"id\": \"2\"}]}";


        [HttpGet]
        public async Task<IActionResult> Get(string firstCatalogMetadataJson, string secondCatalogMetadataJson)
        {
            var firstCatalogMetadata = DtoResolver<CatalogMetadataPresentation>.DeserializeFrom(str1);
            var secondCatalogMetadata = DtoResolver<CatalogMetadataPresentation>.DeserializeFrom(str2);

            await _commandExecutor.GenerateReport(firstCatalogMetadata, secondCatalogMetadata);

            return "".ToHttpResponse();
        }
    }
}
