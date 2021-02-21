using Catalogs.API.Application.Dtos;
using Catalogs.API.Domain;
using Catalogs.API.Infrastructure.Persistence;
using Common.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogs.API.Application.CommandExecutors
{
    public class CatalogCommandExecutor
    {
        private readonly ICatalogRepository _repository;

        public CatalogCommandExecutor(ICatalogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Dictionary<string, object>>> GetCatalog(int catalogId)
        {
            var catalog = await _repository.GetCatalog(catalogId);

            if (catalog == null)
                throw new NotFoundException();

            return catalog.Elements.Select(el => 
            {
                return el.Fields.Select(field =>
                {
                    var attribute = catalog.Attributes.First(a => a.Id == field.Key);

                    return new { Key = attribute.Name, Value = field.Value };
                })
                .ToDictionary(f => f.Key, f => f.Value);

            }).ToList();
        }

        public async Task<CatalogMetadataDto> GetCatalogMetadata(int catalogId)
        {
            var catalog = await _repository.GetCatalog(catalogId);

            if (catalog == null)
                throw new NotFoundException();

            return new CatalogMetadataDto()
            {
                CatalogName = catalog.Name,
                CatalogId = catalog.Id,
                Attributes = catalog.Attributes.Select(a => new CatalogAttributeDto
                {
                   Id = a.Id,
                   Name = a.Name,
                   DataType = a.DataType
                }).ToList()
            };
        }
    }
}
