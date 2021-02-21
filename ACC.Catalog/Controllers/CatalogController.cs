using Catalogs.API.Application.CommandExecutors;
using Catalogs.API.Application.Dtos;
using Catalogs.API.Domain;
using Common.Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        [Produces(typeof(List<Dictionary<string, object>>))]
        public async Task<IActionResult> Get(int catalogId)
        {
            return (await _commandExecutor.GetCatalog(catalogId)).ToHttpResponse();
        }

        [HttpGet("{catalogId}/elements")]
        [Produces(typeof(List<CatalogElement>))]
        public async Task<IActionResult> GetCatalogElements(int catalogId)
        {
            return (await _commandExecutor.GetCatalogElements(catalogId)).ToHttpResponse();
        }

        [HttpGet("{catalogId}/metadata")]
        [Produces(typeof(CatalogMetadataDto))]
        public async Task<IActionResult> GetMetadata(int catalogId)
        {
            return (await _commandExecutor.GetCatalogMetadata(catalogId)).ToHttpResponse();
        }
    }
}
