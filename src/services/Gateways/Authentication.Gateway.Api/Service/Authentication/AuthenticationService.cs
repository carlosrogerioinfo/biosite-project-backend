using Authentication.Gateway.Api.Request;
using Authentication.Gateway.Api.Services.Base;
using Biosite.Core.Commands.Response;
using Biosite.Core.Extensions;

namespace Authentication.Gateway.Api.Services.Authentication
{
    public class AuthenticationService : Service
    {
        public readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AuthenticationResponse> Authentication(AuthenticationRequest request)
        {
            _httpClient.DefaultRequestHeaders.Clear();

            var response = await _httpClient
                .PostJsonAsync($"login", request);

            if (!ResponseErrorHandling(response))
                return default;

            return await response.Content.ReadJsonAsync<AuthenticationResponse>("data");
        }
    }
}