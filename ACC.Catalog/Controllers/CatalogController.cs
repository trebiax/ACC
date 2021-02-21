using Catalogs.API.Application.CommandExecutors;
using Common.Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ACC.Catalog.Controllers
{
    [ApiController]
    [Route("api/catalog")]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogCommandExecutor _commandExecutor;

        public CatalogController(CatalogCommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }

        [HttpGet("{catalogId}")]
        public async Task<IActionResult> Get(int catalogId)
        {
            return (await _commandExecutor.GetCatalog(catalogId)).ToHttpResponse();
        }

        [HttpGet("{catalogId}/metadata")]
        public async Task<IActionResult> GetMetadata(int catalogId)
        {
            return (await _commandExecutor.GetCatalogMetadata(catalogId)).ToHttpResponse();
        }
    }
}
