using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Wallets;
using SLACowryWise.Domain.Services;
using System.Text.Json.Serialization;

namespace SLACowryWise.Domain.DomainModels
{
    [BsonCollection("CreatedWallets")]
    public class CreateWallet : BaseDomainModel
    {
        public CreateWalletResponseDto CreateWalletResponseDto { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("customer_Id")]
        public string CustomerId { get; set; }
    }

    [BsonCollection("FundsWalletTransfer")]
    public class FundsWalletTransfer : BaseDomainModel
    {
        public WalletTransferDtoRoot TransferFundsFromWallet { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("customer_Id")]
        public string CustomerId { get; set; }
    }
}
