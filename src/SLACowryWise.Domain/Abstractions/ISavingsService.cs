using System.Threading.Tasks;
using RestSharp;
using SLACowryWise.Domain.DomainModels;
using SLACowryWise.Domain.DTOs.Savings;
using SLACowryWise.Domain.DTOs.Wallets;

namespace SLACowryWise.Domain.Abstractions
{
    public interface ISavingsService
    {
        Task<SavingsPaginatedResponseDto> GetAllSavings();

        Task<CreateSavingsResponse> CreateSavings(CreateSavingsInputModel inputModel);

        Task<SingleSavingsByIdResponseDto> GetSingleSavings(string savingsId);

        Task<SavingsRateDtoResponse> GetSavingsRate(string days);

        Task<WithdrawFromSavingsDto> WithdrawFromSavings(WithdrawFromSavingsInputModel inputModel);

        Task<FundSavingsDtoResponse> FundSavingsFromWallet(WalletTransferInputModel inputModel);
    }

    public interface ICreateSavings : IMongodbService<CreateSavings> { }

    public interface IFundSavings : IMongodbService<FundSavings> { }

    public interface IWithdrawSavings : IMongodbService<WithdrawSavings> { }
}