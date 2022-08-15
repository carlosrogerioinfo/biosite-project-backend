using System.Text.Json.Serialization;

namespace Authentication.Gateway.Api.Response
{
    public class BloodTypeResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
