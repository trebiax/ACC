using System.Text.Json.Serialization;

namespace Catalogs.API.Domain
{
    // To display in json as string and not number
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CatalogAttributeDataType
    {
        Text,
        Number
    }
}
