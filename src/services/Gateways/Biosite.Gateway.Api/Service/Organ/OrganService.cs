using Biosite.Core.Extensions;
using Biosite.Domain.Commands.Response;
using Biosite.Gateway.Api.Services.Base;

namespace Biosite.Gateway.Api.Services.Organ
{
    public class OrganService : Service
    {
        public readonly HttpClient _httpClient;

        public OrganService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<OrganResponse>> GetAll(string token)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.AddTokenAuthorization(token);

            var response = await _httpClient
                .GetJsonAsync($"organ/crud/get");

            if (!ResponseErrorHandling(response))
                return default;

            return await response.Content.ReadJsonAsync<IEnumerable<OrganResponse>>("data");
        }
    }
}