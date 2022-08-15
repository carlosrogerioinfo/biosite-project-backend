using System.Text.Json.Serialization;

namespace Authentication.Gateway.Api.Response
{
    public class UserResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("genderDescription")]
        public string Gender { get; set; }

        [JsonPropertyName("pregnant")]
        public bool Pregnant { get; set; }

        [JsonPropertyName("height")]
        public string Height { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("imc")]
        public string Imc { get; set; }

        [JsonPropertyName("imcResult")]
        public string ImcResult { get; set; }

        [JsonPropertyName("lastLoginAt")]
        public string LastLoginAt { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("plan")]
        public PlanResponse Plan { get; set; }
        
        [JsonPropertyName("bloodType")]
        public BloodTypeResponse BloodType { get; set; }
    }
}

public class Area
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}

public class BloodTypeResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}

public class PlanArea
{
    [JsonPropertyName("area")]
    public Area Area { get; set; }
}

public class PlanResponse
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("planAreas")]
    public List<PlanArea> PlanAreas { get; set; }
}