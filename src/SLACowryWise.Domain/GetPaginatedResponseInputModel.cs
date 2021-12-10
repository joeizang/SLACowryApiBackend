using System.Text.Json.Serialization;

namespace SLACowryWise.Domain
{
    public class GetPaginatedResponseInputModel
    {
        [JsonPropertyName("page_size")]
        public string PageSize { get; set; } = 20.ToString();

        [JsonPropertyName("page")]
        public string Page { get; set; } = 1.ToString();
    }
}