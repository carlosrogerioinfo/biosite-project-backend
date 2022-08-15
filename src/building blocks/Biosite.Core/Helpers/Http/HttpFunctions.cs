using Biosite.Core.JsonSettings;
using System;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace Biosite.Core.Helpers.Http
{
    public class HttpFunctions
    {
        public static Uri SetBaseAdressForApi(string address)
        {
            return new Uri(address);
        }

        public static HttpContent CreateContent(object content)
        {
            var stringContent = JsonSerializer.Serialize(content, JsonSerializerSettings.ConfigWrite);
            return new StringContent(stringContent, Encoding.UTF8, MediaTypeNames.Application.Json);
        }
    }
}
