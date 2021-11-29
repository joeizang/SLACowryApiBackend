using System.Text.Json.Serialization;

namespace SLACowryWise.Domain
{
    public class GetPaginatedResponseInputModel
    {
        [JsonPropertyName("page_size")]
        public string PageSize { get; set; }

        [JsonPropertyName("page")]
        public string Page { get; set; }
    }
}