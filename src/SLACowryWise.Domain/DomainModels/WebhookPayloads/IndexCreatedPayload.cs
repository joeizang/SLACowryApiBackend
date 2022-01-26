using SLACowryWise.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SLACowryWise.Domain.DomainModels.WebhookPayloads
{
    [BsonCollection("IndexCreatedUpdatedWebhookPayload")]
    public partial class IndexCreatedUpdatedWebhookPayload
    {
        [JsonPropertyName("event")] public IndexCreatedEvent Event { get; set; }

        [JsonPropertyName("data")] public IndexCreatedPayloadData Data { get; set; }

    }

    public class IndexCreatedEvent
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("event")]
        public string EventName { get; set; }

        [JsonPropertyName("target")]
        public string Target { get; set; }

        [JsonPropertyName("signature")]
        public string Signature { get; set; }
    }

    public class IndexCreatedAllocation
    {
        [JsonPropertyName("asset_id")] public string AssetId { get; set; }

        [JsonPropertyName("asset_name")] public string AssetName { get; set; }

        [JsonPropertyName("asset_code")] public string AssetCode { get; set; }

        [JsonPropertyName("weight")] public int Weight { get; set; }
    }

    public class IndexCreatedPayloadData
    {
        [JsonPropertyName("index_id")] public string IndexId { get; set; }

        [JsonPropertyName("account_id")] public string AccountId { get; set; }

        [JsonPropertyName("is_user_created")] public bool IsUserCreated { get; set; }

        [JsonPropertyName("asset_code")] public string AssetCode { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("description")] public string Description { get; set; }

        [JsonPropertyName("asset_type")] public string AssetType { get; set; }

        [JsonPropertyName("asset_class")] public string AssetClass { get; set; }

        [JsonPropertyName("created_on")] public DateTime CreatedOn { get; set; }

        [JsonPropertyName("allocations")] public List<IndexCreatedAllocation> Allocations { get; set; }

        [JsonPropertyName("index_type")] public string IndexType { get; set; }

        [JsonPropertyName("country")] public string Country { get; set; }
    }
}