using Data.API.Application.Dtos;
using Data.API.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.API.Infrastructure.Persistence
{
    public class MemoryCatalogElementCrossRepository : ICatalogElementCrossRepository
    {
        private readonly CatalogElementCrossDb _db;

        public MemoryCatalogElementCrossRepository(CatalogElementCrossDb db)
        {
            _db = db;
        }

        public Task<List<CatalogElementCross>> GetCatalogElementCrosses(List<CatalogElementCrossDto> dtos)
        {
            var crosses = _db.CatalogElementCrosses.Where(dbCross => dtos.Any(dtoCross => dtoCross.MatchesTo(dbCross)))
                                                   .ToList();

            return Task.FromResult(crosses);
        }
    }
}
