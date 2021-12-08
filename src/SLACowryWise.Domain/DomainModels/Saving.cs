using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Savings;
using SLACowryWise.Domain.Services;

namespace SLACowryWise.Domain.DomainModels
{
    public class SingleSaving : BaseDomainModel
    {
        public SingleSavingsResponse SingleSavingsResponse { get; set; }
    }

    [BsonCollection("SavingsCreated")]
    public class CreateSavings : BaseDomainModel
    {
        public CreateSavingsResponse CreateSavingsResponse { get; set; }
        public string AccountId { get; set; }

        public string CustomerId { get; set; }

        public string ProductType { get; set; }
    }

    [BsonCollection("SavingsFunded")]
    public class FundSavings : BaseDomainModel
    {
        public FundSavingsDtoResponse FundSavingsDtoResponse { get; set; }

        public string AccountId { get; set; }

        public string CustomerId { get; set; }

        public string ProductType { get; set; }
    }

    [BsonCollection("SavingsWithdrawn")]
    public class WithdrawSavings : BaseDomainModel
    {
        public WithdrawFromSavingsDto WithdrawFromSavingsDto { get; set; }

        public string AccountId { get; set; }

        public string CustomerId { get; set; }

        public string ProductType { get; set; }
    }
}