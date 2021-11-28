using System.Threading.Tasks;
using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Transactions;

namespace SLACowryWise.Domain.Services
{
    public class TransactionsService : ITransactionService
    {
        private readonly IHttpService _service;

        public TransactionsService(IHttpService service)
        {
            _service = service;
        }
        public async Task<GetDepositResponse> GetSingleDeposit(string id)
        {
            IRestRequest request = new RestRequest($"/api/v1/deposits/{id}", Method.GET);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<GetDepositResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<GetWithdrawalResponse> GetSingleWithdrawal(string id)
        {
            IRestRequest request = new RestRequest($"/api/v1/withdrawals/{id}", Method.GET);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<GetWithdrawalResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<SingleTransferResponse> GetSingleTransfer(string id)
        {
            IRestRequest request = new RestRequest($"/api/v1/transfers/{id}", Method.GET);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<SingleTransferResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<GetTransactionsPaginatedResponse> GetAllTransfers(GetAllTransfersInputModel inputModel)
        {
            IRestRequest request = new RestRequest("/api/v1/settlements", Method.GET);
            request.AddParameter("account_id", inputModel.AccountId, ParameterType.GetOrPost);
            request.AddParameter("transfer_type", inputModel.TransferType, ParameterType.GetOrPost);
            request.AddParameter("from_date", inputModel.FromDate, ParameterType.GetOrPost);
            request.AddParameter("to_date", inputModel.ToDate, ParameterType.GetOrPost);
            request.AddParameter("status", inputModel.Status, ParameterType.GetOrPost);
            request.AddParameter("asset_type", inputModel.AssetType, ParameterType.GetOrPost);
            request.AddParameter("currency", inputModel.Currency, ParameterType.GetOrPost);
            request.AddParameter("email", inputModel.Email, ParameterType.GetOrPost);
            request.AddParameter("page", inputModel.Page, ParameterType.GetOrPost);
            request.AddParameter("page_size", inputModel.PageSize, ParameterType.GetOrPost);

            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client
                .ExecuteAsync<GetTransactionsPaginatedResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<GetDepositsPaginatedResponse> GetAllDeposits(GetPaginatedResponseInputModel inputModel)
        {
            IRestRequest request = new RestRequest("/api/v1/deposits", Method.POST);
            request.AddParameter("page", inputModel.Page, ParameterType.GetOrPost);
            request.AddParameter("page_size", inputModel.PageSize, ParameterType.GetOrPost);

            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<GetDepositsPaginatedResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<GetAllWithdrawalsPaginatedResponse> GetAllWithdrawals(GetPaginatedResponseInputModel inputModel)
        {
            IRestRequest request = new RestRequest("/api/v1/withdrawals", Method.POST);
            request.AddParameter("page", inputModel.Page, ParameterType.GetOrPost);
            request.AddParameter("page_size", inputModel.PageSize, ParameterType.GetOrPost);

            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client
                .ExecuteAsync<GetAllWithdrawalsPaginatedResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }
    }
}