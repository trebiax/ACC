using System.Collections.Generic;

namespace Reporting.API.Application.Dtos
{
    public class CatalogMetadataPresentation
    {
        public int CatalogId { get; set; }
        public List<CatalogAttribute> Attributes { get; set; }
    }
}
