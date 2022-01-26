using SLACowryWise.Domain.Services;
using System;
using System.Text.Json.Serialization;

namespace SLACowryWise.Domain.DomainModels.WebhookPayloads
{
    [BsonCollection("WalletCreatedCreditedWebhookPayload")]
    public class WalletCreatedCreditedWebhookPayload
    {
        [JsonPropertyName("event")]
        public WalletCreatedEvent Event { get; set; }

        [JsonPropertyName("data")]
        public WalletCreatedEventPayloadData Data { get; set; }
        public class WalletCreatedEvent
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

        public class WalletCreatedEventPayloadData
        {
            [JsonPropertyName("savings_id")]
            public string SavingsId { get; set; }

            [JsonPropertyName("account_id")]
            public string AccountId { get; set; }

            [JsonPropertyName("product_code")]
            public string ProductCode { get; set; }

            [JsonPropertyName("currency")]
            public string Currency { get; set; }

            [JsonPropertyName("principal")]
            public string Principal { get; set; }

            [JsonPropertyName("returns")]
            public string Returns { get; set; }

            [JsonPropertyName("balance")]
            public string Balance { get; set; }

            [JsonPropertyName("interest_enabled")]
            public bool InterestEnabled { get; set; }

            [JsonPropertyName("interest_rate")]
            public double InterestRate { get; set; }

            [JsonPropertyName("maturity_date")]
            public string MaturityDate { get; set; }

            [JsonPropertyName("created_on")]
            public DateTime CreatedOn { get; set; }
        }
    }
}