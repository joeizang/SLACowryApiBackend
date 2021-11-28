using System.Text.Json.Serialization;

namespace SLACowryWise.Domain
{
    public class Pagination
    {
        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("previous")]
        public string Previous { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
        
        [JsonPropertyName("current_page")] public string CurrentPage { get; set; }
        
        [JsonPropertyName("total_pages")] public string TotalPages { get; set; }
    }
}