namespace Catalogs.API.Domain.DataTypeConvertions
{
    public class StringDataTypeConverter : IDataTypeConverter
    {
        public object Convert(string value)
        {
            return value;
        }
    }
}
