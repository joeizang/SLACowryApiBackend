using RestSharp;
using SLACowryWise.Domain;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Data;
using SLACowryWise.Domain.DTOs;
using SLACowryWise.Domain.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SLAApp.Cowrywise.Api.Tests
{
    public class CowryServiceTests
    {

        [Fact]
        public async void GetBanksWithReturnsBankResponse()
        {
            var bootstrap = await BootstrapTest("api/v1/misc/banks", Method.Get).ConfigureAwait(false);
            var input = new GetPaginatedResponseInputModel
            {
                Page = "1",
                PageSize = "20"
            };
            bootstrap.Request.AddParameter("page", input.Page, ParameterType.GetOrPost);
            bootstrap.Request.AddParameter("page_size", input.PageSize, ParameterType.GetOrPost);
            var result = await bootstrap.Client.ExecuteAsync<BankResponse>(bootstrap.Request).ConfigureAwait(false);
            Assert.NotNull(result.Data);
            Assert.Contains("successful", result.Data.Message);
        }

        [Fact]
        public async void GetBanksFromDb()
        {
            IMongoDatabaseSettings settings = new MongoDatabaseSettings
            {
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "SLACowryWiseDb",
                CollectionName = "CowryBanks"
            };
            ICacheBanksFromCowry cache = new CacheBanksFromCowry(settings);
            var result = await cache.GetDocsAsync().ConfigureAwait(false);
            Assert.IsType<List<Bank>>(result);
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
