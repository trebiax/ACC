using System.Globalization;

namespace Catalogs.API.Domain.DataTypeConvertions
{
    public class NumberDataTypeConverter : IDataTypeConverter
    {
        public object Convert(string value)
        {
            return decimal.Parse(value, CultureInfo.InvariantCulture);
        }
    }
}
