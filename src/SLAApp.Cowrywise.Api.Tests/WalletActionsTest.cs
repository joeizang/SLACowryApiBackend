using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serializers.SystemTextJson;
using SLACowryWise.Domain.Configuration;
using SLACowryWise.Domain.DTOs.Wallets;
using SLACowryWise.Domain.Services;
using Xunit;

namespace SLAApp.Cowrywise.Api.Tests
{
    public class WalletActionsTest
    {
        const string id = "d1e08f90b4454a9db033ff4e0b39a6e0";
        private const string TestId1 = "192473e0224741e294f8d97d60689e6a";
        private const string WalletID = "ff8f01a6457a4bf2a1735e00332c2dd9"; // USD tied to id
        private const string WalletID1 = "a9cf5503682541a48a840bdde53efd41"; // NGN tied to id
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
            client.UseSystemTextJson(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            client.AddDefaultHeaders(new Dictionary<string, string>
            {
                {"Authorization", $"Bearer {auth.ApiToken.AccessToken}"}
            });
                
            var request = new RestRequest(resource, method);
            return new AccountActionsTests.BootstrapProps { Client = client, Request = request };
        }

        [Fact]
        public async void CreateWalletForAccount_ReturnsCreateWalletResponseDto()
        {
            var bootstrap = await BootstrapTest("/api/v1/wallets", Method.POST);
            bootstrap.Request.AddParameter("account_id", $"{TestId1}", ParameterType.GetOrPost);
            bootstrap.Request.AddParameter("currency_code", "NGN");
            var result = await bootstrap.Client
                .ExecuteAsync<CreateWalletResponseDto>(bootstrap.Request)
                .ConfigureAwait(false);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async void GetAllWalletsReturnsWalletPaginatedResponseDto()
        {
            var bootstrap = await BootstrapTest("/api/v1/wallets", Method.GET);
            bootstrap.Request.AddParameter("page", "2");
            bootstrap.Request.AddParameter("page_count", 2);
            var result = await bootstrap.Client
                .ExecuteAsync<WalletPaginatedDtoRoot>(bootstrap.Request)
                .ConfigureAwait(false);
            Assert.NotNull(result.Data);
            Assert.IsType<WalletPaginatedDtoRoot>(result.Data);
            Assert.NotEmpty(result.Data.Data);
        }

        [Fact]
        public async void GetSingleWalletReturns()
        {
            
        }
    }
}