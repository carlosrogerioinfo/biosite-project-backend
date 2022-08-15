using Biosite.Core.Helpers.Http;
using Biosite.Core.JsonSettings;
using Biosite.Core.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Biosite.Core.Extensions
{
    public static class HttpClientExtensions
    {
        //READ
        public static async Task<T> ReadJsonAsync<T>(this HttpContent content, string jsonElement = null)
        {
            try
            {
                if (content == null)
                    throw new CustomHttpRequestException(nameof(content));

                string contentResponse = await content
                    .ReadAsStringAsync();

                if (jsonElement != null)
                {
                    var json = JsonDocument.Parse(contentResponse);
                    if (json.RootElement.TryGetProperty(jsonElement, out var jsonPropertyValue))
                    {
                        return string.IsNullOrEmpty(contentResponse) ? default : JsonSerializer.Deserialize<T>(json.RootElement.GetProperty(jsonElement).ToString(), JsonSerializerSettings.Config);
                    }
                }

                return string.IsNullOrEmpty(contentResponse) ? default : JsonSerializer.Deserialize<T>(contentResponse, JsonSerializerSettings.Config);
            }
            catch (Exception e)
            {
                var exceptionError = new ResponseError { Errors = new List<Error>() };
                exceptionError.Errors.Add(new Error { Property = "Exception", Message = e.Message });
                return JsonSerializer.Deserialize<T>(await HttpFunctions.CreateContent(new ResponseError { Success = false, Errors = exceptionError.Errors }).ReadAsStringAsync(), JsonSerializerSettings.Config);
            }
        }

        //GET
        public static async Task<HttpResponseMessage> GetJsonAsync(this HttpClient client, string url)
        {
            if (client == null)
                throw new CustomHttpRequestException(nameof(client));

            return await client.GetAsync(string.Concat(client.BaseAddress, url));
        }

        //POST
        public static async Task<HttpResponseMessage> PostJsonAsync(this HttpClient client, string url, object data)
        {
            if (client == null)
                throw new CustomHttpRequestException(nameof(client));

            return await client.PostAsync(string.Concat(client.BaseAddress, url), HttpFunctions.CreateContent(data));
        }

        public static async Task<HttpResponseMessage> PostJsonFormEncodedAsync(this HttpClient client, string url, Dictionary<string, string> data)
        {
            if (client == null)
                throw new CustomHttpRequestException(nameof(client));

            return await client.PostAsync(string.Concat(client.BaseAddress, url), new FormUrlEncodedContent(data));
        }

        //PUT
        public static async Task<HttpResponseMessage> PutJsonAsync(this HttpClient client, string url, object data)
        {
            if (client == null)
                throw new CustomHttpRequestException(nameof(client));

            return await client.PutAsync(string.Concat(client.BaseAddress, url), HttpFunctions.CreateContent(data));
        }

        //PATCH
        public static async Task<HttpResponseMessage> PatchJsonAsync(this HttpClient client, string url, object data)
        {
            if (client == null)
                throw new CustomHttpRequestException(nameof(client));

            return await client.PatchAsync(string.Concat(client.BaseAddress, url), HttpFunctions.CreateContent(data));
        }

        //DELETE
        public static async Task<HttpResponseMessage> DeleteJsonAsync(this HttpClient client, string url)
        {
            if (client == null)
                throw new CustomHttpRequestException(nameof(client));

            return await client.DeleteAsync(string.Concat(client.BaseAddress, url));
        }

        public static void AddTokenAuthorization(this HttpClient client, string token)
        {
            try
            {
                var jwt = (string.IsNullOrEmpty(token) ? string.Empty : token.Replace("bearer", string.Empty).Replace("Bearer", string.Empty).Trim());
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            }
            catch
            {
                throw new CustomHttpRequestException(nameof(client));
            }
        }
    }
}
