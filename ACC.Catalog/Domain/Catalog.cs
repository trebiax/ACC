using Catalogs.API.Domain.DataTypeConvertions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalogs.API.Domain
{
    public class Catalog
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public List<CatalogAttribute> Attributes { get; internal set; }
        public List<CatalogElement> Elements { get; set; }

        public object ConvertToElementFieldValue(string value, int attributeId)
        {
            var attribute = Attributes.SingleOrDefault(async => async.Id == attributeId);

            if (attribute == null)
                throw new ArgumentException("No attribute with provided id exists");

            return DataTypeConverterResolver.GetDataTypeConverter(attribute.DataType)
                                            .Convert(value);
        }
    }
}
