using Catalogs.API.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogs.API.Infrastructure.Persistence
{
    public class MemoryCatalogRepository : ICatalogRepository
    {
        private readonly CatalogDb _db;

        public MemoryCatalogRepository(CatalogDb db)
        {
            _db = db;
        }
        public Task<Catalog> GetCatalog(int catalogId)
        {
            var catalog = _db.Catalogs.FirstOrDefault(c => c.Id == catalogId);

            return Task.FromResult(catalog);
        }
    }
}
