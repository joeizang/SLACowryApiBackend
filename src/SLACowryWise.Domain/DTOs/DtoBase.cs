using System.Collections.Generic;
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

    public class Bank
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("acronym")]
        public string Acronym { get; set; }

        [JsonPropertyName("bank_code")]
        public string BankCode { get; set; }

        [JsonPropertyName("nip_bank_code")]
        public object NipBankCode { get; set; }
    }

    public class BankResponse : DtoBase
    {
        [JsonPropertyName("data")]
        public List<Bank> Data { get; set; }
    }
}