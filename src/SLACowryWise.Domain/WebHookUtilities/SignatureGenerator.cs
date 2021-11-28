using System;
using System.Security.Cryptography;
using System.Text;
using SLACowryWise.Domain.Configuration;

namespace SLACowryWise.Domain.WebHookUtilities
{
    public class SignatureGenerator
    {
        private AuthenticationConfiguration _configuration;

        public SignatureGenerator(AuthenticationConfiguration configuration)
        {
            _configuration = configuration;
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