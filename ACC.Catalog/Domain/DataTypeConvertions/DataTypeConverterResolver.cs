using System;

namespace Catalogs.API.Domain.DataTypeConvertions
{
    public class DataTypeConverterResolver
    {
        public static IDataTypeConverter GetDataTypeConverter(CatalogAttributeDataType dataType)
        {
            return dataType switch
            {
                CatalogAttributeDataType.Number => new NumberDataTypeConverter(),
                CatalogAttributeDataType.Text => new StringDataTypeConverter(),
                _ => throw new ArgumentException("No relevant converter found")
            };
        }
    }
}
