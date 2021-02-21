using Data.API.Domain;
using System.Collections.Generic;

namespace Data.API.Infrastructure.Persistence
{
    public class CatalogElementCrossDb
    {
        public List<CatalogElementCross> CatalogElementCrosses { get; private set; }

        public CatalogElementCrossDb()
        {
            CatalogElementCrosses = new List<CatalogElementCross>
            {
                new CatalogElementCross
                {
                    FirstElement = new CatalogElement
                    {
                        CatalogId = 1,
                        ElementId = 1
                    },
                    SecondElement = new CatalogElement
                    {
                        CatalogId = 2,
                        ElementId = 1
                    },
                    Amount = 1
                },
                new CatalogElementCross
                {
                    FirstElement = new CatalogElement
                    {
                        CatalogId = 1,
                        ElementId = 1
                    },
                    SecondElement = new CatalogElement
                    {
                        CatalogId = 2,
                        ElementId = 2
                    },
                    Amount = 2
                },
                new CatalogElementCross
                {
                    FirstElement = new CatalogElement
                    {
                        CatalogId = 1,
                        ElementId = 1
                    },
                    SecondElement = new CatalogElement
                    {
                        CatalogId = 2,
                        ElementId = 3
                    },
                    Amount = 3
                },
                new CatalogElementCross
                {
                    FirstElement = new CatalogElement
                    {
                        CatalogId = 1,
                        ElementId = 2
                    },
                    SecondElement = new CatalogElement
                    {
                        CatalogId = 2,
                        ElementId = 1
                    },
                    Amount = 4
                },
                new CatalogElementCross
                {
                    FirstElement = new CatalogElement
                    {
                        CatalogId = 1,
                        ElementId = 2
                    },
                    SecondElement = new CatalogElement
                    {
                        CatalogId = 2,
                        ElementId = 2
                    },
                    Amount = 5
                },
                new CatalogElementCross
                {
                    FirstElement = new CatalogElement
                    {
                        CatalogId = 1,
                        ElementId = 2
                    },
                    SecondElement = new CatalogElement
                    {
                        CatalogId = 2,
                        ElementId = 3
                    },
                    Amount = 6
                },
                new CatalogElementCross
                {
                    FirstElement = new CatalogElement
                    {
                        CatalogId = 1,
                        ElementId = 3
                    },
                    SecondElement = new CatalogElement
                    {
                        CatalogId = 2,
                        ElementId = 1
                    },
                    Amount = 7
                },
                new CatalogElementCross
                {
                    FirstElement = new CatalogElement
                    {
                        CatalogId = 1,
                        ElementId = 3
                    },
                    SecondElement = new CatalogElement
                    {
                        CatalogId = 2,
                        ElementId = 2
                    },
                    Amount = 8
                },
                new CatalogElementCross
                {
                    FirstElement = new CatalogElement
                    {
                        CatalogId = 1,
                        ElementId = 3
                    },
                    SecondElement = new CatalogElement
                    {
                        CatalogId = 2,
                        ElementId = 3
                    },
                    Amount = 9
                }
            };

            IsValid();
        }

        private void IsValid()
        {
            // [TODO]: Check no double matchings
        }
    }
}
