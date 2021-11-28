using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SLACowryWise.Domain.DTOs.Stocks
{
    public class StockAssetsPayload
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("class")]
        public string Class { get; set; }

        [JsonPropertyName("exchange")]
        public string Exchange { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("tradable")]
        public bool Tradable { get; set; }

        [JsonPropertyName("marginable")]
        public bool Marginable { get; set; }

        [JsonPropertyName("shortable")]
        public bool Shortable { get; set; }

        [JsonPropertyName("easy_to_borrow")]
        public bool EasyToBorrow { get; set; }

        [JsonPropertyName("fractionable")]
        public bool Fractionable { get; set; }
    }

    public class StockAssetsResponse
    {
        [JsonPropertyName("data")]
        public List<StockAssetsPayload> Data { get; set; }
    }
    
    public class BuyStockInputModel
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("time_in_force")]
        public string TimeInForce { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }
    }
    
    public class SellStockInputModel
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("side")]
        public string Side { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("time_in_force")]
        public string TimeInForce { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }
    }
    
    public class UserStockProfileResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("buying_power")]
        public string BuyingPower { get; set; }

        [JsonPropertyName("regt_buying_power")]
        public string RegtBuyingPower { get; set; }

        [JsonPropertyName("daytrading_buying_power")]
        public string DaytradingBuyingPower { get; set; }

        [JsonPropertyName("cash")]
        public string Cash { get; set; }

        [JsonPropertyName("cash_withdrawable")]
        public string CashWithdrawable { get; set; }

        [JsonPropertyName("cash_transferable")]
        public string CashTransferable { get; set; }

        [JsonPropertyName("pending_transfer_out")]
        public string PendingTransferOut { get; set; }

        [JsonPropertyName("portfolio_value")]
        public string PortfolioValue { get; set; }

        [JsonPropertyName("pattern_day_trader")]
        public bool PatternDayTrader { get; set; }

        [JsonPropertyName("trading_blocked")]
        public bool TradingBlocked { get; set; }

        [JsonPropertyName("transfers_blocked")]
        public bool TransfersBlocked { get; set; }

        [JsonPropertyName("account_blocked")]
        public bool AccountBlocked { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("trade_suspended_by_user")]
        public bool TradeSuspendedByUser { get; set; }

        [JsonPropertyName("multiplier")]
        public string Multiplier { get; set; }

        [JsonPropertyName("shorting_enabled")]
        public bool ShortingEnabled { get; set; }

        [JsonPropertyName("equity")]
        public string Equity { get; set; }

        [JsonPropertyName("last_equity")]
        public string LastEquity { get; set; }

        [JsonPropertyName("long_market_value")]
        public string LongMarketValue { get; set; }

        [JsonPropertyName("short_market_value")]
        public string ShortMarketValue { get; set; }

        [JsonPropertyName("initial_margin")]
        public string InitialMargin { get; set; }

        [JsonPropertyName("maintenance_margin")]
        public string MaintenanceMargin { get; set; }

        [JsonPropertyName("last_maintenance_margin")]
        public string LastMaintenanceMargin { get; set; }

        [JsonPropertyName("sma")]
        public string Sma { get; set; }

        [JsonPropertyName("daytrade_count")]
        public int DaytradeCount { get; set; }

        [JsonPropertyName("previous_close")]
        public DateTime PreviousClose { get; set; }

        [JsonPropertyName("last_long_market_value")]
        public string LastLongMarketValue { get; set; }

        [JsonPropertyName("last_short_market_value")]
        public string LastShortMarketValue { get; set; }

        [JsonPropertyName("last_cash")]
        public string LastCash { get; set; }

        [JsonPropertyName("last_initial_margin")]
        public string LastInitialMargin { get; set; }

        [JsonPropertyName("last_regt_buying_power")]
        public string LastRegtBuyingPower { get; set; }

        [JsonPropertyName("last_daytrading_buying_power")]
        public string LastDaytradingBuyingPower { get; set; }

        [JsonPropertyName("last_buying_power")]
        public string LastBuyingPower { get; set; }

        [JsonPropertyName("last_daytrade_count")]
        public int LastDaytradeCount { get; set; }

        [JsonPropertyName("clearing_broker")]
        public string ClearingBroker { get; set; }
    }
    
    
}