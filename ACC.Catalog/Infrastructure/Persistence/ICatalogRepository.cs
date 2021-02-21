using Catalogs.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogs.API.Infrastructure.Persistence
{
    public interface ICatalogRepository
    {
        Task<Catalog> GetCatalog(int catalogId);
    }
}
