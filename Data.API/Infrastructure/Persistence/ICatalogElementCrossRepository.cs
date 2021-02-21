using Data.API.Application.Dtos;
using Data.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.API.Infrastructure.Persistence
{
    public interface ICatalogElementCrossRepository
    {
        Task<List<CatalogElementCross>> GetCatalogElementCrosses(List<CatalogElementCrossDto> dtos);
    }
}
