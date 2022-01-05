using Microsoft.Extensions.Options;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationConfiguration _config;

        public AuthenticationService(IHttpClientFactory httpClient, IOptions<AuthenticationConfiguration> config)
        {
            _http = httpClient.CreateClient();
            _config = config.Value;
        }

        public AuthenticationService(HttpClient httpClient, IOptions<AuthenticationConfiguration> config)
        {
            _http = httpClient;
            _config = config.Value;
        }

        public string GrantType => "client_credentials";

        public ApiToken ApiToken { get; private set; }

        public async Task<IAuthenticationService> GetApiToken()
        {
            try
            {
                _http.BaseAddress = new Uri(_config.EndPointBaseUrl);
                var dictionary = new Dictionary<string, string>
                {
                    {"grant_type", GrantType},
                    {"client_id", _config.ClientId},
                    {"client_secret", _config.ClientSecret}
                };
                HttpContent content = new FormUrlEncodedContent(dictionary);
                var request = new HttpRequestMessage(HttpMethod.Post, _config.TokenEndPoint);
                request.Content = content;
                request.Content.Headers.ContentType = new MediaTypeHeaderValue(Constants.ContentTypeFormUrlEnc)
                {
                    CharSet = "UTF-8"
                };
                var response = await _http.SendAsync(request).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Token acquisition failure");
                }
                var payload = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

                };
                ApiToken = JsonSerializer.Deserialize<ApiToken>(payload, options);
                return this;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task RefreshToken()
        {
            await GetApiToken().ConfigureAwait(false);
        }
    }
}