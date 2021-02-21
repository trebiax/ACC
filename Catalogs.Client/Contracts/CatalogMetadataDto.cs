using System.Collections.Generic;

namespace Catalogs.Client.Contracts
{
    public class CatalogMetadataDto
    {
        public int CatalogId { get; set; }
        public string CatalogName { get; set; }
        public List<CatalogAttributeDto> Attributes { get; set; }
    }
}
