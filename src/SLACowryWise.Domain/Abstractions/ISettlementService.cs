using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SLACowryWise.Domain.Abstractions
{
    public interface ISettlementService
    {
        Task<SettlementResponseDto> WithdrawToUserBankAccount(SettlementInputModel model);
    }

    public class SettlementInputModel
    {
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("bank_id")]
        public string BankId { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    public class SettlementPayload
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }

        [JsonPropertyName("owner_name")]
        public string OwnerName { get; set; }

        [JsonPropertyName("owner_email")]
        public string OwnerEmail { get; set; }

        [JsonPropertyName("source_asset")]
        public string SourceAsset { get; set; }

        [JsonPropertyName("bank_name")]
        public string BankName { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("account_name")]
        public string AccountName { get; set; }
    }

    public class SettlementResponseDto
    {
        [JsonPropertyName("data")]
        public SettlementPayload Data { get; set; }

        [JsonPropertyName("errors")]
        public object Errors { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}