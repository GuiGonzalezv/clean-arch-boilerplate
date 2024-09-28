using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AgrotoolsMaps.Api.Responses
{
    public static class JsonSerializer
    {
        private static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public static string SerializeObject(object data)
        {
            return JsonConvert.SerializeObject(data, Formatting.Indented, settings);
        }
    }
}