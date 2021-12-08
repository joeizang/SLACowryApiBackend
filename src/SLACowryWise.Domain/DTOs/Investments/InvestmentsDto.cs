using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SLACowryWise.Domain.DTOs.Investments
{
    public class InvestmentActionPayload
    {
        [JsonPropertyName("investment_id")]
        public string InvestmentId { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName("asset_type")]
        public string AssetType { get; set; }

        [JsonPropertyName("asset_in_index")]
        public bool AssetInIndex { get; set; }

        [JsonPropertyName("index_id")]
        public object IndexId { get; set; }

        [JsonPropertyName("current_units")]
        public string CurrentUnits { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("current_value")]
        public string CurrentValue { get; set; }

        [JsonPropertyName("investment_returns")]
        public string InvestmentReturns { get; set; }

        [JsonPropertyName("change_today")]
        public string ChangeToday { get; set; }

        [JsonPropertyName("created_on")]
        public DateTime CreatedOn { get; set; }

        [JsonPropertyName("pending_deposits")]
        public List<PendingDeposit> PendingDeposits { get; set; }

        [JsonPropertyName("pending_sales")]
        public List<PendingSale> PendingSales { get; set; }
    }

    public class InvestmentPaginatedResponseInput : GetPaginatedResponseInputModel
    {
        [JsonPropertyName("asset_type")]
        public string AssetType { get; set; }
    }

    public class InvestmentPaginatedResponse
    {
        public ModelPagination Pagination { get; set; }

        public List<InvestmentActionPayload> Data { get; set; }

        [JsonPropertyName("errors")]
        public object Errors { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    public class SingleInvestmentResponseDto : DtoBase
    {
        public InvestmentActionPayload Data { get; set; }
    }

    public class CreateInvestmentInputModel
    {
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("asset_code")]
        public string AssetCode { get; set; }

        [JsonPropertyName("customer_Id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("sla_product_type")]
        public int ProductType { get; set; }
    }

    public class PendingDeposit
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("transaction_date")]
        public DateTime TransactionDate { get; set; }
    }

    public class PendingSale
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("units")]
        public double Units { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("created_on")]
        public DateTime CreatedOn { get; set; }
    }

    public class InvestmentLiquidatedPayload
    {
        [JsonPropertyName("investment_id")]
        public string InvestmentId { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName("asset_type")]
        public string AssetType { get; set; }

        [JsonPropertyName("asset_in_index")]
        public bool AssetInIndex { get; set; }

        [JsonPropertyName("index_id")]
        public object IndexId { get; set; }

        [JsonPropertyName("current_units")]
        public string CurrentUnits { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("current_value")]
        public string CurrentValue { get; set; }

        [JsonPropertyName("investment_returns")]
        public string InvestmentReturns { get; set; }

        [JsonPropertyName("change_today")]
        public string ChangeToday { get; set; }

        [JsonPropertyName("created_on")]
        public DateTime CreatedOn { get; set; }

        [JsonPropertyName("pending_deposits")]
        public List<PendingDeposit> PendingDeposits { get; set; }

        [JsonPropertyName("pending_sales")]
        public List<PendingSale> PendingSales { get; set; }
    }

    public class InvestmentLiquidatedDto : DtoBase
    {
        [JsonPropertyName("data")]
        public InvestmentLiquidatedPayload Data { get; set; }
    }

    public class InvestmentPagination
    {
        [JsonPropertyName("next")]
        public object Next { get; set; }

        [JsonPropertyName("previous")]
        public object Previous { get; set; }

        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }

    public class InvestmentDatumPayload
    {
        [JsonPropertyName("investment_id")]
        public string InvestmentId { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName("asset_type")]
        public string AssetType { get; set; }

        [JsonPropertyName("asset_in_index")]
        public bool AssetInIndex { get; set; }

        [JsonPropertyName("index_id")]
        public object IndexId { get; set; }

        [JsonPropertyName("current_units")]
        public string CurrentUnits { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("current_value")]
        public string CurrentValue { get; set; }

        [JsonPropertyName("investment_returns")]
        public string InvestmentReturns { get; set; }

        [JsonPropertyName("change_today")]
        public string ChangeToday { get; set; }

        [JsonPropertyName("created_on")]
        public DateTime CreatedOn { get; set; }

        [JsonPropertyName("pending_deposits")]
        public List<object> PendingDeposits { get; set; }

        [JsonPropertyName("pending_sales")]
        public List<object> PendingSales { get; set; }
    }

    public class InvestmentPaginatedDtoResponse
    {
        [JsonPropertyName("pagination")]
        public InvestmentPagination Pagination { get; set; }

        [JsonPropertyName("data")]
        public List<InvestmentDatumPayload> Data { get; set; }

        [JsonPropertyName("errors")]
        public object Errors { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}