using NSE.WebApp.MVC.Extensions;

namespace NSE.WebApp.MVC.Services.Handlers
{
    public class HttpClienteAuthorizationDelegatingHandler:DelegatingHandler
    {
        private readonly IUser _user;

        public HttpClienteAuthorizationDelegatingHandler(IUser user)
        {
            _user = user;
        }


        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var authorizationHeader = _user.ObterHttpContext().Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                request.Headers.Add("Authorization", new List<string>() { authorizationHeader });
            }
            var token = _user.ObterUserToken();

            if (token != null)
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
