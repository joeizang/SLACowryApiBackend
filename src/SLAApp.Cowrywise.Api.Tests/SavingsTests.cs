using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serializers.SystemTextJson;
using SLACowryWise.Domain.Configuration;
using SLACowryWise.Domain.DTOs.Savings;
using SLACowryWise.Domain.Services;
using Xunit;

namespace SLAApp.Cowrywise.Api.Tests
{
    public class SavingsTests
    {
        const string id = "d1e08f90b4454a9db033ff4e0b39a6e0"; // savings id -> 92342f7bfd22486a81ee762655499d14
        private const string savingsId = "92342f7bfd22486a81ee762655499d14";
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
        public async void GetAllSavingsByCustomer_ReturnsSavingsPaginatedResponseDto()
        {
            var bootstrap = await BootstrapTest("/api/v1/savings", Method.GET);
            var result = await bootstrap.Client
                .ExecuteAsync<SavingsPaginatedResponseDto>(bootstrap.Request)
                .ConfigureAwait(false);
            Assert.NotNull(result.Data);
            Assert.IsType<SavingsPaginatedResponseDto>(result.Data);
        }

        [Fact]
        public async void CreateSavings_ReturnsCreateSavingsPayload()
        {
            var bootstrap = await BootstrapTest("/api/v1/savings", Method.POST);
            bootstrap.Request.AddParameter("account_id", $"{id}");
            bootstrap.Request.AddParameter("currency_code", "NGN");
            bootstrap.Request.AddParameter("days", "154");
            bootstrap.Request.AddParameter("interest_enabled", "1");

            var result = await bootstrap.Client
                .ExecuteAsync<SavingsCreatedResponseDto>(bootstrap.Request)
                .ConfigureAwait(false);
            Assert.NotNull(result.Data);
            Assert.Equal(result.Data.Data.AccountId, id);
        }

        [Fact]
        public async void GetSingleSavingsByID_ReturnsSingleSavingsByIDResponseDto()
        {
            var bootstrap = await BootstrapTest($"/api/v1/savings/{savingsId}", Method.GET);
            var result = await bootstrap.Client
                .ExecuteAsync<SingleSavingsByIdResponseDto>(bootstrap.Request)
                .ConfigureAwait(false);
            Assert.NotNull(result.Data);
            Assert.False(string.IsNullOrEmpty(result.Data.Data.SavingsId));
            Assert.Equal(result.Data.Data.SavingsId, savingsId);
        }
    }
}