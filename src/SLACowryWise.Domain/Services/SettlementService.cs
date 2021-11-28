using System.Threading.Tasks;
using RestSharp;
using SLACowryWise.Domain.Abstractions;

namespace SLACowryWise.Domain.Services
{
    public class SettlementService : ISettlementService
    {
        private readonly IHttpService _service;

        public SettlementService(IHttpService service)
        {
            _service = service;
        }
        public async Task<SettlementResponseDto> WithdrawToUserBankAccount(SettlementInputModel model)
        {
            IRestRequest request = new RestRequest("/api/v1/settlements", Method.POST);
            request.AddParameter("account_id", model.AccountId, ParameterType.GetOrPost);
            request.AddParameter("amount", model.Amount, ParameterType.GetOrPost);
            request.AddParameter("bank_id", model.BankId, ParameterType.GetOrPost);
            request.AddParameter("description", model.Description, ParameterType.GetOrPost);

            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<SettlementResponseDto>(request)
                .ConfigureAwait(false);
            return result.Data;
        }
    }
}