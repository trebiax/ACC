namespace Catalogs.API.Domain.DataTypeConvertions
{
    public interface IDataTypeConverter
    {
        object Convert(string value);
    }
}
