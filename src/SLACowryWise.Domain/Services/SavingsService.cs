using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Data;
using SLACowryWise.Domain.DomainModels;
using SLACowryWise.Domain.DTOs.Savings;
using SLACowryWise.Domain.DTOs.Wallets;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Services
{
    public class SavingsService : ISavingsService
    {
        private readonly IHttpService _service;
        private readonly ICreateSavings _createSavings;
        private readonly IFundSavings _fundSavings;
        private readonly IWithdrawSavings _withdraw;

        public SavingsService(IHttpService service, ICreateSavings createSavings, IFundSavings fundSavings, IWithdrawSavings withdraw)
        {
            _service = service;
            _createSavings = createSavings;
            _fundSavings = fundSavings;
            _withdraw = withdraw;
        }
        public async Task<SavingsPaginatedResponseDto> GetAllSavings()
        {
            var request = new RestRequest("/api/v1/savings", Method.Get);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<SavingsPaginatedResponseDto>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<SavingsCreatedResponse> CreateSavings(CreateSavingsInputModel inputModel)
        {
            var request = new RestRequest("/api/v1/savings", Method.Post);
            request.AddParameter("account_id", inputModel.AccountId, ParameterType.GetOrPost);
            request.AddParameter("currency_code", inputModel.CurrencyCode, ParameterType.GetOrPost);
            request.AddParameter("days", inputModel.Days, ParameterType.GetOrPost);
            request.AddParameter("interest_enabled", inputModel.InterestEnabled, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<SavingsCreatedResponse>(request)
                .ConfigureAwait(false);
            var created = new CreateSavings
            {
                CreateSavingsResponse = result,
                Response = inputModel
            };
            await _createSavings.CreateOneAsync(created).ConfigureAwait(false);
            return result.Data;
        }

        public async Task<SingleSavingsByIdResponseDto> GetSingleSavings(string savingsId)
        {
            var request = new RestRequest($"/api/v1/savings/{savingsId}", Method.Get);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<SingleSavingsByIdResponseDto>(request).ConfigureAwait(
                false);
            return result.Data;
        }

        public async Task<FundSavingsDtoResponse> FundSavingsFromWallet(WalletTransferInputModel inputModel)
        {
            var request = new RestRequest($"/api/v1/wallets/{inputModel.WalletId}/transfer", Method.Post);
            request.AddParameter("product_code", inputModel.ProductCode, ParameterType.GetOrPost);
            request.AddParameter("amount", inputModel.Amount, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<FundSavingsDtoResponse>(request)
                .ConfigureAwait(false);
            var funded = new FundSavings
            {
                FundSavingsDtoResponse = result,
                Request = inputModel
            };
            await _fundSavings.CreateOneAsync(funded).ConfigureAwait(false);
            return result.Data;
        }

        public async Task<SavingsRateDtoResponse> GetSavingsRate(string days)
        {
            var request = new RestRequest($"/api/v1/savings/rates", Method.Post);
            request.AddParameter("days", days, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<SavingsRateDtoResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<WithdrawFromSavingsDto> WithdrawFromSavings(WithdrawFromSavingsInputModel inputModel)
        {
            var request = new RestRequest($"/api/v1/savings/{inputModel.SavingsId}/withdraw", Method.Post);
            request.AddParameter("amount", inputModel.Amount, ParameterType.GetOrPost);
            request.AddParameter("product_code", inputModel.ProductCode, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync(request).ConfigureAwait(false);
            var withdrawalStatus = new WithdrawFromSavingsDto
            {
                Successful = result.IsSuccessful
            };
            var withdrawn = new WithdrawSavings
            {
                WithdrawFromSavingsDto = result,
                Request = inputModel
            };
            await _withdraw.CreateOneAsync(withdrawn).ConfigureAwait(false);
            return withdrawalStatus;
        }
    }

    public class CreateSavingsService : MongodbPersistenceService<CreateSavings>, ICreateSavings
    {
        public CreateSavingsService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class FundSavingsService : MongodbPersistenceService<FundSavings>, IFundSavings
    {
        public FundSavingsService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class WithdrawSavingsService : MongodbPersistenceService<WithdrawSavings>, IWithdrawSavings
    {
        public WithdrawSavingsService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }
}