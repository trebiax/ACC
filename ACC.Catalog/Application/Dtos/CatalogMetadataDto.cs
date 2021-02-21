using System.Collections.Generic;

namespace Catalogs.API.Application.Dtos
{
    public class CatalogMetadataDto
    {
        public int CatalogId { get; set; }
        public string CatalogName { get; set; }
        public List<CatalogAttributeDto> Attributes { get; set; }
    }
}
