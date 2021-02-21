using System.Collections.Generic;
using System.Linq;

namespace Reporting.API.Application.Dtos
{
    public class CatalogMetadata
    {
        public int CatalogId { get; set; }
        public List<CatalogAttribute> Attributes { get; set; }

        // Ideally this should be more general
        public List<int> ElementIds { get; set; }

        public void CheckValidity()
        {
            // There must be an attribute which would be used for matching
            if (!(Attributes.Count(a => a.IsIdentifier) == 1))
                throw new System.Exception("Metadata must have 1 identifier");
        }
    }
}
