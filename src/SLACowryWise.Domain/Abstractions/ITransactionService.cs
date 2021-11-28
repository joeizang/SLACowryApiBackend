using System.Threading.Tasks;
using SLACowryWise.Domain.DTOs.Transactions;

namespace SLACowryWise.Domain.Abstractions
{
    public interface ITransactionService
    {
        Task<GetDepositResponse> GetSingleDeposit(string id);

        Task<GetWithdrawalResponse> GetSingleWithdrawal(string id);

        Task<SingleTransferResponse> GetSingleTransfer(string id);

        Task<GetTransactionsPaginatedResponse> GetAllTransfers(GetAllTransfersInputModel inputModel);

        Task<GetDepositsPaginatedResponse> GetAllDeposits(GetPaginatedResponseInputModel inputModel);

        Task<GetAllWithdrawalsPaginatedResponse> GetAllWithdrawals(GetPaginatedResponseInputModel inputModel);
    }
}