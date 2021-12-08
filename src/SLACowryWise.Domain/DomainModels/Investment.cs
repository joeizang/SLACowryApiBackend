using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Investments;
using SLACowryWise.Domain.DTOs.Wallets;
using SLACowryWise.Domain.Services;
using System.Text.Json.Serialization;

namespace SLACowryWise.Domain.DomainModels
{
    [BsonCollection("InvestmentsCreated")]
    public class CreateInvestment : BaseDomainModel
    {
        public SingleInvestmentResponseDto SingleInvestmentResponseDto { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("customer_Id")]
        public string CustomerId { get; set; }
    }

    [BsonCollection("InvestmentsLiquidated")]
    public class InvestmentLiquidation : BaseDomainModel
    {
        public InvestmentLiquidatedDto InvestmentLiquidatedDto { get; set; }
        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("customer_Id")]
        public string CustomerId { get; set; }
    }

    [BsonCollection("InvestmentsFunded")]
    public class InvestmentsFunded : BaseDomainModel
    {
        public TransferFromWalletResponseDto FundedInvestmentDto { get; set; }

        [JsonPropertyName("account_id")]
        public string AccountId { get; set; }

        [JsonPropertyName("customer_Id")]
        public string CustomerId { get; set; }
    }



}
