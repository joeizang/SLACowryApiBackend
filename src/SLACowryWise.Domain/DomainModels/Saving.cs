using RestSharp;
using SLACowryWise.Domain.Abstractions;
using SLACowryWise.Domain.DTOs.Savings;
using SLACowryWise.Domain.DTOs.Wallets;
using SLACowryWise.Domain.Services;

namespace SLACowryWise.Domain.DomainModels
{
    public class SingleSaving : BaseDomainModel
    {
        public RestResponse<SingleSavingsResponse> SingleSavingsResponse { get; set; }
    }

    [BsonCollection("SavingsCreated")]
    public class CreateSavings : BaseDomainModel
    {
        public RestResponse<SavingsCreatedResponse> CreateSavingsResponse { get; set; }

        public CreateSavingsInputModel Response { get; set; }
    }

    [BsonCollection("SavingsFunded")]
    public class FundSavings : BaseDomainModel
    {
        public RestResponse<FundSavingsDtoResponse> FundSavingsDtoResponse { get; set; }
        public WalletTransferInputModel Request { get; internal set; }
    }

    [BsonCollection("SavingsWithdrawn")]
    public class WithdrawSavings : BaseDomainModel
    {
        public RestResponse WithdrawFromSavingsDto { get; set; }
        public WithdrawFromSavingsInputModel Request { get; internal set; }
    }
}