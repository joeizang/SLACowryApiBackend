using System.Threading.Tasks;
using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Stocks;
using SLACowryWise.Domain.DTOs.Transactions;

namespace SLACowryWise.Domain.Services
{
    public class TradeStockService : ITradeStockService
    {
        private readonly IHttpService _service;

        public TradeStockService(IHttpService service)
        {
            _service = service;
        }
        public async Task<object> GetStockOrders(string account_id, string status)
        {
            IRestRequest request = new RestRequest($"/api/v1/orders", Method.POST);
            request.AddParameter("account_id", account_id, ParameterType.GetOrPost);
            request.AddParameter("status", status, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<object>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<StockAssetsResponse> GetStocks()
        {
            IRestRequest request = new RestRequest($"/api/v1/stocks/assets", Method.GET);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<StockAssetsResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<object> BuyStock(BuyStockInputModel inputModel)
        {
            IRestRequest request = new RestRequest($"/api/v1/stocks/buy", Method.POST);
            request.AddParameter("symbol", inputModel.Symbol, ParameterType.GetOrPost);
            request.AddParameter("amount", inputModel.Amount, ParameterType.GetOrPost);
            request.AddParameter("side", inputModel.Side, ParameterType.GetOrPost);
            request.AddParameter("type", inputModel.Type, ParameterType.GetOrPost);
            request.AddParameter("time_in_force", inputModel.TimeInForce, ParameterType.GetOrPost);
            request.AddParameter("account_id", inputModel.AccountId, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<object>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<object> SellStock(SellStockInputModel inputModel)
        {
            IRestRequest request = new RestRequest($"/api/v1/stocks/sell", Method.POST);
            request.AddParameter("symbol", inputModel.Symbol, ParameterType.GetOrPost);
            request.AddParameter("amount", inputModel.Amount, ParameterType.GetOrPost);
            request.AddParameter("side", inputModel.Side, ParameterType.GetOrPost);
            request.AddParameter("type", inputModel.Type, ParameterType.GetOrPost);
            request.AddParameter("time_in_force", inputModel.TimeInForce, ParameterType.GetOrPost);
            request.AddParameter("account_id", inputModel.AccountId, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<object>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<UserStockProfileResponse> GetUserStockProfile(string accountId)
        {
            IRestRequest request = new RestRequest($"/api/v1/stocks/profile", Method.GET);
            request.AddParameter("account_id", accountId, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<UserStockProfileResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<object> GetStockPositions(string accountId)
        {
            IRestRequest request = new RestRequest($"/api/v1/stocks/positions", Method.GET);
            request.AddParameter("account_id", accountId, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<object>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<object> GetSingleStockPosition(string accountId)
        {
            IRestRequest request = new RestRequest($"/api/v1/stocks/positions/GFI", Method.GET);
            request.AddParameter("account_id", accountId, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<object>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<object> CloseStockPositions(string accountId)
        {
            IRestRequest request = new RestRequest($"/api/v1/stocks/GFI/positions", Method.GET);
            request.AddParameter("account_id", accountId, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<object>(request)
                .ConfigureAwait(false);
            return result.Data;
        }
    }
}