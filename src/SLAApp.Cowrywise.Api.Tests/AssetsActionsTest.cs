using RestSharp;
using SLACowryWise.Domain.DTOs.Assets;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SLAApp.Cowrywise.Api.Tests
{
    public class AssetsActionsTest
    {
        private const string AssetId = "dd08ec82-4e0b-4928-abb9-b22f26cd3f30";
        private const string AssetId1 = "38b8b210-5e48-43fe-920f-1da3722b9717";
        [Fact]
        public async void GetAllAssets_ReturnsAssetsPaginatedResponseDto()
        {
            var bootstrap = await BootstrapTest("/api/v1/assets", Method.Get);
            var result = await bootstrap.Client
                .ExecuteAsync<AssetsPaginatedResponse>(bootstrap.Request)
                .ConfigureAwait(false);
            Assert.NotNull(result.Data);
            Assert.IsType<AssetsPaginatedResponse>(result.Data);
        }

        [Fact]
        public async void GetSingleAssetById_ReturnsSingleAssetsResponse()
        {
            var bootstrap = await BootstrapTest($"/api/v1/assets/{AssetId}", Method.Get);
            var result = await bootstrap.Client.ExecuteAsync<SingleAssetRoot>(bootstrap.Request).ConfigureAwait(false);
            Assert.NotNull(result.Data);
            Assert.Contains("NGN", result.Data.Data.Currency);
            Assert.False(string.IsNullOrEmpty(result.Data.Data.AssetId));
            Assert.Contains("success", result.Data.Status);
        }

        private async Task<AccountActionsTests.BootstrapProps> BootstrapTest(string resource, RestSharp.Method method)
        {
            var config = new AuthenticationConfiguration(
                "CWRY-QMjMdkxOr1R5sXD2EvmJUPt03KhKURDsPMbM5i5k",
                "CWRY-SECRET-1UZJLwy726yjrw0b66kVudkAr7u5xOReWmBRMvdLivgt4xvBI2FmBlK7qPXApWImyqgS7gMXlyzqBfnzjnZWeqqnfMxoeduXKQHjY1KrDAf8DiOiYbJIf7cFe1OT9sHZ",
                "https://sandbox.embed.cowrywise.com",
                "/o/token/"
            );
            var auth = new AuthenticationService(new HttpClient(), config);
            await auth.GetApiToken()
                .ConfigureAwait(false);

            var client = new RestClient("https://sandbox.embed.cowrywise.com");
            client.UseDefaultSerializers();
            client.AddDefaultHeaders(new Dictionary<string, string>
            {
                {"Authorization", $"Bearer {auth.ApiToken.AccessToken}"}
            });

            var request = new RestRequest(resource, method);
            return new AccountActionsTests.BootstrapProps { Client = client, Request = request };
        }
    }
}