using System.Threading.Tasks;
using SLACowryWise.Domain.DTOs.Stocks;

namespace SLACowryWise.Domain.Abstractions
{
    public interface ITradeStockService
    {
        Task<object> GetStockOrders(string account_id, string status);

        Task<StockAssetsResponse> GetStocks();

        Task<object> BuyStock(BuyStockInputModel inputModel);

        Task<object> SellStock(SellStockInputModel inputModel);

        Task<UserStockProfileResponse> GetUserStockProfile(string accountId);

        Task<object> GetStockPositions(string accountId);

        Task<object> GetSingleStockPosition(string accountId);
    }
}