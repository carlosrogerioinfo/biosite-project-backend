using Biosite.Gateway.Api.Services.Base;
using Biosite.Core.Extensions;
using Biosite.Domain.Commands.Request.User;
using Biosite.Gateway.Api.Response;

namespace Biosite.Gateway.Api.Services.Profile
{
    public class ProfileService : Service
    {
        public readonly HttpClient _httpClient;

        public ProfileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProfileResponse> GetById(Guid id, string token)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.AddTokenAuthorization(token);

            var response = await _httpClient
                .GetJsonAsync($"profile/get/{id}");

            if (!ResponseErrorHandling(response))
                return default;

            return await response.Content.ReadJsonAsync<ProfileResponse>("data");
        }

        public async Task<ProfileResponse> Put(UpdateProfileRequest command, string token)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.AddTokenAuthorization(token);

            var response = await _httpClient
                .PutJsonAsync($"profile/put", command);

            if (!ResponseErrorHandling(response))
                return default;

            return await response.Content.ReadJsonAsync<ProfileResponse>("data");
        }

        public async Task<ProfileResponse> ProfileInfo(AuthenticateUserRequest request, string token)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.AddTokenAuthorization(token);

            var response = await _httpClient
                .PostJsonAsync($"profile/info", request);

            if (!ResponseErrorHandling(response))
                return default;

            return await response.Content.ReadJsonAsync<ProfileResponse>("data");
        }
    }
}