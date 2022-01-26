using SLACowryWise.Domain.Services;
using System.Text.Json.Serialization;

namespace SLACowryWise.Domain.DomainModels.WebhookPayloads
{
    [BsonCollection("WebhookResponse")]
    public class WebhookResponse
    {
        public CowryEvent Event { get; set; }

        public object Data { get; set; }

        public string Message { get; set; }
    }

    public class CowryEvent
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
}
