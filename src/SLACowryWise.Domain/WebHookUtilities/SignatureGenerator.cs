using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using SLACowryWise.Domain.Configuration;

namespace SLACowryWise.Domain.WebHookUtilities
{
    public class SignatureGenerator : ISignatureGenerator
    {
        private AuthenticationConfiguration _configuration;

        public SignatureGenerator(IOptions<AuthenticationConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }

        public string PrepSignature()
        {
            var key = Encoding.UTF8.GetBytes(_configuration.ClientSecret);
            byte[] hash;
            using (var hmac = new HMACSHA256(key))
            {
                hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(_configuration.ClientId));
            }
            return Convert.ToString(hash).ToUpperInvariant();
        }
    }
}