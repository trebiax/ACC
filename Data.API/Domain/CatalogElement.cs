using System.Collections.Generic;
using System.Linq;

namespace Data.API.Domain
{
    public class CatalogElement
    {
        public int CatalogId { get; set; }
        public int ElementId { get; set; }

        public bool MatchesTo(CatalogElement element)
        {
            return CatalogId == element.CatalogId && ElementId == element.ElementId;
        }
    }
}
