using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Data;
using SLACowryWise.Domain.DomainModels;
using SLACowryWise.Domain.DTOs.Investments;
using SLACowryWise.Domain.DTOs.Wallets;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IHttpService _service;
        private readonly ICreateInvestment _createInvestment;
        private readonly IInvestmentFunded _investmentFunded;
        private readonly ILiquidateInvestment _liquidateInvestment;

        public InvestmentService(IHttpService service,
            ICreateInvestment createInvestment,
            IInvestmentFunded investmentFunded,
            ILiquidateInvestment liquidateInvestment)
        {
            _service = service;
            _createInvestment = createInvestment;
            _investmentFunded = investmentFunded;
            _liquidateInvestment = liquidateInvestment;
        }

        public async Task<SingleInvestmentResponseDto> CreateInvestment(CreateInvestmentInputModel inputModel)
        {
            var request = new RestRequest("/api/v1/investments", Method.Post);
            request.AddParameter("account_id", inputModel.AccountId, ParameterType.GetOrPost);
            request.AddParameter("asset_code", inputModel.AssetCode, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client
                .ExecuteAsync<SingleInvestmentResponseDto>(request)
                .ConfigureAwait(false);
            var created = new CreateInvestment
            {
                SingleInvestmentResponseDto = result.Data,
                AccountId = inputModel.AccountId,
                CustomerId = inputModel.CustomerId,
            };
            await _createInvestment.CreateOneAsync(created).ConfigureAwait(false);
            return result.Data;
        }

        public async Task<InvestmentPaginatedDtoResponse> GetAllInvestments(InvestmentPaginatedResponseInput inputModel)
        {
            var request = new RestRequest("/api/v1/investments", Method.Get);
            if (inputModel is not null && string.IsNullOrEmpty(inputModel.Page) && string.IsNullOrEmpty(inputModel.PageSize)
                && string.IsNullOrEmpty(inputModel.AssetType))
            {
                var clientHttp = await _service.InitializeClient().ConfigureAwait(false);
                var resultPayload = await clientHttp
                    .ExecuteAsync<InvestmentPaginatedDtoResponse>(request)
                    .ConfigureAwait(false);
                return resultPayload.Data;
            }
            //request.AddParameter("asset_type", inputModel.AssetType, ParameterType.GetOrPost);
            //request.AddParameter("page", inputModel.Page, ParameterType.GetOrPost);
            request.AddParameter("page_size", inputModel.PageSize, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client
                .ExecuteAsync<InvestmentPaginatedDtoResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<TransferFromWalletResponseDto> FundInvestment(WalletTransferInputModel inputModel)
        {
            var request = new RestRequest($"/api/v1/investments/{inputModel.AccountId}/transfer", Method.Post);
            request.AddParameter("product_code", inputModel.ProductCode, ParameterType.GetOrPost);
            request.AddParameter("amount", inputModel.Amount, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client
                .ExecuteAsync<TransferFromWalletResponseDto>(request)
                .ConfigureAwait(false);
            var funded = new InvestmentsFunded
            {
                FundedInvestmentDto = result.Data,
                AccountId = inputModel.AccountId,
                CustomerId = inputModel.CustomerId,
            };
            await _investmentFunded.CreateOneAsync(funded).ConfigureAwait(false);
            return result.Data;
        }

        public async Task<InvestmentLiquidatedDto> LiquidateInvestment(string units, string investmentId, string accountId, string customerId)
        {
            var request = new RestRequest($"/api/v1/investments/{investmentId}/liquidate", Method.Post);
            request.AddParameter("units", units, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client
                .ExecuteAsync<InvestmentLiquidatedDto>(request)
                .ConfigureAwait(false);
            var liquidated = new InvestmentLiquidation
            {
                InvestmentLiquidatedDto = result.Data,
                AccountId = accountId,
                CustomerId = customerId,
            };
            await _liquidateInvestment.CreateOneAsync(liquidated).ConfigureAwait(false);
            return result.Data;
        }

        public async Task<SingleInvestmentResponseDto> GetSingleInvestment(string investmentId)
        {
            var request = new RestRequest($"/api/v1/investments/{investmentId}", Method.Post);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client
                .ExecuteAsync<SingleInvestmentResponseDto>(request)
                .ConfigureAwait(false);
            return result.Data;
        }
    }

    public class InvestmentCreatedService : MongodbPersistenceService<CreateInvestment>, ICreateInvestment
    {
        public InvestmentCreatedService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class LiquidateInvestmentService : MongodbPersistenceService<InvestmentLiquidation>, ILiquidateInvestment
    {
        public LiquidateInvestmentService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class InvestmentFundedService : MongodbPersistenceService<InvestmentsFunded>, IInvestmentFunded
    {
        public InvestmentFundedService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }
}