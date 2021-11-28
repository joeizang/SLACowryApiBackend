using System;
using System.Text.Json.Serialization;

namespace SLAApp.Cowrywise.Api.Tests
{
    public class AuthConfig
    {
        
    }
    
    public class AuthenticationConfiguration
    {
        public AuthenticationConfiguration(string clientId, string clientSecret, string endPointBaseUrl, string tokenEndPoint, string grantType = "")
        {
            if (!string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(clientSecret) &&
                !string.IsNullOrEmpty(endPointBaseUrl) && !string.IsNullOrEmpty(tokenEndPoint))
            {
                ClientId = clientId;
                ClientSecret = clientSecret;
                EndPointBaseUrl = endPointBaseUrl;
                TokenEndPoint = tokenEndPoint;
                GrantType = string.IsNullOrEmpty(grantType) ? "client_credentials" : grantType;
            }
            else
            {
                throw new Exception(
                    "One or more of the dependencies of this type are not in a valid state!");
            }
        }
        public string GrantType { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
        
        public string EndPointBaseUrl { get; set; }
        
        public string TokenEndPoint { get; set; }

        public string ApiVersion { get; set; } = "v1";
    }

    public class ApiToken
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }
    }
}