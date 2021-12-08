using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Data;
using SLACowryWise.Domain.DomainModels;
using SLACowryWise.Domain.DTOs.Wallets;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Services
{
    public class WalletService : IWalletService
    {
        private readonly IHttpService _service;
        private readonly ICreateWallet _createWallet;
        private readonly IFundsWalletTransfer _walletTransfer;

        public WalletService(IHttpService service, ICreateWallet createWallet, IFundsWalletTransfer walletTransfer)
        {
            _service = service;
            _createWallet = createWallet;
            _walletTransfer = walletTransfer;
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
            var created = new CreateWallet
            {
                CreateWalletResponseDto = result.Data,
                AccountId = inputModel.AccountId,
                CustomerId = inputModel.CustomerId
            };
            await _createWallet.CreateOneAsync(created).ConfigureAwait(false);
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
            var transferred = new FundsWalletTransfer
            {
                TransferFundsFromWallet = result.Data,
                AccountId = inputModel.AccountId,
                CustomerId = inputModel.CustomerId
            };
            await _walletTransfer.CreateOneAsync(transferred).ConfigureAwait(false);
            return result.Data;

        }
    }

    public class CreateWalletService : MongodbPersistenceService<CreateWallet>, ICreateWallet
    {
        public CreateWalletService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }

    public class FundsWalletTransferService : MongodbPersistenceService<FundsWalletTransfer>, IFundsWalletTransfer
    {
        public FundsWalletTransferService(IMongoDatabaseSettings settings) : base(settings)
        {
        }
    }
}