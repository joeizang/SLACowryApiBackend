using System.Text.Json.Serialization;

namespace SLACowryWise.Domain.DTOs
{
    public class DtoBase
    {
        [JsonPropertyName("errors")]
        public object Errors { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}