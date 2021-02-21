namespace Catalogs.API.Domain
{
    public class CatalogAttribute
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public CatalogAttributeDataType DataType { get; internal set; }
    }
}
