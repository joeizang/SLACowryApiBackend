using MediatR;
using SLACowryWise.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SLACowryWise.Domain.DomainModels.WebhookPayloads
{
    public class InvestmentCreatedPayload : IWebhookPayload
    {
        [JsonPropertyName("event")] public InvestmentCreatedEvent InvestmentCreatedEvent { get; set; }

        [JsonPropertyName("data")] public InvestmentCreatedPayloadData Data { get; set; }

        
    }

    public class InvestmentCreatedEvent
    {
        [JsonPropertyName("id")] public string Id { get; set; }

        [JsonPropertyName("event")] public string EventName { get; set; }

        [JsonPropertyName("target")] public string Target { get; set; }

        [JsonPropertyName("signature")] public string Signature { get; set; }
    }

    public class PendingDeposit
    {
        [JsonPropertyName("id")] public string Id { get; set; }

        [JsonPropertyName("amount")] public string Amount { get; set; }

        [JsonPropertyName("reference")] public string Reference { get; set; }

        [JsonPropertyName("transaction_date")] public DateTime TransactionDate { get; set; }
    }

    public class InvestmentCreatedPayloadData
    {
        [JsonPropertyName("investment_id")] public string InvestmentId { get; set; }

        [JsonPropertyName("account_id")] public string AccountId { get; set; }

        [JsonPropertyName("product_code")] public string ProductCode { get; set; }

        [JsonPropertyName("asset_type")] public string AssetType { get; set; }

        [JsonPropertyName("asset_in_index")] public bool AssetInIndex { get; set; }

        [JsonPropertyName("index_id")] public object IndexId { get; set; }

        [JsonPropertyName("current_units")] public string CurrentUnits { get; set; }

        [JsonPropertyName("currency")] public string Currency { get; set; }

        [JsonPropertyName("current_value")] public string CurrentValue { get; set; }

        [JsonPropertyName("investment_returns")]
        public string InvestmentReturns { get; set; }

        [JsonPropertyName("change_today")] public string ChangeToday { get; set; }

        [JsonPropertyName("created_on")] public DateTime CreatedOn { get; set; }

        [JsonPropertyName("pending_deposits")] public List<PendingDeposit> PendingDeposits { get; set; }

        [JsonPropertyName("pending_sales")] public List<object> PendingSales { get; set; }
    }
}