using Microsoft.Extensions.Options;
using SLACowryWise.Domain.Configuration;
using System;
using System.Security.Cryptography;
using System.Text;

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
            return Convert.ToHexString(hash).ToUpperInvariant();
        }
    }
}