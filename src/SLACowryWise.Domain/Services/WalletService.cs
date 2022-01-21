using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.Data;
using SLACowryWise.Domain.DomainModels;
using SLACowryWise.Domain.DTOs.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<WalletPaginatedDtoRoot> GetAllWallets(GetPaginatedResponseInputModel inputModel)
        {
            var request = new RestRequest("/api/v1/wallets", Method.Get);
            request.AddParameter("page", inputModel.Page, ParameterType.GetOrPost);
            request.AddParameter("page_count", inputModel.PageSize, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<WalletPaginatedDtoRoot>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<CreateWalletResponseDto> CreateWallet(CreateWalletInputModel inputModel)
        {
            var request = new RestRequest("/api/v1/wallets", Method.Post);
            request.AddParameter("account_id", inputModel.AccountId, ParameterType.GetOrPost);
            request.AddParameter("currency_code", inputModel.CurrencyCode, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<CreateWalletResponseDto>(request)
                .ConfigureAwait(false);
            var created = new CreateWallet
            {
                CreateWalletResponseDto = result,
                Response = inputModel
            };
            await _createWallet.CreateOneAsync(created).ConfigureAwait(false);
            return result.Data;
        }

        public async Task<SingleWalletResponse> GetAWallet(string walletId)
        {
            var request = new RestRequest($"/api/v1/wallets/{walletId}", Method.Get);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<SingleWalletResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<WalletTransferDtoRoot> TransferFundsFromWallet(WalletTransferInputModel inputModel)
        {
            var request = new RestRequest($"/api/v1/wallets/{inputModel.WalletId}/transfer", Method.Post);
            request.AddParameter("product_code", inputModel.ProductCode, ParameterType.GetOrPost);
            request.AddParameter("amount", inputModel.Amount, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<WalletTransferDtoRoot>(request)
                .ConfigureAwait(false);
            var transferred = new FundsWalletTransfer
            {
                TransferFundsFromWallet = result,
                Response = inputModel
            };
            await _walletTransfer.CreateOneAsync(transferred).ConfigureAwait(false);
            return result.Data;

        }

        public async Task<List<string>> ReturnWalletIdsByAccountId(string accountId)
        {
            var paginatedInput = new GetPaginatedResponseInputModel();
            var firstTrip = await FetchWallets(paginatedInput.Page).ConfigureAwait(false);
            WalletPaginatedDtoRoot subsequents;
            List<string> final = new();
            if (firstTrip is null)
                throw new Exception("Cowry has no wallets so something ain't right with them!");
            FilterAndAct(firstTrip.Data, final, accountId);
            var ticker = firstTrip.Pagination.TotalPages;
            for (int i = 1; i < ticker; i++)
            {
                paginatedInput.Page = (int.Parse(paginatedInput.Page) + i).ToString();
                subsequents = await FetchWallets(paginatedInput.Page).ConfigureAwait(false);
                FilterAndAct(subsequents.Data, final, accountId);
            }
            return final;
        }

        public async Task<WalletPaginatedDtoRoot> FetchWallets(string page)
        {
            var paginatedInput = new GetPaginatedResponseInputModel();
            if (!string.IsNullOrEmpty(page))
            {
                paginatedInput.Page = page;
            }
            var fetched = await GetAllWallets(paginatedInput).ConfigureAwait(false);
            return fetched is not null ? fetched : throw new Exception("Nothing fetched!");
        }

        private void FilterAndAct(List<WalletDataPayload> data, List<string> destination, string filter)
        {
            data.Where(w => w.AccountId.Equals(filter)).ToList().ForEach(x => destination.Add(x.WalletId));
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