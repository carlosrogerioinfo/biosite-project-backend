using Biosite.Gateway.Api.Services.Base;
using Biosite.Core.Extensions;
using Biosite.Domain.Commands.Request.Biomarker;
using Biosite.Domain.Commands.Response;

namespace Biosite.Gateway.Api.Services.Biomarker
{
    public class BiomarkerService : Service
    {
        public readonly HttpClient _httpClient;

        public BiomarkerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BiomarkerResponse> GetById(Guid id, string token)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.AddTokenAuthorization(token);

            var response = await _httpClient
                .GetJsonAsync($"biomarker/get-by-id/{id}");

            if (!ResponseErrorHandling(response))
                return default;

            return await response.Content.ReadJsonAsync<BiomarkerResponse>("data");
        }

        public async Task<IEnumerable<BiomarkerResponse>> GetAll(string token)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.AddTokenAuthorization(token);

            var response = await _httpClient
                .GetJsonAsync($"biomarker/crud/get");

            if (!ResponseErrorHandling(response))
                return default;

            return await response.Content.ReadJsonAsync<IEnumerable<BiomarkerResponse>>("data");
        }

        public async Task<BiomarkerResponse> GetByName(string name, string token)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.AddTokenAuthorization(token);

            var response = await _httpClient
                .GetJsonAsync($"biomarker/crud/get-by-name/{name}");

            if (!ResponseErrorHandling(response))
                return default;

            return await response.Content.ReadJsonAsync<BiomarkerResponse>("data");
        }

        public async Task<BiomarkerResponse> Save(RegisterBiomarkerRequest command, string token)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.AddTokenAuthorization(token);

            var response = await _httpClient
                .PostJsonAsync($"biomarker/crud/save", command);

            if (!ResponseErrorHandling(response))
                return default;

            return await response.Content.ReadJsonAsync<BiomarkerResponse>("data");
        }

        public async Task<BiomarkerResponse> Put(UpdateBiomarkerRequest command, string token)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.AddTokenAuthorization(token);

            var response = await _httpClient
                .PutJsonAsync($"biomarker/crud/put", command);

            if (!ResponseErrorHandling(response))
                return default;

            return await response.Content.ReadJsonAsync<BiomarkerResponse>("data");
        }

        public async Task<BiomarkerResponse> Delete(DeleteBiomarkerRequest command, string token)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.AddTokenAuthorization(token);

            var response = await _httpClient
                .DeleteJsonAsync($"biomarker/crud/delete?id={command.Id}");

            if (!ResponseErrorHandling(response))
                return default;

            return await response.Content.ReadJsonAsync<BiomarkerResponse>("data");
        }
    }
}