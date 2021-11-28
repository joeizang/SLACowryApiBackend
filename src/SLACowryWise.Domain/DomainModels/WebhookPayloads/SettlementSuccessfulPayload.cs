using MediatR;
using SLACowryWise.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SLACowryWise.Domain.DomainModels.WebhookPayloads
{
    public class SettlementSuccessfulPayload : IWebhookPayload
    {
        [JsonPropertyName("event")] public SettlementSuccessfulEvent Event { get; set; }

        [JsonPropertyName("data")] public SettlementSuccessfulEventPayloadData Data { get; set; }

        public class SettlementSuccessfulEvent
        {
            [JsonPropertyName("id")] public string Id { get; set; }

            [JsonPropertyName("event")] public string EventName { get; set; }

            [JsonPropertyName("target")] public string Target { get; set; }

            [JsonPropertyName("signature")] public string Signature { get; set; }
        }

        public class PendingSale
        {
            [JsonPropertyName("id")] public string Id { get; set; }

            [JsonPropertyName("units")] public int Units { get; set; }

            [JsonPropertyName("reference")] public string Reference { get; set; }

            [JsonPropertyName("created_on")] public DateTime CreatedOn { get; set; }
        }

        public class SettlementSuccessfulEventPayloadData
        {
            [JsonPropertyName("investment_id")] public string InvestmentId { get; set; }

            [JsonPropertyName("account_id")] public string AccountId { get; set; }

            [JsonPropertyName("name")] public string Name { get; set; }

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

            [JsonPropertyName("pending_deposits")] public List<object> PendingDeposits { get; set; }

            [JsonPropertyName("pending_sales")] public List<PendingSale> PendingSales { get; set; }
        }
    }
}