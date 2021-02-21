using Data.API.Application.Dtos;
using Data.API.Domain;
using Data.API.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.API.Application.CommandExecutors
{
    public class CatalogElementCrossCommandExecutor
    {
        private readonly ICatalogElementCrossRepository _repository;

        public CatalogElementCrossCommandExecutor(ICatalogElementCrossRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CatalogElementCross>> GetCatalogElementCrosses(List<CatalogElementCrossDto> dtos)
        {
            return await _repository.GetCatalogElementCrosses(dtos);
        }
    }
}
