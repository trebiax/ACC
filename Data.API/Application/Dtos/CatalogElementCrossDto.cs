using Data.API.Domain;
namespace Data.API.Application.Dtos
{
    public class CatalogElementCrossDto
    {
        public CatalogElement FirstElement { get; set; }
        public CatalogElement SecondElement { get; set; }

        public bool MatchesTo(CatalogElementCross cross)
        {
            return FirstElement.MatchesTo(cross.FirstElement) && SecondElement.MatchesTo(cross.SecondElement)
                   ||
                   FirstElement.MatchesTo(cross.SecondElement) && SecondElement.MatchesTo(cross.FirstElement);
        }
    }
}
