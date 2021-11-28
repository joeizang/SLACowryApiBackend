using System;
using System.Threading.Tasks;
using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Wallets;

namespace SLACowryWise.Domain.Services
{
    public class WalletService : IWalletService
    {
        private readonly IHttpService _service;

        public WalletService(IHttpService service)
        {
            _service = service;
        }
        public async Task<WalletPaginatedDtoRoot> GetAllWallets(string page = "1", string pageSize = "10")
        {
                IRestRequest request = new RestRequest("/api/v1/wallets", Method.GET);
                request.AddParameter("page", page);
                request.AddParameter("page_count", pageSize);
                var client = await _service.InitializeClient().ConfigureAwait(false);
                var result = await client.ExecuteAsync<WalletPaginatedDtoRoot>(request)
                    .ConfigureAwait(false);
                return result.Data;
        }

        public async Task<CreateWalletResponseDto> CreateWallet(CreateWalletInputModel inputModel)
        {
                IRestRequest request = new RestRequest("/api/v1/wallets", Method.POST);
                request.AddParameter("account_id", inputModel.AccountId, ParameterType.GetOrPost);
                request.AddParameter("currency_code", inputModel.CurrencyCode, ParameterType.GetOrPost);
                var client = await _service.InitializeClient().ConfigureAwait(false);
                var result = await client.ExecuteAsync<CreateWalletResponseDto>(request)
                    .ConfigureAwait(false);
                return result.Data;
        }

        public async Task<SingleWalletResponse> GetAWallet(string walletId)
        {
                IRestRequest request = new RestRequest($"/api/v1/wallets/{walletId}", Method.GET);
                var client = await _service.InitializeClient().ConfigureAwait(false);
                var result = await client.ExecuteAsync<SingleWalletResponse>(request)
                    .ConfigureAwait(false);
                return result.Data;
        }

        public async Task<WalletTransferDtoRoot> TransferFundsFromWallet(WalletTransferInputModel inputModel)
        {
                IRestRequest request = new RestRequest($"/api/v1/wallets/{inputModel.AccountId}", Method.POST);
                request.AddParameter("product_code", inputModel.ProductCode, ParameterType.GetOrPost);
                request.AddParameter("amount", inputModel.Amount, ParameterType.GetOrPost);
                var client = await _service.InitializeClient().ConfigureAwait(false);
                var result = await client.ExecuteAsync<WalletTransferDtoRoot>(request)
                    .ConfigureAwait(false);
                return result.Data;

        }
    }
}