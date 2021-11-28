using System.Threading.Tasks;
using RestSharp;
using SLACowryWise.Domain.DTOs.Savings;
using SLACowryWise.Domain.DTOs.Wallets;

namespace SLACowryWise.Domain.Abstractions
{
    public interface ISavingsService
    {
        Task<SavingsPaginatedResponseDto> GetAllSavings();

        Task<SavingsCreatedResponseDto> CreateSavings(CreateSavingsInputModel inputModel);

        Task<SingleSavingsByIdResponseDto> GetSingleSavings(string savingsId);

        Task<SavingsRateDtoResponse> GetSavingsRate(string days);

        Task<WithdrawFromSavingsDto> WithdrawFromSavings(WithdrawFromSavingsInputModel inputModel);

        Task<FundSavingsDtoResponse> FundSavingsFromWallet(WalletTransferInputModel inputModel);
    }
}