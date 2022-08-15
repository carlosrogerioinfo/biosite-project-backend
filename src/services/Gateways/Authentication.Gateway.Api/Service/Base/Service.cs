using Biosite.Core.Extensions;
using Biosite.Core.Response;
using FluentValidator;

namespace Authentication.Gateway.Api.Services.Base
{
    public abstract class Service : Notifiable
    {
        protected bool ResponseErrorHandling(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 405:
                case 500:
                case 400:
                    SetError(response);
                    return false;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }

        private void SetError(HttpResponseMessage response)
        {
            if ((int)response.StatusCode == 401)
            {
                AddNotification("Autenticação", "401: Usuário não autorizado");
                return;
            }

            if ((int)response.StatusCode == 403)
            {
                AddNotification("Autenticação", "403: Usuário sem permissão para efetuar essa requisição");
                return;
            }

            if ((int)response.StatusCode == 405)
            {
                AddNotification("Request", "405: Método não suportado");
                return;
            }

            var notifications = response.Content.ReadJsonAsync<ResponseError>("error").Result;
            foreach (var item in notifications.Errors)
            {
                AddNotification(item.Property, item.Message);
            }
        }
    }
}
