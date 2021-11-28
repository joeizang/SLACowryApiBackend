using SLACowryWise.Domain.WebHookUtilities;
using Xunit;

namespace SLAApp.Cowrywise.Api.Tests
{
    public class WebHookTests
    {
        [Fact]
        public void GenerateSignatureReturnsHexString()
        {
            var config = new AuthenticationConfiguration(
                "CWRY-QMjMdkxOr1R5sXD2EvmJUPt03KhKURDsPMbM5i5k",
                "CWRY-SECRET-1UZJLwy726yjrw0b66kVudkAr7u5xOReWmBRMvdLivgt4xvBI2FmBlK7qPXApWImyqgS7gMXlyzqBfnzjnZWeqqnfMxoeduXKQHjY1KrDAf8DiOiYbJIf7cFe1OT9sHZ",
                "https://sandbox.embed.cowrywise.com",
                "/o/token/"
            );
            // var generator = new SignatureGenerator(config);
            // var result = generator.PrepSignature();
            
            // Assert.NotEmpty(result);
        }
    }
}