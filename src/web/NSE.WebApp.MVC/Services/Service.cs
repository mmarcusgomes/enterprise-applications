using NSE.WebApp.MVC.Extensions;
using System.Net;
using System.Text;
using System.Text.Json;

namespace NSE.WebApp.MVC.Services
{
    public abstract class Service
    {
        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }
        protected StringContent ObterConteudo(object dado)
        {
            return new StringContent(JsonSerializer.Serialize(dado), Encoding.UTF8, "application/json");
        }
        protected bool TratarErroResponse(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.InternalServerError:
                    throw new CustomHttpRequestException(response.StatusCode);

                case HttpStatusCode.BadRequest:
                    return false;

            }
            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
