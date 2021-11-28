using System.Threading.Tasks;
using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Investments;
using SLACowryWise.Domain.DTOs.Wallets;

namespace SLACowryWise.Domain.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IHttpService _service;

        public InvestmentService(IHttpService service)
        {
            _service = service;
        }
        public async Task<SingleInvestmentResponseDto> CreateInvestment(CreateInvestmentInputModel inputModel)
        {
            var request = new RestRequest("/api/v1/investments", Method.POST);
            request.AddParameter("account_id", inputModel.AccountId, ParameterType.GetOrPost);
            request.AddParameter("asset_code", inputModel.AssetCode, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client
                .ExecuteAsync<SingleInvestmentResponseDto>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<InvestmentPaginatedDtoResponse> GetAllInvestments(InvestmentPaginatedResponseInput inputModel)
        {
            var request = new RestRequest("/api/v1/investments", Method.GET);
            request.AddParameter("asset_type", inputModel.AssetType, ParameterType.GetOrPost);
            request.AddParameter("page", inputModel.Page, ParameterType.GetOrPost);
            request.AddParameter("page_size", inputModel.PageSize, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client
                .ExecuteAsync<InvestmentPaginatedDtoResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<TransferFromWalletResponseDto> FundInvestment(WalletTransferInputModel inputModel)
        {
            var request = new RestRequest($"/api/v1/investments/{inputModel.AccountId}/transfer", Method.POST);
            request.AddParameter("product_code", inputModel.ProductCode, ParameterType.GetOrPost);
            request.AddParameter("amount", inputModel.Amount, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client
                .ExecuteAsync<TransferFromWalletResponseDto>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<InvestmentLiquidatedDto> LiquidateInvestment(string units, string investmentId)
        {
            var request = new RestRequest($"/api/v1/investments/{investmentId}/liquidate", Method.POST);
            request.AddParameter("units", units, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client
                .ExecuteAsync<InvestmentLiquidatedDto>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<SingleInvestmentResponseDto> GetSingleInvestment(string investmentId)
        {
            var request = new RestRequest($"/api/v1/investments/{investmentId}", Method.GET);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client
                .ExecuteAsync<SingleInvestmentResponseDto>(request)
                .ConfigureAwait(false);
            return result.Data;
        }
    }
}