using System.Text.Json.Serialization;

namespace Biosite.Gateway.Api.Response
{
    public class PlanResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("areas")]
        public ICollection<AreaResponse> Areas { get; set; }
    }
}
