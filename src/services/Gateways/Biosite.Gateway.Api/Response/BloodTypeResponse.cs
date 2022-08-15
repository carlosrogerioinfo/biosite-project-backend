using System.Text.Json.Serialization;

namespace Biosite.Gateway.Api.Response
{
    public class BloodTypeResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
