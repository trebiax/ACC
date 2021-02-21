using Catalogs.API.Domain;

namespace Catalogs.Client.Contracts
{
    public class CatalogAttributeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CatalogAttributeDataType DataType { get; set; }
    }
}
