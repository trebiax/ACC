using Common.Application.Extensions;
using Data.API.Application.CommandExecutors;
using Data.API.Application.Dtos;
using Data.API.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.API.Controllers
{
    [ApiController]
    [Route("api/catalog-element-cross")]
    public class CatalogElementCrossController : ControllerBase
    {
        private readonly CatalogElementCrossCommandExecutor _commandExecutor;

        public CatalogElementCrossController(CatalogElementCrossCommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }

        // Sorry for REST violation, params are too complex
        [HttpPost]
        [Produces(typeof(List<CatalogElementCross>))]
        public async Task<IActionResult> Get(List<CatalogElementCrossDto> dtos)
        {
            return (await _commandExecutor.GetCatalogElementCrosses(dtos)).ToHttpResponse();
        }
    }
}
