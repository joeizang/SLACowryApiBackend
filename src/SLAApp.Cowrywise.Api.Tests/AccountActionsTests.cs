using RestSharp;
using SLACowryWise.Domain.DTOs.Accounts;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace SLAApp.Cowrywise.Api.Tests
{
    public class AccountActionsTests
    {
        private const string TestId = "d1e08f90b4454a9db033ff4e0b39a6e0";
        private const string TestId1 = "192473e0224741e294f8d97d60689e6a";
        [Fact]
        public async void CreateAccount()
        {
            var user = new CreateAccountInputModel
            {
                FirstName = "slatester9",
                LastName = "slaorg9",
                Email = "slatest9@slatester.com"
            };
            var bootstrap = await BootstrapTest("/api/v1/accounts", Method.Post);
            bootstrap.Request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            bootstrap.Request.AddParameter("first_name", user.FirstName, ParameterType.GetOrPost);
            bootstrap.Request.AddParameter("last_name", user.LastName, ParameterType.GetOrPost);
            bootstrap.Request.AddParameter("email", user.Email, ParameterType.GetOrPost);
            var result = await bootstrap.Client.ExecuteAsync(bootstrap.Request).ConfigureAwait(false);
            var response = JsonSerializer.Deserialize<AccountCreationResponse>(result.Content);
            Assert.NotNull(response);
            Assert.False(string.IsNullOrEmpty(response.Data.AccountId));
        }

        [Fact]
        public async void GetSingleAccount_ReturnsAccountCreationDto()
        {
            var bootstrap = await BootstrapTest($"/api/v1/accounts/{TestId1}", Method.Get);
            var result = await bootstrap.Client.ExecuteAsync(bootstrap.Request).ConfigureAwait(false);
            var response = JsonSerializer.Deserialize<AccountCreationResponse>(result.Content);
            Assert.NotNull(response);
            Assert.False(string.IsNullOrEmpty(response.Data.AccountId));
        }

        [Fact]
        public async void GetPortfolio_ReturnsAccountPortfolioDto()
        {
            var bootstrap = await BootstrapTest($"/api/v1/accounts/{TestId}/portfolio", Method.Get).ConfigureAwait(false);
            var result = await bootstrap.Client.ExecuteAsync(bootstrap.Request).ConfigureAwait(false);
            var response = JsonSerializer.Deserialize<AccountPortfolioResponse>(result.Content);

            Assert.NotNull(response);
            Assert.IsType<AccountPortfolioResponse>(response);
        }

        [Fact]
        public async void UpdateAccountAddress_ReturnsAccountCreationDto()
        {
            var bootstrap = await BootstrapTest($"/api/v1/accounts/{TestId}/address", Method.Post);
            var updatedAddress = new AddressUpdateInputModel
            {
                City = "Jos",
                AreaCode = "930292",
                Country = "NG",
                Lga = "Jos-South",
                State = "Plateau",
                Street = "Main Street Avenue"
            };
            bootstrap.Request.AddParameter("area_code", updatedAddress.AreaCode, ParameterType.GetOrPost);
            bootstrap.Request.AddParameter("lga", updatedAddress.Lga, ParameterType.GetOrPost);
            bootstrap.Request.AddParameter("state", updatedAddress.State, ParameterType.GetOrPost);
            bootstrap.Request.AddParameter("city", updatedAddress.City, ParameterType.GetOrPost);
            bootstrap.Request.AddParameter("country", updatedAddress.Country, ParameterType.GetOrPost);
            bootstrap.Request.AddParameter("street", updatedAddress.Street, ParameterType.GetOrPost);
            var result = await bootstrap.Client.ExecuteAsync(bootstrap.Request).ConfigureAwait(false);
            var response = JsonSerializer.Deserialize<AccountCreationResponse>(result.Content);

            Assert.NotNull(response);
            Assert.IsType<AccountCreationResponse>(response);
        }




        private async Task<BootstrapProps> BootstrapTest(string resource, Method method)
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
            client.AddDefaultHeaders(new Dictionary<string, string>
            {
                {"Authorization", $"Bearer {auth.ApiToken.AccessToken}"}
            });

            var request = new RestRequest(resource, method);
            return new BootstrapProps { Client = client, Request = request };
        }

        public class BootstrapProps
        {
            public RestClient Client { get; set; }

            public RestRequest Request { get; set; }
        }
    }
}