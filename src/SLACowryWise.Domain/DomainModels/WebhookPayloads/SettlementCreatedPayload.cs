using SLACowryWise.Domain.Services;
using System;
using System.Text.Json.Serialization;

namespace SLACowryWise.Domain.DomainModels.WebhookPayloads
{
    [BsonCollection("SettlementCreatedWebhookPayload")]
    public class SettlementCreatedWebhookPayload
    {
        [JsonPropertyName("event")] public SettlementCreatedEvent Event { get; set; }

        [JsonPropertyName("data")] public SettlementCreatedEventPayloadData Data { get; set; }

        public class SettlementCreatedEvent
        {
            [JsonPropertyName("id")] public string Id { get; set; }

            [JsonPropertyName("event")] public string EventName { get; set; }

            [JsonPropertyName("target")] public string Target { get; set; }

            [JsonPropertyName("signature")] public string Signature { get; set; }
        }

        public class Amount
        {
            [JsonPropertyName("value")] public string Value { get; set; }

            [JsonPropertyName("currency_code")] public string CurrencyCode { get; set; }
        }

        public class SourceAsset
        {
            [JsonPropertyName("id")] public string Id { get; set; }

            [JsonPropertyName("account_id")] public string AccountId { get; set; }

            [JsonPropertyName("account_name")] public string AccountName { get; set; }

            [JsonPropertyName("account_email")] public string AccountEmail { get; set; }

            [JsonPropertyName("product_code")] public string ProductCode { get; set; }

            [JsonPropertyName("asset_type")] public string AssetType { get; set; }
        }

        public class DestinationAsset
        {
            [JsonPropertyName("id")] public string Id { get; set; }

            [JsonPropertyName("account_id")] public string AccountId { get; set; }

            [JsonPropertyName("account_name")] public string AccountName { get; set; }

            [JsonPropertyName("account_email")] public string AccountEmail { get; set; }

            [JsonPropertyName("product_code")] public string ProductCode { get; set; }

            [JsonPropertyName("asset_type")] public string AssetType { get; set; }
        }

        public class SettlementCreatedEventPayloadData
        {
            [JsonPropertyName("id")] public string Id { get; set; }

            [JsonPropertyName("amount")] public Amount Amount { get; set; }

            [JsonPropertyName("reference")] public string Reference { get; set; }

            [JsonPropertyName("description")] public string Description { get; set; }

            [JsonPropertyName("source_asset")] public SourceAsset SourceAsset { get; set; }

            [JsonPropertyName("destination_asset")]
            public DestinationAsset DestinationAsset { get; set; }

            [JsonPropertyName("status")] public string Status { get; set; }

            [JsonPropertyName("fee")] public int Fee { get; set; }

            [JsonPropertyName("transaction_date")] public DateTime TransactionDate { get; set; }
        }
    }
}