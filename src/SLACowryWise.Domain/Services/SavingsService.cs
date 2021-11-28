using System;
using System.Threading.Tasks;
using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Savings;
using SLACowryWise.Domain.DTOs.Wallets;

namespace SLACowryWise.Domain.Services
{
    public class SavingsService : ISavingsService
    {
        private readonly IHttpService _service;

        public SavingsService(IHttpService service)
        {
            _service = service;
        }
        public async Task<SavingsPaginatedResponseDto> GetAllSavings()
        {
            IRestRequest request = new RestRequest("/api/v1/savings", Method.GET);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<SavingsPaginatedResponseDto>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<SavingsCreatedResponseDto> CreateSavings(CreateSavingsInputModel inputModel)
        {
            IRestRequest request = new RestRequest("/api/v1/savings", Method.POST);
             
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<SavingsCreatedResponseDto>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<SingleSavingsByIdResponseDto> GetSingleSavings(string savingsId)
        {
            IRestRequest request = new RestRequest($"/api/v1/savings/{savingsId}", Method.GET);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<SingleSavingsByIdResponseDto>(request).ConfigureAwait(
                false);
            return result.Data;
        }
        
        public async Task<FundSavingsDtoResponse> FundSavingsFromWallet(WalletTransferInputModel inputModel)
        {
            var request = new RestRequest($"/api/v1/wallets/{inputModel.AccountId}/transfer", Method.POST);
            request.AddParameter("product_code", inputModel.ProductCode, ParameterType.GetOrPost);
            request.AddParameter("amount", inputModel.Amount, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<FundSavingsDtoResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<SavingsRateDtoResponse> GetSavingsRate(string days)
        {
            var request = new RestRequest($"/api/v1/savings/rates", Method.POST);
            request.AddParameter("days", days, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<SavingsRateDtoResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<WithdrawFromSavingsDto> WithdrawFromSavings(WithdrawFromSavingsInputModel inputModel)
        {
            var request = new RestRequest($"/api/v1/savings/{inputModel.SavingsId}/withdraw", Method.POST);
            request.AddParameter("amount", inputModel.Amount, ParameterType.GetOrPost);
            request.AddParameter("product_code", inputModel.ProductCode, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync(request).ConfigureAwait(false);
            var withdrawalStatus = new WithdrawFromSavingsDto
            {
                Successful = result.IsSuccessful
            };
            return withdrawalStatus;
        }
    }
}