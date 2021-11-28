using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serializers.SystemTextJson;
using SLACowryWise.Domain.Configuration;
using SLACowryWise.Domain.DTOs.Investments;
using SLACowryWise.Domain.DTOs.Wallets;
using SLACowryWise.Domain.Services;
using Xunit;

namespace SLAApp.Cowrywise.Api.Tests
{
    public class InvestmentActionsTest
    {
        private const string AssetCode = "AST-FUND-0258835412";
        private const string AssetCode1 = "AST-FUND-1843078640";
        private const string WalletID1 = "a9cf5503682541a48a840bdde53efd41"; // NGN tied to id
        const string id = "d1e08f90b4454a9db033ff4e0b39a6e0";
        private const string investmentId = "2c8bc3bc-c411-41d8-a1b6-8dc925636f0e";

        [Fact]
        public async void CreateInvestment_Returns()
        {
            var bootstrap = await BootstrapTest("/api/v1/investments", Method.POST);
            bootstrap.Request.AddParameter("account_id", "d1e08f90b4454a9db033ff4e0b39a6e0", ParameterType.GetOrPost);
            bootstrap.Request.AddParameter("asset_code", AssetCode1, ParameterType.GetOrPost);
            var result = await bootstrap.Client
                .ExecuteAsync<SingleInvestmentResponseDto>(bootstrap.Request)
                .ConfigureAwait(false);
            Assert.NotNull(result);
            Assert.IsType<SingleInvestmentResponseDto>(result.Data);
        }

        [Fact]
        public async void GetAllInvestments_ReturnsInvestmentPaginatedResponse()
        {
            var bootstrap = await BootstrapTest("/api/v1/investments", Method.GET);
            bootstrap.Request.AddParameter("asset_code", AssetCode1, ParameterType.GetOrPost);
            var result = await bootstrap.Client
                .ExecuteAsync<InvestmentPaginatedDtoResponse>(bootstrap.Request)
                .ConfigureAwait(false);
            Assert.NotNull(result.Data);
            Assert.False(string.IsNullOrEmpty(result.Data.Data.Single().AssetType));
            Assert.False(string.IsNullOrEmpty(result.Data.Data.Single().InvestmentId));
        }

        [Fact]
        public async void FundInvestmentByProductCode_Returns()
        {
            var bootstrap = await BootstrapTest($"/api/v1/wallets/{WalletID1}/transfer", Method.POST);
            bootstrap.Request.AddParameter("product_code", "PRCDE6909476183", ParameterType.GetOrPost);
            bootstrap.Request.AddParameter("amount", "5000000", ParameterType.GetOrPost);
            var result = await bootstrap.Client
                .ExecuteAsync<TransferFromWalletResponseDto>(bootstrap.Request)
                .ConfigureAwait(false);
            Assert.NotNull(result.Data);
            Assert.False(string.IsNullOrEmpty(result.Data.Message));
            Assert.Contains("successful", result.Data.Message);
        }

        [Fact]
        public async void LiquidateInvestment_ReturnsLiquidatedResponse()
        {
            var bootstrap = await BootstrapTest($"/api/v1/investments/{investmentId}/liquidate", Method.POST);
            bootstrap.Request.AddParameter("units", "10", ParameterType.GetOrPost);
            var result = await bootstrap.Client
                .ExecuteAsync<InvestmentLiquidatedDto>(bootstrap.Request)
                .ConfigureAwait(false);
            Assert.NotNull(result.Data);
            Assert.Equal(result.Data.Data.InvestmentId, investmentId);
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
    }
}