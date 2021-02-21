using Newtonsoft.Json;

namespace Reporting.API.Application
{
    public class DtoResolver<T>
    {
        public static T DeserializeFrom(string value)
        {
            if (value is null)
            {
                throw new System.ArgumentNullException(nameof(value));
            }

            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
