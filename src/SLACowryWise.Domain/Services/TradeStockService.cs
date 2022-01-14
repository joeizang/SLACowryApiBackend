using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Stocks;
using System.Threading.Tasks;

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
            var request = new RestRequest($"/api/v1/orders", Method.Post);
            request.AddParameter("account_id", account_id, ParameterType.GetOrPost);
            request.AddParameter("status", status, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<object>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<StockAssetsResponse> GetStocks()
        {
            var request = new RestRequest($"/api/v1/stocks/assets", Method.Get);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<StockAssetsResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<object> BuyStock(BuyStockInputModel inputModel)
        {
            var request = new RestRequest($"/api/v1/stocks/buy", Method.Post);
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
            var request = new RestRequest($"/api/v1/stocks/sell", Method.Post);
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
            var request = new RestRequest($"/api/v1/stocks/profile", Method.Get);
            request.AddParameter("account_id", accountId, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<UserStockProfileResponse>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<object> GetStockPositions(string accountId)
        {
            var request = new RestRequest($"/api/v1/stocks/positions", Method.Get);
            request.AddParameter("account_id", accountId, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<object>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<object> GetSingleStockPosition(string accountId)
        {
            var request = new RestRequest($"/api/v1/stocks/positions/GFI", Method.Get);
            request.AddParameter("account_id", accountId, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<object>(request)
                .ConfigureAwait(false);
            return result.Data;
        }

        public async Task<object> CloseStockPositions(string accountId)
        {
            var request = new RestRequest($"/api/v1/stocks/GFI/positions", Method.Get);
            request.AddParameter("account_id", accountId, ParameterType.GetOrPost);
            var client = await _service.InitializeClient().ConfigureAwait(false);
            var result = await client.ExecuteAsync<object>(request)
                .ConfigureAwait(false);
            return result.Data;
        }
    }
}