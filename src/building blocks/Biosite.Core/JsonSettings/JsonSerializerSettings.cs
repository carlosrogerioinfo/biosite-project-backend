using System.Text.Json;
using System.Text.Json.Serialization;

namespace Biosite.Core.JsonSettings
{
    public class JsonSerializerSettings
    {
        public static readonly JsonSerializerOptions Config = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true,
        };

        public static readonly JsonSerializerOptions ConfigWrite = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
        };
    }
}
