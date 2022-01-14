using RestSharp;
using SLACowryWise.Domain.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SLACowryWise.Domain
{
    public class HttpService : IHttpService
    {
        public HttpService(IAuthenticationService service)
        {
            _auth = service;
            _client = new RestClient("https://sandbox.embed.cowrywise.com");
        }

        private readonly IAuthenticationService _auth;

        private readonly RestClient _client;

        public async Task<RestClient> InitializeClient()
        {
            await _auth.GetApiToken()
                .ConfigureAwait(false);
            if (!string.IsNullOrEmpty(_auth.ApiToken.AccessToken))
            {
                _client.UseDefaultSerializers();
                _client.AddDefaultHeaders(new Dictionary<string, string>
                {
                    {"Authorization", $"Bearer {_auth.ApiToken.AccessToken}"}
                });
                return _client;
            }

            await _auth.RefreshToken().ConfigureAwait(false);
            _client.UseDefaultSerializers();
            _client.AddDefaultHeaders(new Dictionary<string, string>
            {
                {"Authorization", $"Bearer {_auth.ApiToken.AccessToken}"}
            });

            return _client;
        }
    }
}